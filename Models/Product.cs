namespace FreakyFashion.Models
{
    class Product
    {
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
