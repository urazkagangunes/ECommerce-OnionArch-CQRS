﻿using Core.Persistence.Repositories;
using ECommerce.Domain.Entities;

namespace ECommerce.Persistence.Abstracts;

public interface IProductTagRepository : IAsyncRepository<ProductTag, Guid> { }
