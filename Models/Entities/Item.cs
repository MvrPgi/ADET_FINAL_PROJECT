namespace ADET_FINAL_PROJECT.Models.Entities
{
    public class Item
    {
        public Guid ID { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public required string Description { get; set; }
        public required string Quantity { get; set; }
        public string Status { get; set; } = "High"; // ✅ Default value here
    }
}
    