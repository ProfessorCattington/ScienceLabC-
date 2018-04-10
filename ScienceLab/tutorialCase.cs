using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceLab
{
    public class tutorialCase
    {

        public void RunCase()
        {
            string inputFilePath = "C:\\Users\\Mike\\Documents\\sum.in";
            string[] textData = LoadInputTextFromFile(inputFilePath);

            if (textData != null)
            {

                string outputFilePath = "C:\\Users\\Mike\\Documents\\sum_sample.out";
                List<int> addedNumbersFromTextFile = ConvertStringsAndAddThem(textData);


                OutputFormattedNumbersToConsole(addedNumbersFromTextFile, 1);
                OutputFormattedNumbersToFile(outputFilePath, addedNumbersFromTextFile, 1);
            }

            Console.ReadKey();
        }

        private static string[] LoadInputTextFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                return lines;

            }
            else
            {
                Console.WriteLine("could not find file at: " + filePath);
                return null;
            }
        }

        private List<int> ConvertStringsAndAddThem(string[] strings)
        {

            List<int> numbers = new List<int>();
            //conver the strings to integers, add them and return them so we can output them
            string[] separators = { " " };

            for (int i = 0; i < strings.Length; i++)
            {
                string[] separatedStrings = strings[i].Split(separators, System.StringSplitOptions.RemoveEmptyEntries);

                int addedNumbers = 0;
                foreach (string number in separatedStrings)
                {
                    addedNumbers += int.Parse(number);

                }

                numbers.Add(addedNumbers);
            }
            return numbers;
        }

        private void OutputFormattedNumbersToConsole(List<int> numbers, int startingLine)
        {
            for (int i = startingLine; i < numbers.Count; i++)
            {
                Console.WriteLine("Case #" + i);
                Console.WriteLine(numbers[i]);
            }
        }

        private void OutputFormattedNumbersToFile(string filePath, List<int> numbers, int startingLine)
        {
            StreamWriter streamWriter = new StreamWriter(filePath);

            for (int i = startingLine; i < numbers.Count; i++)
            {
                streamWriter.WriteLine("Case #" + i);
                streamWriter.WriteLine(numbers[i]);
            }

            streamWriter.Close();
        }
    }
}
