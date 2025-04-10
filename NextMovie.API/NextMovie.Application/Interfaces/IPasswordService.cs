namespace NextMovie.Application.Interfaces
{
    public interface IPasswordService
    {
        /// <summary>
        /// Creates a password hash and salt from the provided password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        /// <summary>
        /// Verifies if the provided password matches the stored hash and salt.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="storedHash"></param>
        /// <param name="storedSalt"></param>
        /// <returns></returns>
        bool IsCorrectPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}
