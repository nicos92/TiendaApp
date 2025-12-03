using System;
using System.Security.Cryptography;
using System.Text;

namespace TiendaApp.Utilidad
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;          // 128-bit salt
        private const int KeySize = 32;           // 256-bit key
        private const int Iterations = 100000;    // PBKDF2 iterations

        public static string Hash(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[SaltSize];
            rng.GetBytes(salt);

            byte[] key = PBKDF2(password, salt, Iterations, KeySize);

            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(key)}";
        }

        public static bool Verify(string password, string hashString)
        {
            var parts = hashString.Split('.');

            if (parts.Length != 3)
                return false;

            int iterations = int.Parse(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] key = Convert.FromBase64String(parts[2]);

            byte[] incoming = PBKDF2(password, salt, iterations, key.Length);

            return CryptographicOperations.FixedTimeEquals(incoming, key);
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}
