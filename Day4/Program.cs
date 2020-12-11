using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load in file containing the data
            string workingDirectory = Environment.CurrentDirectory;
            string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @"input.txt");
            string input = File.ReadAllText(path);

            string[] rawPassports = input.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            //Create a dictionary to contain key/value pairs of passport data
            //Dictionary<string, List<Passport>> validPassports = new Dictionary<string, List<Passport>>();
            //Create a List to contain valid passports
            List<Passport> validPassports = new List<Passport>();

            foreach (string passport in rawPassports)
            {
                Passport temp = new Passport(passport);

                //Check that temp object created isn't null
                if (temp.Pid != null)
                {
                    validPassports.Add(temp);
                }
            }

            //Summary
            Console.WriteLine("The total number of valid passports is: {0}", validPassports.Count());


            
            
        }
    }
}
