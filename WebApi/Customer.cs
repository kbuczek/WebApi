namespace WebApi
{
    public class Customer
    {
        //properties
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public Int64 vat_Id { get; set; } = 0;
        public string CreationDate { get; set; } = String.Empty;
        public string AddressCity { get; set; } = String.Empty;
        public string AddressStreet { get; set; } = String.Empty;
        public string AddressPostalCode { get; set; } = String.Empty;

    }
}
