using LoanManagementSystem.Models;
using LoanManagementSystem.Repositories;
using LoanManagementSystem.Security;

namespace LoanManagementSystem.Controllers
{
    public class LoginController
    {
        private readonly StaffRepository repository = new StaffRepository();

        public StaffUser? Login(string username, string password)
        {
            StaffUser? staff = repository.GetStaffByUsername(username);
            if (staff == null || staff.AccountStatus != "Active") return null;
            if (!PasswordHasher.VerifyPassword(password, staff.PasswordHash)) return null;
            return staff;
        }
    }
}
