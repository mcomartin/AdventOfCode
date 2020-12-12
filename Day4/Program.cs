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

            //Create a List of passports
            List<Passport> passports = new List<Passport>();

            foreach (string passport in rawPassports)
            {
                Passport temp = new Passport(passport);

                //Check that temp object created isn't null
                if (temp.Pid != null)
                {
                    passports.Add(temp);
                }
            }


            //PART 2 DATA VALIDATION
            //Create List of Valid Passports
            List<Passport> validPassports = new List<Passport>();
            char[] validNumbersLetters = "0123456789abcdef".ToCharArray(); //valid chars used in Hair Color
            string[] validEyeColours = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }; //Valid eye colours
            char[] validPidNumbers = "0123456789".ToCharArray(); //valid numbers to used in PID

            foreach (Passport passport in passports)
            {
                bool cmValid = false, inchesValid = false, hclValid = false, eclValid = false, pidValid = false;
                //Birth, passport issue and expiry years
                if ((passport.Byr >= 1920 && passport.Byr <= 2002) && (passport.Iyr >= 2010 && passport.Iyr <= 2020) && (passport.Eyr >= 2020 && passport.Eyr <= 2030))
                {
                    //Height
                    if (passport.Hgt.Contains("cm"))
                    {
                        string[] temp = passport.Hgt.Split("cm");
                        if (Convert.ToInt32(temp[0]) >= 150 && Convert.ToInt32(temp[0]) <= 193)
                        {
                            cmValid = true;
                        }
                    }

                    else if (passport.Hgt.Contains("in"))
                    {
                        string[] temp = passport.Hgt.Split("in");
                        if (Convert.ToInt32(temp[0]) >= 59 && Convert.ToInt32(temp[0]) <= 76)
                        {
                            inchesValid = true;
                        }
                    }

                    //Hair Colour
                    int hclCharCount = 0;
                    for (int i = 1; i < passport.Hcl.Length; i++)
                    {
                        if (validNumbersLetters.Contains(passport.Hcl[i]))
                        {
                            hclCharCount++;
                        }
                    }

                    if (passport.Hcl[0] == '#' && hclCharCount == 6)
                    {
                        hclValid = true;
                    }

                    //Eye colour
                    if (validEyeColours.Contains(passport.Ecl))
                    {
                        eclValid = true;
                    }

                    //Passport ID
                    if (passport.Pid.ToCharArray().Length == 9)
                    {
                        int validNumberCount = 0;
                        foreach (char number in passport.Pid)
                        {
                            if (validPidNumbers.Contains(number))
                            {
                                validNumberCount++;
                            }
                        }

                        if (validNumberCount == 9)
                        {
                            pidValid = true;
                        }

                    }

                    //Final test to see if passport is valid. If so, add object to valid passport list
                    if ((cmValid || inchesValid) && hclValid && eclValid && pidValid)
                    {
                        validPassports.Add(passport);
                    }


                }
            }

            //Summary
            Console.WriteLine("The total number of passports is: {0}", passports.Count());
            Console.WriteLine("The total number of valid passports is {0}", validPassports.Count());
        }
    }
}
