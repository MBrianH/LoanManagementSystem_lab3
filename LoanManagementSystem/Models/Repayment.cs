namespace LoanManagementSystem.Models
{
    public class Repayment
    {
        public int RepaymentID { get; set; }
        public int LoanID { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = "";
        public string ReceiptReference { get; set; } = "";
    }
}