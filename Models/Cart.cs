using System;
using System.Collections.Generic;

namespace FrostyBear.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public string? CustomerId { get; set; }

    public DateTime? CartDate { get; set; }

    public string? TotalAmount { get; set; }

    public double? CartQty { get; set; }

    public string? CartCf { get; set; }

    public string? CartPay { get; set; }

    public string? CartSend { get; set; }

    public string? CartVoid { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Customer? Customer { get; set; }
}
