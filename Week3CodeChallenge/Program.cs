using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3CodeChallenge
{
    class Program
    {
        static bool isEven(int num)
        {
            bool returnHolder = false;
            if (num % 2 == 0)
            {
                returnHolder = true;
            }
            return returnHolder;
        }
        static bool isPrime(int number)
        {
            bool returnHolder = true;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) { returnHolder = false; }
            }
            return returnHolder;
        }

        static int FindManyPrimes(int thisMany)
        {
            int returnHolder = 0;
            int count = 0;
            for (int i = 2; count < thisMany; i++)
            {
                if (isPrime(i))
                {
                    count++;
                    returnHolder = i;
                }
            }
            return returnHolder;
        }
        static void EvenFibonacciSequencer(int maxValue)
        {
            int preFib = 1;
            int nowFib = 2;
            int nextFib = 0;
            int evenTotals = 0;
            while (nextFib < maxValue)
            {
                nextFib = preFib + nowFib;
                if (isEven(nowFib))
                {
                    evenTotals += nowFib;
                }
                preFib = nowFib;
                nowFib = nextFib;
            }
            Console.WriteLine(evenTotals);
        }
        static void LongestCollatzSequence()
        {
            int longestChainStartValue=0;//stores the starting value of the longest chain
            int longestChainLength=0;//stores the number of terms in the longest value
            for (int i = 1; i < 1000000; i++)
            {
                int curentChainStartValue = i;//
                int curentChainLength = 1;
                double x = i;
                while (x != 1)
                {

                    if (x < 0)
                    {
                        Console.WriteLine("Start Value" + curentChainStartValue + " caused negatives");
                    }
                    if (x%2==0)
                    {
                        x = x / 2;
                        curentChainLength++; 
                    }
                    else
                    {
                        x = x * 3 + 1;
                        curentChainLength++;
                    }
                }
                //Console.WriteLine("New number" + i);
                if (curentChainLength > longestChainLength)
                {
                    Console.WriteLine("Chain switched" +i);
                    longestChainStartValue = curentChainStartValue;
                    longestChainLength = curentChainLength;
                }
            }
            Console.WriteLine("the longest Chain is "+longestChainLength+" terms long. Its starting value is "+longestChainStartValue);
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(FindManyPrimes(10001));
            //EvenFibonacciSequencer(2000000);
            LongestCollatzSequence();
            Console.ReadKey();
        }
    }
}
