namespace LoanManagementSystem.Models
{
    public class Decision
    {
        public int DecisionID { get; set; }
        public int ApplicationID { get; set; }
        public string DecisionStatus { get; set; } = "";
        public string DecisionNote { get; set; } = "";
        public DateTime DecisionDate { get; set; }
        public int ApproverID { get; set; }
    }
}