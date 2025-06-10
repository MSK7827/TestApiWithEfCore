namespace TestApiWithEfCore.NewFolder
{
    public class CreateBasketDto
    {
        public Guid BasketId { get; set; } = Guid.NewGuid();
        public long CustomerId { get; set; }
        public List<CreateBasketLoanItemDto> BasketLoanItems { get; set; }
    }

    public class CreateBasketLoanItemDto
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public decimal LoanAmount { get; set; }
    }
}
