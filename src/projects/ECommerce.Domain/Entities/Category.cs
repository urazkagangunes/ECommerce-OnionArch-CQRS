﻿using Core.Persistence.Repositories;

namespace ECommerce.Domain.Entities;

public sealed class Category : Entity<int>
{
    public string Name { get; set; } = default!;
    public ICollection<SubCategory> SubCategories { get; set; }
}
