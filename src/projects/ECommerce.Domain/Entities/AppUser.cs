﻿using Core.Security.Entities;

namespace ECommerce.Domain.Entities;

public sealed class AppUser : User
{
    public ICollection<Order> Orders { get; set; }
}
