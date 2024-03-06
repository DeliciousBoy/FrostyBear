namespace FrostyBear.ViewModels
{
    public class PdVM
    {
        public string ProductId { get; set; } 
        public string ProductName { get; set; } = null!;
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? Detail { get; set; }
        public double? ProductCost { get; set; }
        public int? ProductStock { get; set; }
    }
}
