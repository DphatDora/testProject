using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyword;
            int shift = 0;
            menu:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to caesar cipher app, choose:");
            Console.WriteLine("(E) to encrypt");
            Console.WriteLine("(D) to decrypt");
            Console.WriteLine("(X) to exit");

            Console.ForegroundColor = ConsoleColor.White;
            keyword = Console.ReadLine();

            if (keyword == "E")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to encryption mode");
                Console.WriteLine("Enter message to encrypt: ");
                Console.ForegroundColor = ConsoleColor.White;
                string plaintext = Console.ReadLine();
                if (plaintext == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input");
                    goto menu;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("enter the shift: ");
                Console.ForegroundColor = ConsoleColor.White;
                shift = int.Parse(Console.ReadLine());
                string cipher = CaesarCipher.Encrypt(plaintext, shift);
                string file = @"D:\name.txt";
                StreamWriter sw = new StreamWriter(file, true);
                sw.Write(cipher);
                sw.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cipher is: " + cipher);     
                Console.WriteLine();
                goto menu;
            }
            if (keyword == "D")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to decryption mode");
                Console.WriteLine("Enter the path of file to decrypt: ");
                Console.ForegroundColor = ConsoleColor.White;
                string filepath = Console.ReadLine();
                if (filepath == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input");
                    goto menu;
                }
                System.IO.StreamReader sr = new System.IO.StreamReader(filepath);
                string cipher = CaesarCipher.Decrypt(sr.ReadToEnd(), shift);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(cipher);
                sr.Close();
                Console.WriteLine();
                goto menu;
            }
            if ( keyword =="X")
            {
                System.Environment.Exit(1);
            }
            if (keyword=="")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                goto menu;
            }
        }
    }
}