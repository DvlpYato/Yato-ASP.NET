using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Connect
{
    public class EncodeString
    {
        public EncodeString()
        {
        }


        public static string MD5HashCyptography(String string2md5) { 
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMD5 = md5.ComputeHash(Encoding.Default.GetBytes(string2md5));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMD5.Length; i++) {
                sb.AppendFormat("{0:x2}",dataMD5[i]);
            }
            string2md5 = sb.ToString();
            return string2md5;
            
        }


        public static string EndcodeTo64(string text) {
            byte[] toencode = Encoding.Unicode.GetBytes(text);
            string returnencode = Convert.ToBase64String(toencode);
            return returnencode;
        }

        public static string DecodeFormat64(string text) {
            byte[] todecode = Convert.FromBase64String(text);
            string returndecode = Encoding.Unicode.GetString(todecode);
            return returndecode;
        }

    }
}
