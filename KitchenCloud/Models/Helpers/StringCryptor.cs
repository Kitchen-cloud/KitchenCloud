using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.Encrypto;

namespace KitchenCloud.Models.Helpers
{
    public class StringCryptor
    {

        public static string Encrypt(string value)
        {
            try
            {
                Hasher encrptor = new Hasher() { SaltSize = 4 };
                return encrptor.Encrypt(value);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public static bool EncryptComparer(string value,string encryptedValue)
        {
            try
            {
                Hasher decryptor = new Hasher() { SaltSize = 4 };
                return decryptor.CompareStringToHash(value, encryptedValue);
            }
            catch
            {
                return false;
            }
        }
    }
}