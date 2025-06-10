using System.Text.Json.Serialization;

namespace TestApiWithEfCore.NewFolder
{
    public class BasketLoanItem
    {
        public int Id { get; set; }
        public Guid LoanItemId { get; set; }
        public Guid BasketId { get; set; }

        public string ItemName { get; set; }

        //foregion key
        public decimal LoanAmount { get; set; }

        // Navigation Property
        [JsonIgnore]
        public virtual BasketModel BasketModel { get; set; }
    }

}