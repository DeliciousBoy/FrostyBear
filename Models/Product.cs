using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrostyBear.Models;

public partial class Product
{
    
    public int ProductId { get; set; }

    [Required(ErrorMessage = "ต้องระบุชื่อสินค้า")]
    [StringLength(100)]
    [Display(Name = "ชื่อสินค้า")]
    public string ProductName { get; set; } = null!;

    [Display(Name = "ราคา")]
    public decimal? ProductPrice { get; set; }

    [Display(Name = "ประเภท")]
    public int? CategoryId { get; set; }

    [Display(Name = "ยี่ห้อ")]
    public int? BrandId { get; set; }

    [Display(Name = "รายละเอียดสินค้า")]
    public string? Detail { get; set; }

    [Display(Name = "ต้นทุน")]
    public double? ProductCost { get; set; }

    [Display(Name = "จำนวนคงเหลือ")]
    public int? ProductStock { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
