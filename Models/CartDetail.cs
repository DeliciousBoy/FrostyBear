using System;
using System.Collections.Generic;

namespace FrostyBear.Models;

public partial class CartDetail
{
    public int CartDetailId { get; set; }

    public int? CartId { get; set; }

    public int? ProductId { get; set; }

    public string? Quantity { get; set; }

    public int? Price { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Product? Product { get; set; }
}
