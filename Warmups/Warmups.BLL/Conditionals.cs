using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == bSmile)
            {
                return true;
            }
            return false;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (!isWeekday || isVacation)
            {
                return true;
            }
            return false;

        }

        public int SumDouble(int a, int b)
        {
            int sum = a + b;
            if (a==b)
            {
                sum *= 2;
            }
            return sum;
        }
        
        public int Diff21(int n)
        {
            if (n < 21)
            {
                return 21 - n;
            }
            return (n - 21) * 2;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking && hour < 7 || isTalking && hour > 20)
            {
                return true;
            }
            return false;
        }
        
        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10 || a + b == 10)
            {
                return true;
            }
            return false;
        }
        
        public bool NearHundred(int n)
        {
            if (Math.Abs(100-n) <= 10 || Math.Abs(200-n) <= 10)
            {
                return true;
            }
            return false;
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            if (a <0 || b < 0 && negative == false)
            {
                return true;
            }
            return false;
        }

        public string NotString(string s)
        {
            if (s.Length > 3)
            {
                if (s.Substring(0, 3) == "not")
                {
                    return s;
                }
                return "not " + s;
            }
            return "not " + s;

        }
        public string MissingChar(string str, int n)
        {
            return str.Remove(n,1);
        }
        
        public string FrontBack(string str)
        {
            if (str.Length > 1)
            {
                return str.Substring(str.Length - 1) + str.Substring(1, str.Length - 2) + str.Substring(0, 1);
            }
            return str;
        }
        
        public string Front3(string str)
        {
            if (str.Length > 3)
            {
                return str.Substring(0, 3)+ str.Substring(0, 3)+ str.Substring(0, 3);
            }
            return str + str + str;
        }
        
        public string BackAround(string str)
        {
            return str.Substring(str.Length - 1) + str + str.Substring(str.Length - 1);
        }
        
        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool StartHi(string str)
        {
            if (str.Length > 2)
            {
                if (str.Substring(0, 3) == "hi " || str.Substring(0, 3) == "hi,")
                {
                    return true;
                }
                return false;
            }
            else if (str == "hi")
            {
                return true;
            }
             return false;
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 > 100 && temp2 < 0 || temp1 <0 && temp2 >100)
            {
                return true;
                    }
            return false;
        }
        
        public bool Between10and20(int a, int b)
        {
            if ( a > 10 && a <20 || b >10 && b < 20)
            {
                return true;
            }
            return false;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            if (a >12 && a <20 || b > 12 && b < 20 || c > 12 && c < 20)
            {
                return true;
            }
            return false;
        }
        
        public bool SoAlone(int a, int b)
        {
            if (a > 12 && a < 20 && b > 12 && b < 20 || a > 20 && b < 12)
            {
                return false;
            }
            return true;
        }
        
        public string RemoveDel(string str)
        {
            if (str.Substring(1, 3) == "del")
            {
                return str.Remove(1, 3);
            }
            return str;
        }
        
        public bool IxStart(string str)
        {
            if(str.Substring(1,2) == "ix")
            {
                return true;
            }
            return false;
        }
        
        public string StartOz(string str)
        {
            if (str.Length > 1)
            {
                if (str.Substring(0, 2) == "oz")
                {
                    return str.Substring(0, 2);
                }
                else if (str.Substring(1, 1) == "z")
                {
                    return str.Substring(1, 1);
                }
                else if (str.Substring(0, 1) == "o")
                {
                    return str.Substring(0, 1);
                }
            }
                return "";
            
                
        }
        
        public int Max(int a, int b, int c)
        {
            return Math.Max(a,Math.Max(b,c));
        }
        
        public int Closer(int a, int b)
        {
            if (Math.Abs(10-a) < Math.Abs(10-b))
            {
                return a;
            }
            if (Math.Abs(10 - a) > Math.Abs(10 - b))
            {
                return b;
            }
            else return 0;
            
        }
        
        public bool GotE(string str)
        {
            int count = 0;
            int x = 0;
            while (true)
            {
                x = str.IndexOf("e", x);
                if (x == -1)
                    break;
                x++;
                count++;
            }
            if (count >= 1 && count <= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public string EndUp(string str)
        {
            if (str.Length < 3)
            {
                return str.ToUpper();
            }
            return str.Substring(0, str.Length - 3) + str.Substring(str.Length-3).ToUpper();
        }
        
        public string EveryNth(string str, int n)
        {
            string result;
            int x = 0;
            string[] nthWords = new string[str.Length];
            for (int i = 0; i < str.Length; i+=n)
            {
                nthWords[x++] = str.Substring(i, 1);
            }
            return result = string.Concat(nthWords);
        }
    }
}
