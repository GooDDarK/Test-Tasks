using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class CompessDecompress
    {
        public static string Compress(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return inputText;

            StringBuilder compressedText = new StringBuilder();
            char currentChar = inputText[0];
            int count = 1;

            for (int i = 1; i < inputText.Length; i++)
            {
                if (inputText[i] == currentChar)
                {
                    count++;
                }
                else
                {
                    compressedText.Append(currentChar);
                    if (count > 1)
                        compressedText.Append(count);

                    currentChar = inputText[i];
                    count = 1;
                }
            }

            compressedText.Append(currentChar);
            if (count > 1)
                compressedText.Append(count);

            return compressedText.ToString();
        }

        public static string Decompress(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return inputText;

            StringBuilder result = new StringBuilder();
            int i = 0;

            while (i < inputText.Length)
            {
                char currentChar = inputText[i];
                i++;

                int count = 0;
                while (i < inputText.Length && char.IsDigit(inputText[i]))
                {
                    count = count * 10 + (inputText[i] - '0');
                    i++;
                }

                if (count == 0)
                    result.Append(currentChar);
                else
                    result.Append(currentChar, count);
            }

            return result.ToString();
        }
    }
}
