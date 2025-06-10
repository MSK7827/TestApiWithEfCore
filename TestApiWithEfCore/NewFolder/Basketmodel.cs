using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestApiWithEfCore.NewFolder
{
    public class BasketModel
    {
        // Primary Key
        [Key]
        public Guid BasketId { get; set; }

        // Foreign Key to Customer
        public long CustomerId { get; set; }

        // Navigation Property
        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        // One-to-Many Relationship
        public virtual List<BasketLoanItem> BasketLoanItems { get; set; } = new();
    }

}
