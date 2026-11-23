namespace LoanManagementSystem.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FullName { get; set; } = "";
        public string IdentificationNumber { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime RegistrationDate { get; set; }
    }
}