﻿using System;
using System.Collections.Generic;

namespace FrostyBear.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? ProductPrice { get; set; }

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public string? Detail { get; set; }

    public double? ProductCost { get; set; }

    public int? ProductStock { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
