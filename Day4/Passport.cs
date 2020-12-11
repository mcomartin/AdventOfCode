using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    public class Passport
    {
        //Class properties
        private int byr, iyr, eyr;
        private string hgt, hcl, ecl, pid, cid;

        //Getters and setters
        public int Byr
        {
            get
            {
                return byr;
            }

            set
            {
                this.byr = value;
            }
        }
        public int Iyr
        {
            get
            {
                return iyr;
            }

            set
            {
                this.iyr = value;
            }
        }
        public int Eyr
        {
            get
            {
                return eyr;
            }

            set
            {
                this.eyr = value;
            }
        }
        
        public string Hgt
        {
            get
            {
                return hgt;
            }

            set
            {
                this.hgt = value;
            }
        }
        public string Hcl
        {
            get
            {
                return hcl;
            }

            set
            {
                this.hcl = value;
            }
        }
        public string Ecl
        {
            get
            {
                return ecl;
            }

            set
            {
                this.ecl = value;
            }
        }
        public string Pid
        {
            get
            {
                return pid;
            }

            set
            {
                this.pid = value;
            }
        }
        public string Cid
        {
            get
            {
                return cid;
            }

            set
            {
                this.cid = value;
            }
        }

        //No arg constructor
        public Passport(string data)
        {
            Regex findBYR = new Regex(@"(?<=byr:)\d*"); //returns number after byr: in string
            Regex findIYR = new Regex(@"(?<=iyr:)\d*"); //returns number after iyr: in string
            Regex findEYR = new Regex(@"(?<=eyr:)\d*"); //returns number after eyr: in string
            Regex findHGT = new Regex(@"(?<=hgt:)\w*"); //returns number after hgt: in string
            Regex findHCL = new Regex(@"(?<=hcl:)\W?\w*"); //returns number after hcl: in string
            Regex findECL = new Regex(@"(?<=ecl:)\W?\w*"); //returns number after ecl: in string
            Regex findPID = new Regex(@"(?<=pid:)\w*"); //returns number after pid: in string
            Regex findCID = new Regex(@"(?<=cid:)\d*"); //returns number after cid: in string

            //Checks for the presence of required passport properties
            if (data.Contains("byr") && data.Contains("iyr") && data.Contains("eyr") && data.Contains("hgt") && data.Contains("hcl") && 
                data.Contains("ecl") && data.Contains("pid"))
            {
                //Adds properties to object
                Byr = int.Parse(findBYR.Match(data).Value);
                Iyr = int.Parse(findIYR.Match(data).Value);
                Eyr = int.Parse(findEYR.Match(data).Value);
                Hgt = findHGT.Match(data).Value;
                Hcl = findHCL.Match(data).Value;
                Ecl = findECL.Match(data).Value;
                Pid = findPID.Match(data).Value;

                //Check to see if Cid is present and assign it, if applicable
                if (data.Contains("cid"))
                {
                    Cid = findCID.Match(data).Value;
                }
            }

            
        }

        //ToString override method
        public override string ToString()
        {
            return "Passport Details: " + "\n" + "Pid: " + Pid + "\n" + "Cid: " + Cid + "\n" + "Byr: " + Byr + "\n" + "Iyr: " + Iyr + "\n" + "Eyr: "
                + Eyr + "\n" + "Hgt: " + Hgt + "\n" + "Hcl: " + Hcl + "\n" + "Ecl: " + Ecl;
        }

    }
}
