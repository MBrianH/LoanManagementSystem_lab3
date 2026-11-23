using System;
using System.Data;
using MySqlConnector;
using LoanManagementSystem.Database;
using LoanManagementSystem.Models;
using LoanManagementSystem.Security;

namespace LoanManagementSystem.Repositories
{
    public class StaffRepository
    {
        public StaffUser? GetStaffByUsername(string username)
        {
            string query = @"SELECT * FROM StaffUsers WHERE Username=@Username LIMIT 1";
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;
                    return new StaffUser
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        FullName = Convert.ToString(reader["FullName"]) ?? "",
                        Username = Convert.ToString(reader["Username"]) ?? "",
                        PasswordHash = Convert.ToString(reader["PasswordHash"]) ?? "",
                        Role = Convert.ToString(reader["Role"]) ?? "",
                        AccountStatus = Convert.ToString(reader["AccountStatus"]) ?? ""
                    };
                }
            }
        }

        public bool AdministratorExists()
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM StaffUsers WHERE Role='Administrator'", con))
            {
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool CreateStaff(string fullName, string username, string password, string role)
        {
            string query = @"INSERT INTO StaffUsers
                (FullName, Username, PasswordHash, Role, AccountStatus)
                VALUES (@name,@username,@hash,@role,'Active')";
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@name", fullName);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@hash", PasswordHasher.HashPassword(password));
                cmd.Parameters.AddWithValue("@role", role);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable GetAll()
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(
                "SELECT UserID,FullName,Username,Role,AccountStatus FROM StaffUsers ORDER BY UserID", con))
            {
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public void UpdateStaff(int userID, string fullName, string username, string role)
        {
            string query = @"UPDATE StaffUsers SET FullName=@name,Username=@username,Role=@role
                             WHERE UserID=@id";
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@name", fullName);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@id", userID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStatus(int userID, string status)
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(
                "UPDATE StaffUsers SET AccountStatus=@status WHERE UserID=@id", con))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", userID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
