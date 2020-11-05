namespace ACM.API.DTO
{
    public class CustomerToReturn
    {
        public int CustomerId { get; private set; }
        public int CustomerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
    }
}