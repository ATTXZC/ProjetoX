using System;
using System.Security.Cryptography;

public class TokenGenerator
{
    public static string GenerateToken()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] tokenData = new byte[32];
            rng.GetBytes(tokenData);
            return Convert.ToBase64String(tokenData);
        }
    }
}
