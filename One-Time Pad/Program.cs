using System;

namespace One_Time_Pad
{
    class Program
    {
        static Random rand = new Random();

        static string OneTimePad(string input)
        {
            string encryptedString = "";

            for (int i = 0; i < input.Length; i++)
            {
                encryptedString += (char)rand.Next('A', 'Z');
            }

            return encryptedString;
        }

        static string Encrypt(string input, string key)
        {
            string encryptedString = "";
            for (int i = 0; i < input.Length; i++)
            {
                int mod = (key[i] + input[i]) % 127;
                encryptedString += (char)mod;
            }
            return encryptedString;
        }

        static string Decrypt(string encryptedString, string key)
        {
            string decryptedString = "";

            for (int i = 0; i < encryptedString.Length; i++)
            {
                //  A     B
                // (65 + 66) % 127 = 4
                // 4 - 66 = -62 + 127 = 65
                //
                //  G  + X
                // (71 + 88) % 127 = 32
                // 32 - 88 = -56 + 127 = 71
                //
                //  (A + A)
                //  (65 + 65) % 127 = 3
                //  3 - 65 = -62 + 127 = 65

                int num = encryptedString[i] - key[i];

                char decryptedChar = (char)(num + 127);

                decryptedString += decryptedChar;
            }

            return decryptedString;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Give string");
            string input = Console.ReadLine();

            string key = OneTimePad(input);
            string encryptedString = Encrypt(input, key);
            string decryptedString = Decrypt(encryptedString, key);
            Console.WriteLine("Key: " + key);
            Console.WriteLine("Encrypted: " + encryptedString);
            Console.WriteLine("Decrypted: " + decryptedString);
        }
    }
}
