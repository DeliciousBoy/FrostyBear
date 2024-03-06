using System;
using System.Collections.Generic;

namespace FrostyBear.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int? ProductId { get; set; }

    public int? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? SaleDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Product? Product { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
