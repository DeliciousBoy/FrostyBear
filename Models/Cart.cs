using System;
using System.Collections.Generic;

namespace FrostyBear.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CartDate { get; set; }

    public string? TotalAmount { get; set; }

    public bool? IsCheckedOut { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Customer? Customer { get; set; }
}
