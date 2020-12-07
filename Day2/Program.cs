using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int validPasswordCount; //gets initialized by PasswordValidator method once its run

            //Load in file containing the data
            string workingDirectory = Environment.CurrentDirectory;
            string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @"input.txt");
            string[] input = File.ReadAllLines(path);

            //Convert array of strings to List
            List<string> passwords = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                passwords.Add(input[i]);
            }

            PasswordValidator(passwords, out validPasswordCount);

            if (validPasswordCount.CompareTo(null) != 0)
            {
                Console.WriteLine("The number of valid passwords are {0}", validPasswordCount);
            }
        }

        public static void PasswordValidator(List<string> passwords, out int validPasswordCount)
        {
            List<string> validPasswords = new List<string>(); //empty list that will contain valid passwords


            Regex minRange = new Regex(@"\d+"); //first number of letter range
            Regex maxRange = new Regex(@"(?<=\-)(\d+)"); //finds the second number to the right of the "-" symbol
            Regex passwordLetter = new Regex(@"[a-z]"); //returns first character in string
            Regex password = new Regex(@"[^:\s]+$"); //returns everything to the right of the colon, excluding the space

            foreach (string item in passwords)
            {
                if (minRange.IsMatch(item) && maxRange.IsMatch(item) && passwordLetter.IsMatch(item) && password.IsMatch(item))
                {
                    int min = int.Parse(minRange.Match(item).Value);
                    int max = int.Parse(maxRange.Match(item).Value);
                    string letter = passwordLetter.Match(item).Value;
                    string pass = password.Match(item).Value;
                    //Console.WriteLine("There's a match! The result is {0}", min);
                    //Console.WriteLine("There's a match! The result is {0}", max);


                    int letterCount = 0; //counter to store number of times letter is seen in pass variable

                    for (int i = 0; i < pass.Length; i++)
                    {
                        //Compare each letter in the sequence to see if they are equal. If so, add 1 to the counter.
                        if (pass[i].Equals(Convert.ToChar(letter)))
                        {
                            letterCount++;
                        }
                    }

                    //Add password to valid list only if the letter count is between the min and max values (inclusive)
                    if (letterCount >= min && letterCount <= max)
                    {
                        validPasswords.Add(item);
                    }


                    //POLICY CHANGE APPROACH. COMMENT OUT ABOVE FOR LOOP AND IF STATEMENT

                    //Since zero index is not used, the min and max values were each subtracted by 1, respectively. Prevents IndexOutOfRangeException at upper end.
                    //if (pass[min - 1].Equals(Convert.ToChar(letter)) ^ pass[max - 1].Equals(Convert.ToChar(letter)))
                    //{
                    //    validPasswords.Add(item);
                    //}

                    //POLICY CHANGE APPROACH COMPLETED
                }
            }

            //Pass the number of valid passwords in the list to the out parameter
            validPasswordCount = validPasswords.Count;

        }
    }
}
