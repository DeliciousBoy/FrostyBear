using System;
using System.Collections.Generic;

namespace FrostyBear.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeeContact { get; set; }

    public string? EmployeeUsername { get; set; }

    public string? EmployeePassword { get; set; }

    public int? PositionId { get; set; }

    public virtual Position? Position { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
