using System.Security.Cryptography;

namespace Drona.AyushmanBharat.Infrastructure.Utilities
{
    public  class SecureNow
    {
        public static string EncryptDataUsingRSA(string publicKey, string dataToEncrypt)
        {
            try
            {
                String pubB64 = publicKey;
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(dataToEncrypt);
                byte[] publicKeyBytes = Convert.FromBase64String(pubB64);

                var keyLengthBits = 2048;  // need to know length of public key in advance!
                byte[] exponent = new byte[3];
                byte[] modulus = new byte[keyLengthBits / 8];
                Array.Copy(publicKeyBytes, publicKeyBytes.Length - exponent.Length, exponent, 0, exponent.Length);
                Array.Copy(publicKeyBytes, publicKeyBytes.Length - exponent.Length - 2 - modulus.Length, modulus, 0, modulus.Length);

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                RSAParameters rsaKeyInfo = rsa.ExportParameters(false);
                rsaKeyInfo.Modulus = modulus;
                rsaKeyInfo.Exponent = exponent;
                rsa.ImportParameters(rsaKeyInfo);
                byte[] encrypted = rsa.Encrypt(textBytes, RSAEncryptionPadding.Pkcs1);
                return Convert.ToBase64String(encrypted);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
