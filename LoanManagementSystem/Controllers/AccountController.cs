using LoanManagementSystem.Repositories;

namespace LoanManagementSystem.Controllers
{
    public class AccountController
    {
        private readonly StaffRepository repository = new StaffRepository();

        public bool AdministratorExists()
        {
            return repository.AdministratorExists();
        }

        public void CreateAccount(string fullName, string username, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
                throw new Exception("Complete all required fields.");

            if (password.Length < 8)
                throw new Exception("Password must contain at least 8 characters.");

            if (role != "Administrator" && role != "Loan Officer" &&
                role != "Loan Manager" && role != "Cashier")
                throw new Exception("Select a valid staff role.");

            if (!repository.CreateStaff(fullName.Trim(), username.Trim(), password, role))
                throw new Exception("The account could not be created.");
        }
    }
}
