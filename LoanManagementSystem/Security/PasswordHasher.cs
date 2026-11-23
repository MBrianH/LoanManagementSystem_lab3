using System.Security.Cryptography;

namespace LoanManagementSystem.Security
{
    public class PasswordHasher
    {
        private const int Iterations = 600000;

        public static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, Iterations, HashAlgorithmName.SHA256, 32);

            return Iterations + "." +
                   Convert.ToBase64String(salt) + "." +
                   Convert.ToBase64String(hash);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            try
            {
                string[] parts = storedHash.Split('.');
                int iterations = int.Parse(parts[0]);
                byte[] salt = Convert.FromBase64String(parts[1]);
                byte[] savedHash = Convert.FromBase64String(parts[2]);

                byte[] enteredHash = Rfc2898DeriveBytes.Pbkdf2(
                    password, salt, iterations,
                    HashAlgorithmName.SHA256, savedHash.Length);

                return CryptographicOperations.FixedTimeEquals(savedHash, enteredHash);
            }
            catch
            {
                return false;
            }
        }
    }
}
