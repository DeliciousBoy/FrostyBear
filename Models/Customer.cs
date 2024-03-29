﻿using System;
using System.Collections.Generic;

namespace FrostyBear.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public string? CustomerContact { get; set; }

    public string CustomerUsername { get; set; } = null!;

    public string CustomerPassword { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
