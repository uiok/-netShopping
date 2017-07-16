using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace shoppingCart.Helpers
{
    public class AESHelper
    {
        private static byte[] RijndaelKey = new byte[] {
            78, 210, 116, 255, 191, 179, 227, 81, 121, 211, 182, 204, 122, 103, 23, 20, 195, 192, 96, 27, 83, 52, 77, 18, 142, 214, 247, 11, 146, 207, 161, 214 };

        private static byte[] RijndaelIV =
             new byte[] { 146, 205, 113, 116, 103, 75, 41, 253, 163, 23, 163, 255, 105, 27, 223, 22 };

        private static Encoding RijndaelEncoding = Encoding.UTF8;

        //AES加密
        public static string AES_Encryption(string PlainCode)
        {
            RijndaelManaged RijndaelObject = new RijndaelManaged()
            {
                Key = RijndaelKey,
                IV = RijndaelIV
            };

            byte[] DataArray = RijndaelEncoding.GetBytes(PlainCode);
            ICryptoTransform transform = RijndaelObject.CreateEncryptor(RijndaelKey, RijndaelIV);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write);

            cs.Write(DataArray, 0, DataArray.Length);
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        //AES解密
        public static string AES_Decryption(string PlainCode)
        {
            RijndaelManaged RijndaelObject = new RijndaelManaged()
            {
                Key = RijndaelKey,
                IV = RijndaelIV
            };

            byte[] DataArray = Convert.FromBase64String(PlainCode);
            ICryptoTransform transform = RijndaelObject.CreateDecryptor(RijndaelObject.Key, RijndaelObject.IV);
            MemoryStream ms = new MemoryStream(DataArray);
            CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Read);

            byte[] ReadArray = new byte[DataArray.Length];
            int ReadLenth = cs.Read(ReadArray, 0, ReadArray.Length);
            return RijndaelEncoding.GetString(ReadArray, 0, ReadLenth);
        }

    }
}