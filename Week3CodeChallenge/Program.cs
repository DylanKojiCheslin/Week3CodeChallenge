using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3CodeChallenge
{
    class Program
    {
        /// <summary>
        /// returns a bool, true if tested int is even false if odd
        /// </summary>
        /// <param name="num">int to be tested</param>
        /// <returns>bool true if even, flase if odd</returns>
        static bool isEven(int num)
        {
            bool returnHolder = false;
            if (num % 2 == 0)
            {
                returnHolder = true;
            }
            return returnHolder;
        }
        /// <summary>
        /// returns a bool true if tested int is prime
        /// </summary>
        /// <param name="number">int to be tested</param>
        /// <returns>bool true if prime false if composite</returns>
        static bool isPrime(int number)
        {
            bool returnHolder = true;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (isEven(number)) { returnHolder = false; }
            }
            return returnHolder;
        }
        /// <summary>
        /// finds prime numbers until it has found the amount of the parameter, writing the final prime to the console
        /// </summary>
        /// <param name="thisMany">int how many prime number you want to find</param>
        /// <returns>int the last prime number found</returns>
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
        /// <summary>
        /// totals the value of all even  fibonacci numbers up to the parameter and writes the total to the value
        /// </summary>
        /// <param name="maxValue">int maximum value to tested</param>
        static void EvenFibonacciSequencer(int maxValue)
        {
            //each number in the fibonacci sequence is the total of the previous 2 numbers in the sequence
            int preFib = 1;//fibonacci sequences always start at one
            int nowFib = 2;
            int nextFib = 0;
            int evenTotals = 0;//holds the total of the even fibonacci numbers
            while (nextFib < maxValue)//test if the next fibonacci number is smaller than the max value 
            {
                nextFib = preFib + nowFib;//totals the previous 2 numbers to create the next fibonacci number
                if (isEven(nowFib))
                {
                    evenTotals += nowFib;//adds the current number to the total 
                }
                preFib = nowFib;//asigns the current number to the previous number
                nowFib = nextFib;//asigns the next number to the current number
            }
            Console.WriteLine(evenTotals);
        }
        /// <summary>
        ///finds the starting number that has the longest chain in a collatz problem under one million
        ///and print the length of the chain and its starting value to the console
        /// </summary>
        static void LongestCollatzSequence()
        {
            // in a collatz problem if a number is even it is divided by 2 if it is odd the number is multiplied by 3 and has one added to it
            //this is referred to as a chain, after enough chains all starting numbers finish at one (theoretically)
            int longestChainStartValue=0;//stores the starting value of the longest chain
            int longestChainLength=0;//stores the number of terms in the longest value
            for (int i = 1; i < 1000000; i++)
            {
                int curentChainStartValue = i;
                int curentChainLength = 1;
                double x = i;
                while (x != 1)//loops until the value is one
                {
                    if (x % 2 == 0)//if x is even divide x by 2
                    {
                        x = x / 2;
                        curentChainLength++; 
                    }
                    else//if x is odd x * 3 + 1
                    {
                        x = x * 3 + 1;
                        curentChainLength++;
                    }
                }
                if (curentChainLength > longestChainLength)//tests if the curent chain is longer than the longest and re-asigns if nessary
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
            Console.WriteLine(FindManyPrimes(10001));
            EvenFibonacciSequencer(2000000);
            LongestCollatzSequence();
            Console.ReadKey();
        }
    }
}
