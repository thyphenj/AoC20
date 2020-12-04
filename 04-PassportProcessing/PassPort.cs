using System;
using System.Collections.Generic;

namespace _04_PassportProcessing
{
    public class PassPort
    {
        public string BYR { get; set; }
        public string IYR { get; set; }
        public string EYR { get; set; }
        public string HGT { get; set; }
        public string HCL { get; set; }
        public string ECL { get; set; }
        public string PID { get; set; }
        public string CID { get; set; }

        private bool IsCIDSet;
        private bool IsValid;
        private int SetCount;

        public PassPort()
        {
            SetCount = 0;
            IsCIDSet = false;
            IsValid = true;
        }

        public void AddField(string field)
        {
            SetCount++;
            string data = field.Split(':')[1];
            switch (field.Substring(0, 3))
            {
                case "byr":
                    BYR = data;
                    ValidateYear(data, 1920, 2002);
                    break;
                case "iyr":
                    IYR = data;
                    ValidateYear(data, 2010, 2020);
                    break;
                case "eyr":
                    EYR = data;
                    ValidateYear(data, 2020, 2030);
                    break;
                case "hgt":
                    HGT = data;
                    ValidateHeight(data);
                    break;
                case "hcl":
                    HCL = data;
                    ValidateHairColour(data);
                    break;
                case "ecl":
                    ECL = data;
                    ValidateEyeColour(data);
                    break;
                case "pid":
                    PID = data;
                    ValidatePassportId(data);
                    break;
                case "cid":
                    CID = data;
                    IsCIDSet = true;
                    break;
            }
        }
        public bool AreFieldsPresent()
        {
            return (SetCount == 8 || (SetCount == 7 && !IsCIDSet));
        }

        public bool AreFieldsValid()
        {
            return IsValid;
        }

        private void ValidateYear(string fld, int min, int max)
        {
            bool gotValue = int.TryParse(fld, out int value);
            if (!gotValue || value < min || value > max)
                IsValid = false;
        }

        private void ValidateHeight(string fld)
        {
            int len = fld.Length;
            if (len < 4)
                IsValid = false;
            else
            {
                bool gotValue = int.TryParse(fld.Substring(0, len - 2), out int value);
                if (!gotValue)
                    IsValid = false;
                {
                    string units = fld.Substring(len - 2);
                    if (units != "in" && units != "cm")
                        IsValid = false;
                    else if (units == "in" && (value < 59 || value > 76))
                        IsValid = false;
                    else if (fld.Substring(len - 2) == "cm" && (value < 150 || value > 193))
                        IsValid = false;
                }
            }
        }
        private void ValidateHairColour(string fld)
        {
            if (fld.Length != 7)
                IsValid = false;
            else if (fld[0] != '#')
                IsValid = false;
            else
            {
                foreach (char ch in fld.Substring(1))
                    if ((ch < '0' || ch > '9') && (ch < 'a' || ch > 'f'))
                    {
                        IsValid = false;
                        return;
                    }
            }
        }
        private void ValidateEyeColour(string fld)
        {
            if (fld.Length != 3)
                IsValid = false;
            else
            {
                List<string> validEyeColours = new List<string>();

                validEyeColours.Add("amb");
                validEyeColours.Add("blu");
                validEyeColours.Add("brn");
                validEyeColours.Add("gry");
                validEyeColours.Add("grn");
                validEyeColours.Add("hzl");
                validEyeColours.Add("oth");

                if (!validEyeColours.Contains(fld))
                    IsValid = false;
            }
        }
        private void ValidatePassportId(string fld)
        {
            if (fld.Length != 9)
                IsValid = false;
            else
            {
                foreach (var ch in fld)

                    if (ch < '0' || ch > '9')
                    {
                        IsValid = false;
                        return;
                    }
            }
        }
    }
}

