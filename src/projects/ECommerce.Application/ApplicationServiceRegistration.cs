﻿using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Login;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Serilog.Loggers;
using ECommerce.Application.Features.Auth.Rules;
using ECommerce.Application.Features.Categories.Rules;
using ECommerce.Application.Features.Products.Rules;
using ECommerce.Application.Services.RoleServices;
using ECommerce.Application.Services.UserServices;
using ECommerce.Application.Services.UserWithTokenServices;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<ProductBusinessRules>();
        services.AddTransient<LoggerServiceBase, MsSqlLogger>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserWithTokenService, UserWithTokenService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(con => {
            con.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            con.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            con.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            con.AddOpenBehavior(typeof(LoginBehavior<,>));
            con.AddOpenBehavior(typeof(LoggingBehavior<,>));
            con.AddOpenBehavior(typeof(CachingBehavior<,>));
            con.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            con.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        return services;
    }
}