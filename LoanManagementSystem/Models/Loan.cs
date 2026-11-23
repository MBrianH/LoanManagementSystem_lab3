namespace LoanManagementSystem.Models
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int ApplicationID { get; set; }
        public decimal ApprovedAmount { get; set; }
        public decimal AmountPaidOut { get; set; }
        public DateTime PayoutDate { get; set; }
        public string PaymentMethod { get; set; } = "";
        public string PaymentReference { get; set; } = "";
        public string LoanStatus { get; set; } = "Active";
    }
}