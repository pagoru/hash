using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace hash01
{
   
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Programa iniciat.");
            while (true)
            {
                Console.WriteLine("[0] Calcular el Hash");
                Console.WriteLine("[1] Verificar un hash");
                Console.WriteLine("[2] Sortir");

                String option = readLine("Introudeix una de les opcions:");
                
                if (option == "0")
                {
                    createHashFileFromFile();
                }
                else if (option == "1")
                {
                    verifyFileFromHashFile();
                }
                else if (option == "2")
                {
                    Console.WriteLine("Has sortit.");
                    break;
                } else
                {
                    Console.WriteLine("Introdueix una opció valida.");
                }
            }

        }

        static void verifyFileFromHashFile()
        {
            try
            {
                String path = readLine("Introdueix la ruta de l'arxiu que conté el text: ");
                String text = System.IO.File.ReadAllText(@path);
                String pathHash = readLine("Introdueix la ruta de l'arxiu que conté el hash: ");
                String hash = System.IO.File.ReadAllText(@pathHash);

                String hashText = getHash(text);

                Console.WriteLine((hash == hashText) ? "El hash es correcte." : "El hash es incorrecte.");
            } catch(FileNotFoundException e){
                Console.WriteLine(e.Message);
            }
        }

        static void createHashFileFromFile()
        {
            try
            {
                String path = readLine("Introdueix la ruta de l'arxiu: ");
                String text = System.IO.File.ReadAllText(@path);
                String pathHash = readLine("Introdueix la ruta on vols guardar el hash: ");
                System.IO.File.WriteAllText(@pathHash, getHash(text));
            } catch(FileNotFoundException e){
                Console.WriteLine(e.Message);
            }
}

        static String getHash(String text)
        {
            byte[] bytesIn = UTF8Encoding.UTF8.GetBytes(text);
            SHA512Managed SHA512 = new SHA512Managed();
            byte[] hashResult = SHA512.ComputeHash(bytesIn);
            SHA512.Dispose();
            return BitConverter.ToString(hashResult, 0);
        }

        static String readLine(String sendText)
        {
            String text = null;
            Console.WriteLine(sendText);
            while (text == null)
            {
                text = Console.ReadLine();
            }
            return text;
        }
    }
}
