using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Entropia
{
    class Program
    {
        private static int _countOfBytes = 0;
        private static int _countOfDifferentBytes = 0;

        private static double _entropy = 0;

        static void Main(string[] args)
        {
            List<int> bytes = ReadFileBytes("C:/Users/Pufyrka/Desktop/bundletool-all-1.8.0.jar");

            _countOfBytes = bytes.Count;

            //WriteBytes(bytes);

            Dictionary<int, float> frequency = CalculateFrequency(bytes);

            WriteFrequency(frequency);



            _countOfDifferentBytes = frequency.Count;
            foreach(var element in frequency)
            {
                frequency[element.Key] /= _countOfBytes;

                _entropy += frequency[element.Key] * Math.Log2(frequency[element.Key]);
            }


            Console.WriteLine(-_entropy);
        }


        private static List<int> ReadFileBytes(string filePath)
        {
            FileStream stream = File.OpenRead(filePath);
            List<int> bytes = new List<int>();

            int b = 0;
            while ((b = stream.ReadByte()) > -1)
            {
                bytes.Add(b);
            }

            return bytes;
        }


        private static void WriteBytes(List<int> bytes)
        {
            Console.WriteLine("Байты:");

            for(int i = 0; i < bytes.Count; i++)
            {
                Console.WriteLine(bytes[i]);
            }
        }


        private static void WriteFrequency(Dictionary<int, float> frequency)
        {
            Console.WriteLine("Частоты:");

            foreach (var element in frequency)
            {
                Console.WriteLine((char)element.Key + " - " + element.Value);
            }

            Console.WriteLine("Количество различных символов: " + frequency.Count);
        }


        private static Dictionary<int, float> CalculateFrequency(List<int> bytes)
        {
            Dictionary<int, float> frequency = new Dictionary<int, float>();


            for (int i = 0; i < bytes.Count; i++)
            {
                if (frequency.ContainsKey(bytes[i]))
                    frequency[bytes[i]]++;
                else
                    frequency.Add(bytes[i], 1);
            }


            return frequency;
        }
    }
}
