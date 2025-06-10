namespace TestApiWithEfCore.NewFolder
{
    public class Customer
    {
        public long CustomerId { get; set; }
        public string Name { get; set; }

        // One-to-One Relationship
        public virtual BasketModel Basket { get; set; }
    }

}
