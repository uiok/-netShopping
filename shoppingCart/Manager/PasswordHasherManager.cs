using Microsoft.AspNet.Identity;
using shoppingCart.Helpers;

namespace shoppingCart.Manager
{
    public class PasswordHasherManager : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return AESHelper.AES_Encryption(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            string decryptedPassword = AESHelper.AES_Decryption(hashedPassword);

            if (decryptedPassword.Equals(providedPassword))
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }
}