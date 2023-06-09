﻿using Foodie.Domain.Common.Models;
using Foodie.Domain.Menu.ValueObjects;

namespace Foodie.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; }
    public string Description { get; }

    IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
    private MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }
    public static MenuSection Create(string name, string description)
    {
        return new(MenuSectionId.CreateUnique(), name, description);
    }

}
