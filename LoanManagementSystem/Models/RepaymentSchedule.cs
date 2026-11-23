namespace LoanManagementSystem.Models
{
    public class RepaymentSchedule
    {
        public int ScheduleID { get; set; }
        public int LoanID { get; set; }
        public DateTime DueDate { get; set; }
        public decimal ExpectedAmount { get; set; }
        public string InstalmentStatus { get; set; } = "Pending";
    }
}
