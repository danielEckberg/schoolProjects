using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string result;
            string[] Words = new string[n];
            for (int i = 0; i < n; i++)
            {
                Words[i] = str;
            }
            return result = string.Concat(Words);

        }

        public string FrontTimes(string str, int n)
        {
            string result;
            string[] Words = new string[n];
            if (str.Length <= 3)
            {
                for (int i = 0; i < n; i++)
                {
                    Words[i] = str;
                }
                return result = string.Concat(Words);
            }
            for (int i = 0; i < n; i++)
            {
                Words[i] = str.Remove(3);
            }
            return result = string.Concat(Words);
        }

        public int CountXX(string str)
        {
            int count = 0;
            string current;
            
            for (int i = 0; i < str.Length-1; i++)
            {
                current =str.Substring(i,2);
                
                if (current == "xx" )
                {
                    count++;
                }
            }
            return count;
        }

        public bool DoubleX(string str)
        {
            string current;

            for (int i = 0; i < str.Length - 1; i++)
            {
                current = str.Substring(i, 1);

                if (current == "x")
                {
                    current = str.Substring(i + 1, 1);
                    if (current == "x")
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public string EveryOther(string str)
        {
            string result;
            int x = 0;
            string[] nthWords = new string[str.Length];
            for (int i = 0; i < str.Length; i += 2)
            {
                nthWords[x++] = str.Substring(i, 1);
            }
            return result = string.Concat(nthWords);
        }

        public string StringSplosion(string str)
        {
            string result;
            string[] Words = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                Words[i] = str.Substring(0,i+1);
            }
            return result = string.Concat(Words);
        }

        public int CountLast2(string str)
        {
            int count = -1;
            string current;

            for (int i = 0; i < str.Length - 1; i++)
            {
                current = str.Substring(i, 2);

                if (current == str.Substring(str.Length-2))
                {
                    count++;
                }
            }
            return count;
        }

        public int Count9(int[] numbers)
        {
            int count = 0;
            
            for (int i = 0; i < numbers.Length; i++)
            {
               if (numbers[i]==9)
                {
                    count++;
                }
            }
            return count;
        }

        public bool ArrayFront9(int[] numbers)
        {
            if (numbers[0] == 9 || numbers[1] == 9 || numbers[2] == 9 || numbers[3] == 9)
            {
                return true;
            }
            return false;
        }

        public bool Array123(int[] numbers)
        {
            int current;
            int next;
            int third;

            if (numbers.Length >= 3)
            {
                for (int i = 0; i < numbers.Length - 2; i++)
                {
                    current = numbers[i];
                    next = numbers[i + 1];
                    third = numbers[i + 2];

                    if (current == 1 && next == 2 && third == 3)
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int count = 0;
            string currenta;
            string currentb;

            if (a.Length <= b.Length)
            {
                for (int i = 0; i < a.Length - 1; i++)
                {
                    currenta = a.Substring(i, 2);
                    currentb = b.Substring(i, 2);
                    if (currenta == currentb)
                    {
                        count++;
                    }
                }
                return count;
            }
            else 
            {
                for (int i = 0; i < b.Length - 1; i++)
                {
                    currenta = a.Substring(i, 2);
                    currentb = b.Substring(i, 2);
                    if (currenta == currentb)
                    {
                        count++;
                    }
                }
                return count;
            }

        }

        public string StringX(string str)
        {
            string result;
            string[] x = new string[str.Length];
            if (str.Substring(0,1) == "x" && str.Substring(str.Length -1) == "x")
            {
                x[0] = "x";
                x[x.Length - 1] = "x";
                for (int i = 1; i < str.Length-1; i++)
                {
                    if (str.Substring(i,1) != "x")
                    {
                        x[i] = str.Substring(i, 1);
                    }
                         
                }
                return result = string.Concat(x);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str.Substring(i, 1) != "x")
                    {
                        x[i] = str.Substring(i, 1);
                    }

                }
                return result = string.Concat(x);
            }
        }

        public string AltPairs(string str)
        {
            string result;
            string[] temp = new string[str.Length];
            for (int i = 0; i < str.Length ; i+=4)
            {
                temp[i] = str.Substring(i, 1);
                if (i < str.Length-1)
                {
                    temp[i + 1] = str.Substring(i + 1, 1);
                }
            }
            return result = string.Concat(temp);
        }

        public string DoNotYak(string str)
        {
            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str.Substring(i, 3) == "yak")
                {
                    return str.Remove(i, 3);
                }

            }
            return str;
        }

        public int Array667(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] == 6 && numbers[i + 1] == 6 || numbers[i] == 6 && numbers[i + 1] == 7)
                {
                    count++;
                }
            }
            return count;
        }

        public bool NoTriples(int[] numbers)
        {
            int first;
            int second;
            int third;

            for (int i = 0; i < numbers.Length-2; i++)
            {
                first = numbers[i];
                second = numbers[i + 1];
                third = numbers[i + 2];
                if (first == second && second == third)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            int first;
            int second;
            int third;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                first = numbers[i];
                second = numbers[i + 1];
                third = numbers[i + 2];
                if (first+5 == second && second-6 == third)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
