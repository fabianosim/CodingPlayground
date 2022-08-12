using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.LeetCode
{
    /// <summary>
    /// Class to resolve algorithm problems from LeetCode.com
    /// </summary>
    public class Algorithms
    {
        /// <summary>
        /// Checks if an integer number is a palindrome without doing any conversion.
        /// </summary>
        /// <remarks>
        ///     Solution from Geeks for Geeks: https://www.geeksforgeeks.org/check-number-palindrome-not-without-using-extra-space/
        ///     Palindrome without string conversion 
        /// </remarks>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsIntPalindromeWithoutConversion(int n)
        {
            // Find the appropriate
            // divisor to extract
            // the leading digit
            int divisor = 1;
            while (n / divisor >= 10)
                divisor *= 10;

            while (n != 0)
            {
                int leading = n / divisor;
                int trailing = n % 10;

                // If first and last digit
                // not same return false
                if (leading != trailing)
                    return false;

                // Removing the leading and
                // trailing digit from number
                n = (n % divisor) / 10;

                // Reducing divisor by
                // a factor of 2 as 2
                // digits are dropped
                divisor = divisor / 100;
            }
            return true;
        }

        /// <summary>
        /// Checks if an integer is a palindrome by using string conversion.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsIntPalindrome(int x)
        {
            string xStr = x.ToString();
            int xHalfSize = xStr.Length / 2;

            for (int i = 0; i < xHalfSize; i++)
            {
                if (xStr[i] != xStr[xStr.Length - 1 - i])
                    return false;
            }

            return true;
        }
    }
}
