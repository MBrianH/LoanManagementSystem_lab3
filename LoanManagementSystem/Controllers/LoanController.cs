using System.Data;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repositories;

namespace LoanManagementSystem.Controllers
{
    public class LoanController
    {
        private readonly LoanRepository repository = new LoanRepository();

        public DataTable GetClients(string search = "") => repository.GetClients(search);
        public void SaveClient(Client client)
        {
            if (string.IsNullOrWhiteSpace(client.FullName) ||
                string.IsNullOrWhiteSpace(client.IdentificationNumber) ||
                string.IsNullOrWhiteSpace(client.PhoneNumber) ||
                string.IsNullOrWhiteSpace(client.Address))
                throw new Exception("Complete all client fields.");
            repository.SaveClient(client);
        }
        public DataTable GetApplications(string search = "", string status = "") => repository.GetApplications(search, status);
        public DataTable GetClientChoices() => repository.GetClientChoices();
        public void AddApplication(LoanApplication application)
        {
            if (application.ClientID <= 0 || application.AmountRequested <= 0 ||
                application.RepaymentPeriod <= 0 || string.IsNullOrWhiteSpace(application.Purpose))
                throw new Exception("Select a client and enter a valid amount, purpose and repayment period.");
            application.ReferenceNumber = "LA-" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            repository.AddApplication(application);
        }
        public void UpdateApplication(LoanApplication application)
        {
            if (application.ApplicationID <= 0 || application.ClientID <= 0 ||
                application.AmountRequested <= 0 || application.RepaymentPeriod <= 0 ||
                string.IsNullOrWhiteSpace(application.Purpose))
                throw new Exception("Enter valid application details.");
            repository.UpdateApplication(application);
        }
        public void Decide(int id, string decision, string note, int approverID)
        {
            if (id <= 0) throw new Exception("Select a pending application.");
            decision = decision.Trim();
            if (decision != "Approved" && decision != "Rejected")
                throw new Exception("Decision must be Approved or Rejected.");
            if (decision == "Rejected" && string.IsNullOrWhiteSpace(note))
                throw new Exception("A note is required when rejecting an application.");
            repository.Decide(id, decision, note, approverID);
        }
        public DataTable GetApprovedApplications(string search = "") => repository.GetApprovedApplications(search);
        public void AddPayout(int id, decimal amount, DateTime date, string method, string reference, int period)
        {
            if (id <= 0 || period <= 0 || string.IsNullOrWhiteSpace(method))
                throw new Exception("Complete the payout details.");
            repository.AddPayout(id, amount, date, method, reference, period);
        }
        public DataTable GetActiveLoans(string search = "") => repository.GetActiveLoans(search);
        public DataTable GetLoanChoices() => repository.GetLoanChoices();
        public void AddRepayment(int id, decimal amount, DateTime date, string method, string reference)
        {
            if (id <= 0 || amount <= 0 || string.IsNullOrWhiteSpace(method))
                throw new Exception("Complete the repayment details.");
            repository.AddRepayment(id, amount, date, method, reference);
        }
        public DataTable GetRepayments(string search = "") => repository.GetRepayments(search);
        public DataTable GetSchedule(string search = "") => repository.GetSchedule(search);
        public DataTable GetReports(DateTime fromDate, DateTime toDate) => repository.GetReports(fromDate, toDate);
        public DataTable GetClientChoicesForReports() => repository.GetClientChoices();
        public DataTable GetLoanStatement(int clientID) => repository.GetLoanStatement(clientID);
        public DataTable GetDashboardCounts() => repository.GetDashboardCounts();
    }
}
