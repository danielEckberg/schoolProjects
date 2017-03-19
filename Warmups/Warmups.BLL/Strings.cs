using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
            return "<" + tag + ">" + content + "</" + tag + ">";
        }

        public string InsertWord(string container, string word)
        {
            return container.Substring(0, 2) + word + container.Substring(container.Length - 2);
        }

        public string MultipleEndings(string str)
        {
            return str.Substring(str.Length - 2) + str.Substring(str.Length - 2) + str.Substring(str.Length - 2);
        }

        public string FirstHalf(string str)
        {
            return str.Substring(0, str.Length / 2);
        }

        public string TrimOne(string str)
        {
            return str.Substring(1, str.Length - 2);
        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return b + a + b;
            }
            return a + b + a;
        }

        public string RotateLeft2(string str)
        {
            return str.Substring(2) + str.Substring(0, 2);
        }

        public string RotateRight2(string str)
        {
            if (str.Length > 2)
            {
                return str.Substring(str.Length - 2, 2) + str.Substring(0, (str.Length) - 2);
            }
            return str;
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront == true)
            {
                return str.Substring(0, 1);
            }
            return str.Substring(str.Length - 1);
        }

        public string MiddleTwo(string str)
        {
            return str.Substring((str.Length) / 2 - 1, 2);
        }

        public bool EndsWithLy(string str)
        {
            if (str.Length > 1)
            {
                if (str.Substring(str.Length - 2) == "ly")
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public string FrontAndBack(string str, int n)
        {
            return str.Substring(0, n) + str.Substring(str.Length - n);
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (str.Substring(n,1) == str.Substring(str.Length-1))
            {
                return str.Substring(0, 2);
            }

            return str.Substring(n, 2);
        }

        public bool HasBad(string str)
        {
            if (str.Length >= 3)
            {
                if (str.Substring(0, 3) == "bad" || str.Substring(1, 3) == "bad")
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public string AtFirst(string str)
        {
            if (str.Length < 1)
            {
                return "@@";
            }
            if (str.Length < 2)
            {
                return str + "@";
            }
            return str.Substring(0, 2);
        }

        public string LastChars(string a, string b)
        {
            if (a.Length < 1 || b.Length < 1)
            {
                if (a.Length < 1 && b.Length < 1)
                {
                    return "@@";
                }
                if (a.Length < 1)
                {
                    return "@" + b.Substring(b.Length - 1);
                }
                if (b.Length < 1)
                {
                    return a.Substring(0, 1) + "@";
                }
            }
            return a.Substring(0, 1) + b.Substring(b.Length - 1);
        }

        public string ConCat(string a, string b)
        {
            string c;
            if (a == "" || b == "")
            {
                return c = string.Concat(a, b);
            }
            if (a.Substring(a.Length - 1) == b.Substring(0, 1))
            {
                return c = string.Concat(a, b.Substring(1));
            }

            return c = string.Concat(a, b);
        }

        public string SwapLast(string str)
        {

            if (str.Length > 2)
            {
                return str.Substring(0, str.Length - 2) + str.Substring(str.Length - 1) +
                       str.Substring(str.Length - 2, 1);
            }
            if (str.Length > 1)
            {
                return str.Substring(str.Length - 1) + str.Substring(str.Length - 2, 1);
            }
            return str;
        }

        public bool FrontAgain(string str)
        {
            if (str.Substring(0, 2) == str.Substring(str.Length - 2))
            {
                return true;
            }
            return false;
        }

        public string MinCat(string a, string b)
        {
            if (a.Length >= b.Length)
            {
                return a.Substring(a.Length - b.Length) + b;
            }
            return a + b.Substring(b.Length - a.Length);
        }

        public string TweakFront(string str)
        {

            if (str.Length > 1)
            {
                if (str.Substring(0, 1) == "a" || str.Substring(1, 1) == "b")
                {
                    if (str.Substring(0, 1) == "a" && str.Substring(1, 1) == "b")
                    {
                        return str;
                    }
                    if (str.Substring(0, 1) == "a")
                    {
                        return str.Substring(0, 1) + str.Substring(2);
                    }
                    if (str.Substring(1, 1) == "b")
                    {
                        return str.Substring(1);
                    }
                }
                return str.Substring(2);
            }
            return str;
        }

        public string StripX(string str)
        {

            if (str == "")
            {
                return str;
            }
            if (str.Substring(0, 1) == "x" || str.Substring(str.Length - 1) == "x")
            {
                if (str == "x")
                {
                    return "";
                }
                if (str.Substring(0, 1) == "x" && str.Substring(str.Length - 1) == "x")
                {
                    return str.Substring(1, str.Length - 2);
                }
                if (str.Substring(0, 1) == "x")
                {
                    return str.Substring(1);
                }
                if (str.Substring(str.Length - 1) == "x")
                {
                    return str.Substring(0, str.Length - 1);
                }
            
            }
            return str;
        }
    }
}
