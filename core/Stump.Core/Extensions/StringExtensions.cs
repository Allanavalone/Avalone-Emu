﻿using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Stump.Core.Collections;
using System.Collections.Generic;

namespace Stump.Core.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveAccents(this string source)
        {
            return string.Concat(
                source.Normalize(NormalizationForm.FormD)
                      .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                   UnicodeCategory.NonSpacingMark)
                ).Normalize(NormalizationForm.FormC);
        }

        public static List<T> Splice<T>(this List<T> Source, int Start, int Size)
        {
            var retVal = Source.Skip(Start).Take(Size).ToList();
            Source.RemoveRange(Start, Size);
            return retVal;
        }

        public static bool HasAccents(this string source)
        {
            return
                source.Normalize(NormalizationForm.FormD)
                      .Any(x => CharUnicodeInfo.GetUnicodeCategory(x) == UnicodeCategory.NonSpacingMark);
        }

        public static string FirstLetterUpper(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            var letters = source.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);

            return new string(letters);
        }

        public static string ConcatCopy(this string str, int times)
        {
            var builder = new StringBuilder(str.Length * times);

            for (int i = 0; i < times; i++)
            {
                builder.Append(str);
            }

            return builder.ToString();
        }

        public static string RandomString(this Random random, int size)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                //26 letters in the alphabet, ascii + 65 for the capital letters
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))));
            }
            return builder.ToString();
        }

        public static string[] SplitAdvanced(this string expression, string delimiter)
        {
            return SplitAdvanced(expression, delimiter, "", false);
        }

        public static string[] SplitAdvanced(this string expression, string delimiter,
                                     string qualifier)
        {
            return SplitAdvanced(expression, delimiter, qualifier, false);
        }


        public static string[] SplitAdvanced(this string expression, string delimiter,
            string qualifier, bool ignoreCase)
        {
            return SplitAdvanced(expression, new[] { delimiter }, qualifier, false);
        }

        public static string[] SplitAdvanced(this string expression, string[] delimiters,
                                     string qualifier, bool ignoreCase)
        {
            bool qualifierState = false;
            var startIndex = 0;
            var values = new ArrayList();

            for (int charIndex = 0; charIndex < expression.Length - 1; charIndex++)
            {
                if (qualifier != null)
                    if (string.Compare(expression.Substring
                                           (charIndex, qualifier.Length), qualifier, ignoreCase) == 0)
                    {
                        qualifierState = !(qualifierState);
                    }
                    else if (!(qualifierState)
                             && (delimiters.Any(x => string.Compare(expression.Substring
                                                  (charIndex, x.Length), x, ignoreCase) == 0)))
                    {
                        values.Add(expression.Substring
                                       (startIndex, charIndex - startIndex));
                        startIndex = charIndex + 1;
                    }
            }

            if (startIndex < expression.Length)
                values.Add(expression.Substring
                               (startIndex, expression.Length - startIndex));

            var returnValues = new string[values.Count];
            values.CopyTo(returnValues);
            return returnValues;
        }

        public static string EscapeString(this string str)
        {
            return str == null ? null : Regex.Replace(str, @"[\r\n\x00\x1a\\'""]", @"\$0");
        }

        /// <summary>
        ///   Convert html chars to HTML entities
        /// </summary>
        /// <param name = "str"></param>
        /// <returns></returns>
        public static string HtmlEntities(this string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            return str;
        }

        public static int CountOccurences(this string str, char chr, int startIndex, int count)
        {
            int occurences = 0;

            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (str[i] == chr)
                    occurences++;
            }

            return occurences;
        }

        public static int CountOccurences(this string str, char chr)
        {
            return CountOccurences(str, chr, 0, str.Length);
        }


        public static string GetMD5(this string encryptString)
        {
            var passByteCrypt = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(encryptString));

            return passByteCrypt.ByteArrayToString();
        }

        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}