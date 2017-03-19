using System;
using System.Net.NetworkInformation;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length- 1] == 6)
            {
                return true;
            }
            return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length > 1 && numbers[0] == numbers[numbers.Length - 1])
            {
                return true;
            }
            return false;
        }
        public int[] MakePi(int n)
        {
            double pi = Math.PI;
            int[] newPie = new int[n];
            for (int i = 0; i < n; i++)
            {
                newPie[i] = (int)Math.Floor(pi);
                pi -= newPie[i];
                pi *= 10;
            }
            return newPie;
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            if (b[0] == a[0] || a[a.Length - 1] == b[b.Length - 1])
            {
                return true;
            }
            return false;
        }
        
        public int Sum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] result = new int[numbers.Length];
            result[result.Length - 1] = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result[(i - 1)] = numbers[i];

            }
            return result;
        }
        
        public int[] Reverse(int[] numbers)
        {
            Array.Reverse(numbers);
            return numbers;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int max = 0;
            if (numbers[0] > numbers[numbers.Length - 1])
            {
                max = numbers[0];
            }
            if (numbers[0] < numbers[numbers.Length - 1])
            {
                max = numbers[numbers.Length - 1];
            }
        
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = max;
            }
            return numbers;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] middles = {a[1], b[1]};
            return middles;
        }
        
        public bool HasEven(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    return true;
                }
                
            }
            return false;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int[] last = new int[(numbers.Length*2)];
            last[last.Length - 1] = numbers[numbers.Length - 1];
            return last;
        }
        
        public bool Double23(int[] numbers)
        {
            int two = 0;
            int three = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                {
                    two++;
                }
                if (numbers[i] == 3)
                {
                    three++;
                }
            }
            if (two == 2 || three == 2)
            {
                return true;
            }
            return false;
        }
        
        public int[] Fix23(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 2 && numbers[(i + 1)] == 3)
                {
                    numbers[(i + 1)] = 0;
                }
            }
            return numbers;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            if(numbers[0] == 1 && numbers[1] == 3|| numbers[1] == 1 && numbers[2] == 3|| numbers[numbers.Length - 2] == 1 && numbers[numbers.Length - 1] == 3)
            {
                return true;
            }
            return false;
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] combine = new int[2];
            if (a.Length >= 2)
            {
                combine[0] = a[0];
                combine[1] = a[1];
            }
            else if (a.Length == 1)
            {
                combine[0] = a[0];
                combine[1] = b[0];
            }
            else
            {
                combine[0] = b[0];
                combine[1] = b[1];
            }
            return combine;
        }

    }
}
