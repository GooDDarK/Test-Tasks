﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку для сжатия:");

            while (true)
            {
                string userText = Console.ReadLine();

                string compressed = CompessDecompress.Compress(userText);
                Console.WriteLine($"Сжатая строка: {compressed}");

                string decompressed = CompessDecompress.Decompress(compressed);
                Console.WriteLine($"Разжатая строка: {decompressed}");
            }
        }
    }
}
