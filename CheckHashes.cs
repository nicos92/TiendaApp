using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace CheckHashes
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

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Testing the default passwords as per documentation (password = username):");
            
            // Try all the default users as per documentation
            string[] usernames = {"superadmin", "admin", "gerente", "supervisor", "encargado", "empleado"};
            string[] expectedHashes = {
                "100000.wJN6ViU+vJ6fR9bC2zZc6w==.qLUh1qiDKoJKrjlQ5qjy5i3VeKqsXWDhyehV+CTvHdI=",
                "100000.Y3GvwTgJ7VyVLULCChFqHw==.tsnhVRmcSR8c0nDXmKxx6YGo2JogB2C021/Cr8YWmy8=",
                "100000.9IjldYgrPkdLJRDXyF0ihA==.n61Vb7SJxwwO0MCqK0NqODtm8yUggYOBn3bEzGXawlE=",
                "100000.KmT9vWcKnfEVPecEzJxHrA==.h6UsJFlCy8YVm2pmDRVHyTqQ6JJxdS1fX3baQS5VE0U=",
                "100000.0Ty0YpNszl7hLjKZfEN5Gw==.tsF7XcrrrN2V3slmytYH8HFcY/HzMhPgH9MgfHBMU2I=",
                "100000.0g4m7x36yFlXHADKFkC1SQ==.Ma9iAHuPGrfG8i2yPMAVIgFk0YuBB1B2Mpk8keMQKSI="
            };
            
            for (int i = 0; i < usernames.Length; i++)
            {
                string username = usernames[i];
                string hash = expectedHashes[i];
                
                Console.WriteLine($"Testing {username}: {PasswordHasher.Verify(username, hash)}");
            }
            
            Console.WriteLine("\nGenerating new hashes for the default usernames:");
            foreach (string username in usernames)
            {
                string newHash = PasswordHasher.Hash(username);
                Console.WriteLine($"{username}: {newHash}");
            }
        }
    }
}