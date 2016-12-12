using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EncryptDecrypt
{
    public class MyObject
{
    public string MyString { get; set; }
}
    class Program
    {
        static void Main(string[] args)
        {


        

            var a = AESEncryption.Encrypt("test");

            Console.WriteLine( AESEncryption.Decrypt(a));
        }
    }
}
