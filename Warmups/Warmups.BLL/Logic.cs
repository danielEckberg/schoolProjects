using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (isWeekend == true)
            {
                return true;
            }
            if (cigars >=40 && cigars <= 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            
            if (yourStyle <= 2 || dateStyle <=2)
            {
               return 0;
            }
            else if (yourStyle > 8|| dateStyle >8)
            {
                return 2;
            }
            else
            {
                return 1;
            }

        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (isSummer == true)
            {
                if (temp >= 60 && temp <= 95)
                {
                    return true;
                }
                return false;
            }
            else if (temp >= 60 && temp <= 90)
            {
                return true;
                
            }
            return false;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (isBirthday == true)
            {
                speed -= 5;
            }
            if (speed <= 60)
            {
                return 0;
            }
            if(speed >60 && speed <=80)
            {
                return 1;
            }
            else
            return 2;
        }
        
        public int SkipSum(int a, int b)
        {
            if (a + b >= 10 && a + b < 20)
            {
                return 20;
            }
            return a + b;
        }

        public string AlarmClock(int day, bool vacation)
        {

            if (vacation == true)
            {
                if (day == 0 || day == 6)
                {
                    return "off";
                }
                return "10:00";
            }
            else if (day == 0 || day == 6)
            {
                return "10:00";
            }
            return "7:00";
        }

        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6 || a + b == 6 || Math.Abs(a - b) == 6)
            {
                return true;
            }
            return false;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode == true)
            {
                if (n <= 1 || n >= 11)
                {
                    return true;
                }
                else
                    return false;
            }
            if (n >= 1 && n <= 10)
            {
                return true;
            }
            return false;
        }
        
        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0 || (n - 1) % 11 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool Mod20(int n)
        {
            if ((n - 2) % 20 == 0 || (n - 1) % 20 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool Mod35(int n)
        {
            if (n % 3 == 0 && n % 5 == 0)
            {
                return false;
            }
            if (n % 3 == 0 || n % 5 == 0) 
            {
                return true;
            }
            return false;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep == true)
            {
                return false;
            }
            if (isMorning == true)
            {
                if (isMom == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c || a + c == b || b + c == a)
            {
                return true;
            }
            return false;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (bOk == true)
            {
                if (c > a)
                {
                    return true;
                }
                return false;
            }
            else if (a < b && b < c)
            {
                return true;
            }
            return false;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (equalOk == true)
            {
                if (a <= b && b <= c)
                {
                    return true;
                }
                return false;
            }
            if (a < b && b < c)
            {
                return true;
            }
            return false;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            if (a % 10 == b % 10 || a % 10 == c % 10 || c % 10 == b % 10)
            {
                return true;
            }
            return false;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            if (noDoubles == true && die1 == die2)
            {
                if (die2 == 6)
                {
                    return die1 + 1;
                }
                return die1 + die2 + 1;
            }
            return die1 + die2;
        }

    }
}
