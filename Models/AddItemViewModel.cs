namespace ADET_FINAL_PROJECT.Models
{
    public class AddItemViewModel
    {
        public required string Name { get; set; }
        public required string Category { get; set; }
        public required string Description { get; set; }
        public required int Quantity { get; set; }
        public required string Status { get; set; }

        public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
