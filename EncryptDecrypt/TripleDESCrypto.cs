using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
    public class TripleDESCrypto
    {
        //"k28e3343453" 'Please do not delete or do not change password
        public static string DefaultPassword = "test";

        public static string Encrypting(string original)
        {
            try
            {
                if (!string.IsNullOrEmpty(original))
                    return encrypt(original, DefaultPassword);
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string Decrypting(string encryptedString)
        {
            try
            {
                if (!string.IsNullOrEmpty(encryptedString))
                    return Decrypt(encryptedString, DefaultPassword);
                return string.Empty;

                //Return TripleDESDecode(encryptedString, _DefaultPassword)
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private static string encrypt(string original, string passward)
        {
            try
            {
                original = original.Trim();
                MD5CryptoServiceProvider md5Hash = new MD5CryptoServiceProvider();


                byte[] passwordhash = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(passward));

                TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
                cryptoProvider.Key = passwordhash;
                cryptoProvider.Mode = CipherMode.ECB;


                byte[] buffer = Encoding.ASCII.GetBytes(original);
                cryptoProvider.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length);

                string encrypted = Convert.ToBase64String(cryptoProvider.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
                return encrypted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string Decrypt(string encryptedString, string password)
        {
            try
            {
                encryptedString = encryptedString.Trim();

                MD5CryptoServiceProvider md5Hash = new MD5CryptoServiceProvider();
                byte[] passwordhash = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(password));

                TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
                cryptoProvider.Key = passwordhash;
                cryptoProvider.Mode = CipherMode.ECB;


                byte[] buffer = Convert.FromBase64String(encryptedString);
                byte[] desbuffer = cryptoProvider.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length);

                string decrypted = Encoding.ASCII.GetString(desbuffer);

                return decrypted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
