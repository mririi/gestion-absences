using BCrypt.Net;

namespace GestionAbscences.Helpers
{
    public static class PasswordHelper
    {
        // Hash password using bcrypt
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Verify password using bcrypt
        public static bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPassword);
        }
    }
}
