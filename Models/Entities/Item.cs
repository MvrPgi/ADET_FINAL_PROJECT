namespace ADET_FINAL_PROJECT.Models.Entities
{
    public class Item
    {
        public Guid ID { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public required string Description { get; set; }
        public required int Quantity { get; set; } 
        public required string Status { get; set; } 

        public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
    