using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SHA256 hash = SHA256.Create();
            string password = "adminadmin123";
            password = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(c => c.ToString()));
            Console.WriteLine(password);
        }
    }
}