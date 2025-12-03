using System;
using TiendaApp.Utilidad;

class Program
{
    static void Main()
    {
        // Hashes from the database initialization script
        string superadminHash = "100000.wJN6ViU+vJ6fR9bC2zZc6w==.qLUh1qiDKoJKrjlQ5qjy5i3VeKqsXWDhyehV+CTvHdI=";
        string adminHash = "100000.Y3GvwTgJ7VyVLULCChFqHw==.tsnhVRmcSR8c0nDXmKxx6YGo2JogB2C021/Cr8YWmy8=";
        string gerenteHash = "100000.9IjldYgrPkdLJRDXyF0ihA==.n61Vb7SJxwwO0MCqK0NqODtm8yUggYOBn3bEzGXawlE=";
        string supervisorHash = "100000.KmT9vWcKnfEVPecEzJxHrA==.h6UsJFlCy8YVm2pmDRVHyTqQ6JJxdS1fX3baQS5VE0U=";
        string encargadoHash = "100000.0Ty0YpNszl7hLjKZfEN5Gw==.tsF7XcrrrN2V3slmytYH8HFcY/HzMhPgH9MgfHBMU2I=";
        string empleadoHash = "100000.0g4m7x36yFlXHADKFkC1SQ==.Ma9iAHuPGrfG8i2yPMAVIgFk0YuBB1B2Mpk8keMQKSI=";

        // Test if the passwords are the same as the usernames
        Console.WriteLine("Testing if passwords match usernames:");
        Console.WriteLine($"superadmin password: {PasswordHasher.Verify("superadmin", superadminHash)}");
        Console.WriteLine($"admin password: {PasswordHasher.Verify("admin", adminHash)}");
        Console.WriteLine($"gerente password: {PasswordHasher.Verify("gerente", gerenteHash)}");
        Console.WriteLine($"supervisor password: {PasswordHasher.Verify("supervisor", supervisorHash)}");
        Console.WriteLine($"encargado password: {PasswordHasher.Verify("encargado", encargadoHash)}");
        Console.WriteLine($"empleado password: {PasswordHasher.Verify("empleado", empleadoHash)}");

        // If the above are false, let's try some common default passwords
        Console.WriteLine("\nTesting common default passwords:");
        string[] commonPasswords = { "123456", "password", "123456789", "12345", "12345678", "qwerty", "1234567", "111111" };
        
        foreach (string pwd in commonPasswords)
        {
            Console.WriteLine($"Testing '{pwd}' as superadmin password: {PasswordHasher.Verify(pwd, superadminHash)}");
            Console.WriteLine($"Testing '{pwd}' as admin password: {PasswordHasher.Verify(pwd, adminHash)}");
        }

        // Let's also test some other possibilities like "TiendaApp", "tienda", etc.
        string[] otherPossibilities = { "TiendaApp", "tienda", "Tienda", "TIENDA", "Tienda123", "" };
        Console.WriteLine("\nTesting other possibilities:");
        foreach (string pwd in otherPossibilities)
        {
            Console.WriteLine($"Testing '{pwd}' as superadmin password: {PasswordHasher.Verify(pwd, superadminHash)}");
            Console.WriteLine($"Testing '{pwd}' as admin password: {PasswordHasher.Verify(pwd, adminHash)}");
        }
    }
}