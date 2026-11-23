namespace LoanManagementSystem.Models
{
    public class LoanApplication
    {
        public int ApplicationID { get; set; }
        public string ReferenceNumber { get; set; } = "";
        public int ClientID { get; set; }
        public decimal AmountRequested { get; set; }
        public string Purpose { get; set; } = "";
        public int RepaymentPeriod { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = "Pending Review";
        public string SupportingNotes { get; set; } = "";
    }
}