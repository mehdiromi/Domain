using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Core
{
    /// <summary>
    /// Here are the String Extension methods (more like Static helper methods)
    /// </summary>
    static class StringExtensions
    {
        
        /// <summary>
        /// StripPunctuation Version 1: Simple and fastest Way.  This method is using StringBuilder to optimize performance for long strings.
        /// </summary>
        /// <param name="strInput">input string</param>
        /// <returns>string without punctuations</returns>
        public static string StripPunctuation(this string strInput)
        {
            var stripped = new StringBuilder();
            foreach (char c in strInput)
            {
                if (!char.IsPunctuation(c) && !char.IsSymbol(c) && !char.IsWhiteSpace(c))
                {
                    stripped.Append(c);
                }
            }
            return stripped.ToString();
        }

        
        /// <summary>
        /// StripPunctuation Version 2: Small and Simple way with Regular Expressions
        /// </summary>
        /// <param name="strInput">input string</param>
        /// <returns>string without punctuations</returns>
        public static string StripPunctuation2(this string strInput)
        {
            return Regex.Replace(strInput, @"[\W_]", string.Empty);
        }



        /// <summary>
        /// Reverses a given string word by word:  Example:   "one two" -> "two one"
        /// </summary>
        /// <param name="strInput">input string</param>
        /// <returns>reversed string</returns>
        public static string Reversed(this string strInput)
        {
            //using LINQ to convert string to array of word, remove spaces, reverse the array and then aggregate through the array to create a new string of words separated by a space
            var reveresed = (
                from word in strInput.Split(' ')
                where word.Trim().Length > 0
                select word)
                    .Reverse()
                    .Aggregate((current, next) => current + " " + next);
            return reveresed;
        }


    }


}