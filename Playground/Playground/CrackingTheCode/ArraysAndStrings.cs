using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Playground.CrackingTheCode
{
    public static class ArraysAndStrings
    {
        /// <summary>
        /// Time complexity: O(N*N)
        /// Exercise 1.1
        /// Implement an algorithm to determine if a string has all unique characters.
        /// What if you cannot use additional data structures?
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static bool IsUnique(string inputStr)
        {
            // tempString will be increased with inputStr character after each iteration
            string tempString = string.Empty;

            for (int i = 0; i < inputStr.Length; i++)
            {
                if (tempString.Contains(inputStr[i]))
                    return false;

                tempString += inputStr[i];
            }

            return true;
        }

        /// <summary>
        /// Considering it is ASCII
        /// Time complexity: O(N)
        /// Exercise 1.1
        /// Implement an algorithm to determine if a string has all unique characters.
        /// What if you cannot use additional data structures?
        /// </summary>
        /// <param name="inputStr"></param>
        public static bool IsUnique2(string inputStr)
        {
            if (inputStr.Length > 128) return false;

            bool[] charSet = new bool[128];

            for (int i = 0; i < inputStr.Length; i++)
            {
                if (charSet[inputStr[i]]) // Already found
                    return false;

                charSet[inputStr[i]] = true;
            }

            return true;
        }

        /// <summary>
        /// Given two strings, write a method to decide if one is a permutation of the other.
        /// Time complexity: O(N)
        /// Exercise 1.2
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool CheckPermutation(string str1, string str2)
        {
            // Loop str1 and check if each char exists in str2. 
            // If yes, let’s remove this char from str2
            string shrinkedStr2 = str2;

            foreach (char str1Char in str1)
            {
                int charIndex = shrinkedStr2.IndexOf(str1Char);

                if (charIndex < 0)
                    return false;

                // Remove the character from Str2
                shrinkedStr2 = shrinkedStr2.Substring(0, charIndex) + shrinkedStr2.Substring(charIndex + 1);
            }

            return string.IsNullOrEmpty(shrinkedStr2);
        }

        /// <summary>
        /// Write a method to replace all spaces in a string with '%20'. You may assume that the string
        /// has sufficient space at the end to hold the additional characters, and that you are given the "true"
        /// length of the string. 
        /// Time complexity:
        /// Exercise 1.3
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string URLFyString(string inputString)
        {
            string urlfiedString = string.Empty;

            foreach (char charac in inputString)
            {
                int charCode = (int)charac;
                string newChar = string.Empty;

                if (charCode.Equals((int)' '))
                    newChar = "%20";
                else
                    newChar = charac.ToString();

                urlfiedString += newChar;
            }

            return urlfiedString;
        }

        /// <summary>
        /// Given a string, write a function to check if it is a permutation of a palindrome. A palindrome is a word or
        /// phrase that is the same forwards and backwards. A permutation is a rearrangement of letters.The palindrome does
        /// not need to be limited to just dictionary words.
        /// Time complexity: O(N+N) = O(N)
        /// Exercise 1.4
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static bool IsPalindromePermutation(string inputStr)
        {
            // Check if all characters has even count
            // If we have odd characters, then it must be up to one. 
            Dictionary<char, int> dictCharsCount = new Dictionary<char, int>();

            foreach (char inputChar in inputStr)
            {
                if (dictCharsCount.ContainsKey(inputChar))
                    dictCharsCount[inputChar] += 1;
                else
                    dictCharsCount.Add(inputChar, 1);
            }

            // Loop through the list and check for odd numbers
            foreach (KeyValuePair<char, int> countItem in dictCharsCount)
            {
                if (countItem.Value > 2 || (countItem.Value % 2) > 1)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// One Away: There are three types of edits that can be performed on strings: insert a character,
        /// remove a character, or replace a character.Given two strings, write a function to check if they are
        /// one edit (or zero edits) away.
        /// Time complexity: O(N)
        /// Exercise 1.5
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool IsOneOrZeroEdit(string str1, string str2)
        {
            // If the strings are equal, return true. No edits needed.
            if (str1.Equals(str2))
                return true;

            // Check if adding or deletions are needed
            int countReplacements = 0;

            try
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (!str1[i].Equals(str2[i]))
                        countReplacements++;

                    if (countReplacements > 1)
                        return false;
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                if (str1.Length - str2.Length > 1)
                    return false;

                // if we reach here, or the lengths are the same or str1 length is greater than str2 length.
                countReplacements++;
                
                if (countReplacements > 1)
                    return false;
            
            }

            return true;
        }

        /// <summary>
        /// Implement a method to perform basic string compression using the counts
        /// of repeated characters.For example, the string aabcccccaaa would become a2blc5a3.If the
        /// "compressed" string would not become smaller than the original string, your method should return
        /// the original string. You can assume the string has only uppercase and lowercase letters(a - z). 
        /// Exercise 1.6
        /// Time Complexity: O(N)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CompressString(string str)
        {
            int finalLength = GetCompressedCapacity(str);
            int countConsecutive = 0;

            if (finalLength == str.Length) 
                return str;
            
            StringBuilder compressedString = new StringBuilder(finalLength);

            // Puts the string chars in a hashtable and increment the count for each repeated char
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;

                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressedString.Append(str[i]);
                    compressedString.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }

            return compressedString.ToString();

            // Get the StringBuilder capacity
            int GetCompressedCapacity(string str)
            {
                int compressedLength = 0;
                int countConsecutive = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    countConsecutive++;

                    // If the next char is different, then computes the count and move to the next
                    if (i + 1 >= str.Length || str[i] != str[i + 1])
                    {
                        compressedLength += 1 + countConsecutive.ToString().Length;
                        countConsecutive = 0;
                    }
                }

                return compressedLength;
            }
        }

        /// <summary>
        /// Rotate Matrix
        /// Exercise 1.7
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[][] RotateMatrix(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix.Length != matrix[0].Length) return null;
            
            int n = matrix.GetLength(0);

            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;

                // note we only need to loop through the first/top row in the matrix and swap all other elements
                for (int i = first; i < last; i++)
                {
                    // used to decrement when we start from the last item in the matrix subtract the layer
                    int offset = i - first;

                    // save the top
                    int top = matrix[first][i]; 

                    // top row=0 column=i <- Left row=L-offset Column 0
                    matrix[first][i] = matrix[last - offset][first];

                    // left row=L-Offset column=0 <- bottom row=4 column=L-Offset
                    matrix[last - offset][first] = matrix[last][last - offset];

                    // bottom bottom row=4 column=L-Off <- right, row=i, column=4
                    matrix[last][last - offset] = matrix[i][last];

                    // right row=i, column=4 <- top
                    matrix[i][last] = top;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0
        /// Exercise 1.8
        /// Time complexity: O(N*M + C*(M+N))
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[,] ZeroMatrix(int[,] matrix)
        {
            if (matrix.Rank != 2) return null; // return null if number of dimensions is not 2

            List<int[]> coordinates = new List<int[]>();

            for (int i = 0; i < matrix.GetLength(0); i++) // Gets the length for the first dimension.
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j].Equals(0)) coordinates.Add(new int[] { i, j });

                }
            }

            // Fill new matrix with zero
            for (int i = 0; i < coordinates.Count; i++)
            {
                // Fill row
                for (int r = 0; r < matrix.GetLength(1); r++)
                    matrix[coordinates[i][0], r] = 0;

                // Fill column
                for (int c = 0; c < matrix.GetLength(0); c++)
                    matrix[c, coordinates[i][1]] = 0;
            }

            return matrix;
        }

        /// <summary>
        /// Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0
        /// Exercise 1.8
        /// Complexity: O(N) space
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[,] ZeroMatrix2(int[,] matrix)
        {
            if (matrix.Rank != 2) return null; // return null if number of dimensions is not 2

            bool rowHasZeros = false;
            bool columnHasZeros = false;

            // Checks if first column has zeros
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[0, i].Equals(0))
                    rowHasZeros = true;
            }

            // Checks if first column has zeros
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[j, 0].Equals(0))
                    columnHasZeros = true;
            }
            
            // Check for zeros in the rest of the array
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j].Equals(0))
                    {
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                }
            }

            // Nullify rows based on values in the first column
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0].Equals(0))
                    NullifyRow(matrix, i);
            }

            // Nullify columns based on values in the first row
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i].Equals(0))
                    NullifyColumn(matrix, i);
            }


            // Nullify first row
            if (rowHasZeros)
                NullifyRow(matrix, 0);
            
            // Nullify first column
            if (columnHasZeros)
                NullifyColumn(matrix, 0);
            
            return matrix;

            
            void NullifyRow(int[,] matrix, int rowIndex)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                    matrix[rowIndex, i] = 0;
            }

            void NullifyColumn(int[,] matrix, int columnIndex)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    matrix[i, columnIndex] = 0;
            }
        }

        /// <summary>
        /// Assumeyou have a method isSubstringwhich checks if oneword is a substring
        /// of another.Given two strings, sl and s2, write code to check if s2 is a rotation of sl using only one
        /// call to isSubstring(e.g., "waterbottle" is a rotation of"erbottlewat")
        /// Exercise 1.9
        /// Time complexity: O(N+M) with 3 loops.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool IsSubstring(string str1, string str2)
        {
            // Get all chars from str1 in a hashtable and count the duplicated ones.
            Hashtable wordMap = new Hashtable();
            int countMappedChars = str1.Length;

            foreach (char strChar in str1)
            {
                if (wordMap.ContainsKey(strChar))
                    wordMap[strChar] = (int)wordMap[strChar] + 1; // Safe unboxing here as key will always have a valid int value.
                else
                    wordMap.Add(strChar, 1);
            }

            // Loop through the second string and search for mapped characters.
            foreach (char strChar in str2)
            {
                if (wordMap.ContainsKey(strChar) && (int)wordMap[strChar] > 0)
                {
                    wordMap[strChar] = (int)wordMap[strChar] - 1; // Safe unboxing here as key will always have a valid int value.
                    countMappedChars -= 1;
                }
            }

            return countMappedChars == 0;
        }
    }
}
