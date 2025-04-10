using NextMovie.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace NextMovie.Application.Services
{
    public class PasswordService : IPasswordService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("The password should not be null or empty!");
            }

            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool IsCorrectPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("The password should not be null or empty!");
            }

            using var hmac = new HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != storedHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
