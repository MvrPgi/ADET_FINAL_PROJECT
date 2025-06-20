using Azure.Identity;

namespace ADET_FINAL_PROJECT.Models.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
