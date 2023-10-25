using System.Security.Cryptography;
using System.Text;

namespace Domain.Endpoint
{
    public class ServiceEncryptDecrypt
    {
        public string Encrypt(string Password)
        {
            string hash = "coding con c";
            byte[] data=UTF8Encoding.UTF8.GetBytes(Password);

            MD5 md5=MD5.Create();
            TripleDES tripleDES = TripleDES.Create();

            tripleDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDES.Mode = CipherMode.ECB;

            ICryptoTransform transform=tripleDES.CreateEncryptor();
            byte[] result=transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);

        }

        public string Decrypt(string Password)
        {
            string hash = "coding con c";
            byte[] data = Convert.FromBase64String(Password);

            MD5 md5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();

            tripleDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDES.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(result); 

        }
    }
}
