using System;
using System.Collections.Generic;

namespace FrostyBear.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? ProductPrice { get; set; }

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public string? Detail { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
