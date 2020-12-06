using System;
using System.IO;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load in file containing the data
            string workingDirectory = Environment.CurrentDirectory;
            string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @"input.txt");
            string[] input = File.ReadAllLines(path);

            //Convert array of strings to int List structure
            List<int> numbers = new List<int>();
            for (int i = 0; i < input.Length - 1; i++)
            {
                numbers.Add(Convert.ToInt32(input[i]));
            }

            //Sort numbers List using default Sort method
            numbers.Sort();

            //Print contents of List to console for testing
            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }

            //Declare left, right and third value index pointers
            int left = 0;
            int right = numbers.Count - 1;
            int thirdIndex;

            //Required sum
            int sum = 2020;


            //See if there's a pair of values in the list that add up to the desired sum
            if (FindPair(numbers, ref left, ref right, sum) == 1)
            {
                int pairProduct = numbers[left] * numbers[right];
                Console.WriteLine("{0} and {1} sum to equal {2} and when multiplied equal {3}", numbers[left], numbers[right], sum, pairProduct);
            }
            else
            {
                Console.WriteLine("No pairs of values exist in the list that add up to {0}", sum);
            }


            //See if there's a triplet of values in the list that add up to the desired sum
            if (FindTriplet(numbers, ref left, ref right, out thirdIndex, sum))
            {
                long tripletProduct = numbers[left] * numbers[right] * numbers[thirdIndex];
                Console.WriteLine("{0}, {1}, and {2} sum to {3} and when multplied have a product of {4}", numbers[left], numbers[right], numbers[thirdIndex], sum, tripletProduct);
            }
            else
            {
                Console.WriteLine("No triplets exist in the list that add up to {0}", sum);
            }

        }

        public static int FindPair(List<int> list, ref int left, ref int right, int sum)
        {
            //Continue until all values have been compared, if necessary.
            while (left < right)
            {
                if (list[left] + list[right] == sum)
                {
                    return 1;
                }
                else if (list[left] + list[right] < sum)
                {
                    left++;
                }

                else
                {
                    right--; //decrement right index when the pair is greater than the sum
                }
            }

            return 0;
        }

        public static bool FindTriplet(List<int> list, ref int left, ref int right, out int thirdIndex, int sum)
        {
            //Find triplet totalling 2020
            for (int i = 0; i < list.Count - 1; i++)
            {
                //Reinitialize pointer values
                left = i + 1; //start with second value in List
                right = list.Count - 1;

                //Continue until all values have been compared, if necessary.
                while (left < right)
                {
                    if (list[i] + list[left] + list[right] == sum)
                    {
                        thirdIndex = i;
                        return true;
                    }
                    else if (list[i] + list[left] + list[right] < sum)
                    {
                        left++;
                    }

                    else
                    {
                        right--; //decrement right index when the pair is greater than the sum
                    }
                }
            }

            thirdIndex = 0;
            return false;
        }
    }
}
