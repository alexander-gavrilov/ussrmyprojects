using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Helpers
{
    public class ValidationHelper
    {
        //private ErrorProvider errorProvider;

        //public ValidationHelper()
        //{
        //    errorProvider = new ErrorProvider();
        //}

        public Boolean IsInt32(String value)
        {
            Int32 result;
            return Int32.TryParse(value, out result);
        }

        public Boolean IsDecimal(String value)
        {
            Decimal result;
            return Decimal.TryParse(value, out result);
        }

        public Boolean IsDate(String value)
        {
            DateTime date;

            return DateTime.TryParse(value, out date) && value.Length == 10;
        }

        public Boolean ValidateControlTextLength(Form form, String controlType, List<String> unvalidateControlNameList)
        {
            Boolean result = false;

            if (form != null)
                foreach (Control control in form.Controls)
                {
                    if (control.GetType().ToString() == controlType)
                    {
                        if (unvalidateControlNameList != null)
                        {
                            foreach (String unvalidateControlName in unvalidateControlNameList)
                            {
                                if (control.Name != unvalidateControlName)
                                {
                                    result = control.Text.Trim().Length.Equals(0);
                                }
                            }
                        }
                        else
                        {
                            result = control.Text.Trim().Length.Equals(0);
                        }
                    }
                }
            return result;
        }

        public Boolean ValidateControlTextLength(Form form, String controlType, List<String> unvalidateControlNameList, Int32 textLength)
        {
            Boolean result = false;

            foreach (Control control in form.Controls)
            {
                if (control.GetType().ToString() == controlType)
                {
                    if (unvalidateControlNameList != null)
                    {
                        foreach (String unvalidateControlName in unvalidateControlNameList)
                        {
                            if (control.Name != unvalidateControlName)
                            {
                                result = ValidateTxtLength(control.Text.Trim(), textLength);
                            }
                        }
                    }
                    else
                    {
                        result = ValidateTxtLength(control.Text.Trim(), textLength);
                    }
                }
            }
            return result;
        }

        public Boolean ValidateTxtLength(String text)
        {
            Boolean result = false;

            if (!text.Trim().Length.Equals(0))
            {
                result = true;
            }

            return result;
        }

        public Boolean ValidateTxtLength(String text, Int32 textLength)
        {
            Boolean result = false;

            if (!text.Trim().Length.Equals(0) && text.Trim().Length.Equals(textLength))
            {
                result = true;
            }

            return result;
        }

        public Boolean ValidatePersonalNumber(String personalNumber)
        {
            Boolean result = false;
            Dictionary<String, String> validSymbolDictionary = new Dictionary<String, String>
                                                                   {
                                                                       {"#1ValidSymbol", "0,1,2,3,4,5,6,7,8,9"},
                                                                       {"#8ValidSymbol", "A,B,C,K,E,M,H"},
                                                                       {"#12#13ValidSymbol", "GB,PB,BA,BI,VF,VA"}
                                                                   };
            const Int32 personalNamberLength = 14;
            //personalNumber = personalNumber.ToUpper();

            if (personalNumber != null)
                if (ValidateTxtLength(personalNumber, personalNamberLength))
                {
                    foreach(String symbol in validSymbolDictionary["#1ValidSymbol"].Split(','))
                    {
                        if (personalNumber.Substring(0, 1) == symbol)
                        {
                            result = true;
                            break;
                        }
                    }

                    if (result)
                    {
                        foreach (String symbol in validSymbolDictionary["#8ValidSymbol"].Split(','))
                        {
                            if (personalNumber.Substring(7, 1) == symbol)
                            {
                                result = true;
                                break;
                            }
                            result = false;
                        }
                    }

                    if (result)
                    {
                        foreach (String symbol in validSymbolDictionary["#12#13ValidSymbol"].Split(','))
                        {
                            if (personalNumber.Substring(11, 2) == symbol)
                            {
                                result = true;
                                break;
                            } 
                            result = false;
                        }
                    }
                    if (!result) return false;
                }
                else
                {
                    return false;
                }
            return result;
        }

        public Boolean ValidatePasportSerial (String serial)
        {
            Boolean result = false;
            
            if (serial.Length == 9)
            {
                String literalPart = serial.Substring(0, 2);
                String numericPart = serial.Substring(2, 7);

                foreach (char s in literalPart)
                {
                    Int32 number;
                    if (!Int32.TryParse(s.ToString(), out number))
                    {
                        result = true;
                    }
                    else return false;
                }

                if(result)
                {
                    foreach (char s in numericPart)
                    {
                        Int32 number;
                        if (!Int32.TryParse(s.ToString(), out number))
                        {
                            return false;
                        }
                    }
                }
            }

            return result;
        }
        
        public Boolean IsLicSchet(String ls)
        {
            Boolean result = false;
            const String key = "7133713713713713";
            List<Int32> keyList = new List<Int32>();
            List<Int32> lsList = new List<Int32>();
            List<Int32> resultList = new List<Int32>();
            Int32 resultMulty = 0;
            Int32 multy;

            if (ls.Length != 16) return false;

            foreach(Char s in key)
            {
                keyList.Add(Convert.ToInt32(s.ToString()));
            }

            foreach (Char s in ls)
            {
                if(s != ' ') lsList.Add(Convert.ToInt32(s.ToString()));
            }

            for (Int32 i = 0; i < keyList.Count; i++ )
            {
                multy = lsList[i] * keyList[i];
                resultList.Add(Convert.ToInt32(multy.ToString().Substring(multy.ToString().Length - 1)));
            }

            foreach (Int32 item in resultList)
            {
                resultMulty += item;
            }

            if (resultMulty.ToString().EndsWith("0")) result = true;
            
            return result;
        }

        public Boolean IsUNP(String unp)
        {
            Boolean result = false;
            Int64 unpValue;

            if ((unp != null)&&(unp.Length == 9))
            {
                if(Int64.TryParse(unp, out unpValue))
                {
                    Int32 unp1 = Convert.ToInt32(unpValue.ToString().Substring(0, 1));
                    Int32 unp2 = Convert.ToInt32(unpValue.ToString().Substring(1, 1));
                    Int32 unp3 = Convert.ToInt32(unpValue.ToString().Substring(2, 1));
                    Int32 unp4 = Convert.ToInt32(unpValue.ToString().Substring(3, 1));
                    Int32 unp5 = Convert.ToInt32(unpValue.ToString().Substring(4, 1));
                    Int32 unp6 = Convert.ToInt32(unpValue.ToString().Substring(5, 1));
                    Int32 unp7 = Convert.ToInt32(unpValue.ToString().Substring(6, 1));
                    Int32 unp8 = Convert.ToInt32(unpValue.ToString().Substring(7, 1));
                    Int32 unp9 = Convert.ToInt32(unpValue.ToString().Substring(8, 1));
                    Int32 sumMult = unp1*29 + unp2*23 + unp3*19 + unp4*17 + unp5*13 + unp6*7 + unp7*5 + unp8*3;
                    Int32 remainder = sumMult%11;

                    if (unp9 == remainder) result = true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return result;   
        }

        public Boolean IsEmail(String email)
        {
            Boolean result = false;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(email))
                result = true;
            return result;
        }

        public Boolean IsPhoneNumber(String phoneNumber)
        {
            Boolean result = false;
            phoneNumber = phoneNumber.Trim();
            List<String> validSymbols = new List<String>{"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-", ",", "(", ")", "+", " "};

            if (phoneNumber.Length > 4)
            {
                validSymbols.ForEach(delegate(String validSymbol)
                                         {
                                             foreach (char s in phoneNumber)
                                             {
                                                 Int32 number;
                                                 result = Int32.TryParse(validSymbol.IndexOf(s).ToString(), out number) && validSymbol.IndexOf(s).GetType() == typeof(int);
                                             }
                                         }
                                     );
            }

            return result;
        }

        public Boolean IsOnlyLiteral(String fio)
        {
            Boolean result = false;

            if (fio.Length > 0)
            {
                foreach(char s in fio)
                {
                    Int32 number;
                    if (!Int32.TryParse(s.ToString(), out number))
                    {
                        result = true;
                    }
                    else return false;
                }
            }

            return result;
        }

        public Boolean IsOnlyNumeric(String numeric)
        {
            Boolean result = false;

            if (numeric.Length > 0)
            {
                foreach (char s in numeric)
                {
                    Int32 number;
                    if (Int32.TryParse(s.ToString(), out number))
                    {
                        result = true;
                    }
                    else return false;
                }
            }

            return result;
        }

   }
}
