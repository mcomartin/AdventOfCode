using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load in file containing the data
            string workingDirectory = Environment.CurrentDirectory;
            string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @"input.txt");
            string[] input = File.ReadAllLines(path);

            //Create new array to contain expanded version of the original
            string [] expandedInput = ExpandTextFile(input);
   
            //Export string array to new file
            string exportedFilePath = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @"ExpandedInput.txt");
            System.IO.File.WriteAllLines(exportedFilePath, expandedInput);


            //Traversal
            int right = 1;
            int numberOfTrees = 0;
            int index = 0;
            List<char> tobogganRide = new List<char>();

            for (int i = 0; i < expandedInput.Length; i += 2) //adjust value that i increases by to reflect the number of down units (ex. 2 down, i += 2)
            {
                for (int j = 0; j <= right; j++)
                {
                    if (j == right)
                    {
                        if (i != expandedInput.Length - 1)
                        {
                            tobogganRide.Add(expandedInput[i + 2][right]); //add to i the number of down units
                            if (tobogganRide[index] == '#')
                            {
                                numberOfTrees++;
                            }
                            index++; //tracks number of iterations since i doesn't always increase by 1 (ex. in the case of right 1, down 2)
                        }
                    }
                }
                right += 1;
            }

            //Analysis
            Console.WriteLine("The number of trees encountered on the toboggan ride was {0}", numberOfTrees);


            //Console.ReadLine();
           
        }

        //Method increases size of input arrays strings by concatenating a prescribed amount of copies of each element
        public static string[] ExpandTextFile(string[] input)
        {
            string[] enlargedInput = input;

            //Tracks how many times the program enters inner If statement of For loop. Controls how many copies of the original input array at i index to add. Made it equal to 40 to ensure enough chars for Right 7, Down 1
            int multiplier = 0;

            //This loop creates a cascading effect where each successive set of 10 elements replicates itself by the multiplier value
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 10 == 0) //Modulo operator (%) will cause this statement to only be true when i is divisable by 10. Ex. 10, 20, 30, etc.
                {
                    multiplier++;

                    int j = i;
                    int limiter = 0;
                    while (limiter < 10 && j < input.Length)
                    {
                        enlargedInput[j] = enlargedInput[j] + StringMethod.Multiply(input[j], multiplier); //Adds to the existing element additional copies of itself, controlled by multiplier value
                        limiter++;
                        j++;
                    }

                    i = j - 1; //Ensures that i is set to 1 away from the next tens. Ex. after processing enlargedInput[20] i becomes 19.
                }
            }

            return enlargedInput;
        }

        
    }

    //Class and method required to "multiply" strings
    //Reference: https://stackoverflow.com/questions/957938/multiplying-strings-in-c-sharp
    public static class StringMethod
    {
        public static string Multiply(this string source, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier * source.Length);
            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(source);
            }

            return sb.ToString();
        }
    }
}
