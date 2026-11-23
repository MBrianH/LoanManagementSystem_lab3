using MySqlConnector;

namespace LoanManagementSystem.Database
{
    public class DatabaseConnection
    {
        // Change the port or password here only if your XAMPP setup is different.
        private static readonly string connectionString =
            "Server=localhost;Port=3306;Database=LoanManagementDB;User ID=root;Password=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
