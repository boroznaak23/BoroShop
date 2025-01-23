namespace Lab2.Models
{
    public class AddProductViewModel
    {
        public string? Name { get; set; }
        public required string Model { get; set; }
        public required string Category { get; set; }
        public int? Memory { get; set; }
    }
}
