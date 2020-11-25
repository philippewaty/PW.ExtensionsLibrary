using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PW.ExtensionsLibrary
{
  public static class StringExtensions
  {
    /// <summary>
    /// true, if is valid email address
    /// from http://www.davidhayden.com/blog/dave/
    /// archive/2006/11/30/ExtensionMethodsCSharp.aspx
    /// </summary>
    /// <param name="s">email address to test</param>
    /// <returns>true, if is valid email address</returns>

    public static bool IsValidEmailAddress(this string s)
    {
      return new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$").IsMatch(s);
    }

    /// <summary>
    /// string formator,replace string.Format
    /// </summary>
    /// <example>string result = StrFormater.Format(@"Hello @Name! Welcome to C#!", new { Name = "World" });///</example>
    /// <param name="template"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <url>http://extensionmethod.net/5474/csharp/string/format</url>
    /// <example>string result = StrFormater.Format(@"Hello {Name}! Welcome to C#!", new { Name = "World" });</example>
    public static string Format(this string template, object data)
    {
      return Regex.Replace(template, @"@([\w\d]+)", match => GetValue(match, data));
    }

    static string GetValue(Match match, object data)
    {
      var paraName = match.Groups[1].Value;
      try
      {
        var proper = data.GetType().GetProperty(paraName);
        return proper.GetValue(data).ToString();
      }
      catch (Exception)
      {
        var errMsg = string.Format("Not find'{0}'", paraName);
        throw new ArgumentException(errMsg);
      }
    }

    #region Conversion    

    /// <summary>
    /// Converts a string to enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <url>https://www.extensionmethod.net/csharp/enum/toenum</url>
    /// <returns></returns>
    public static T? ToEnum<T>(this string value) where T : struct
    {
      if (string.IsNullOrEmpty(value)) return default(T);
      T result;
      return Enum.TryParse<T>(value, true, out result) ? result : default(T);
    }

    /// <summary>
    /// Converts a string to an Int32 value
    /// </summary>
    /// <param name = "value">The value.</param>
    /// <returns></returns>
    /// <example>
    /// <code>
    /// 	var value = "123";
    /// 	var numeric = value.ConvertTo().ToInt32();
    /// </code>
    /// </example>
    public static int ToInt32(this IConverter<string> value)
    {
      return ToInt32(value, 0, false);
    }

    /// <summary>
    /// Converts a string to an Int32 value
    /// </summary>
    /// <param name = "value">The value.</param>
    /// <param name = "defaultValue">The default value.</param>
    /// <param name = "ignoreException">if set to <c>true</c> any parsing exception will be ignored.</param>
    /// <returns></returns>
    /// <example>
    /// <code>
    /// 	var value = "123";
    /// 	var numeric = value.ConvertTo().ToInt32();
    /// </code>
    /// </example>
    public static int ToInt32(this IConverter<string> value, int defaultValue, bool ignoreException)
    {
      if (ignoreException)
      {
        try
        {
          return ToInt32(value, defaultValue, false);
        }
        catch
        { }
        return defaultValue;
      }

      return int.Parse(value.Value);
    }

    /// <summary>
    /// Determines whether the specified string is a date.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>
    ///   <c>true</c> if the specified input is date; otherwise, <c>false</c>.
    /// </returns>
    /// <url>http://extensionmethod.net/5506/csharp/string/isdate</url>
    public static bool IsDate(this string input)
    {
      DateTime dt;
      return (DateTime.TryParse(input, out dt));
    }

    /// <summary> 
    /// Converts a string time to a timespan. 
    /// </summary> 
    /// <param name="time">The time.</param> 
    /// <returns> 
    /// A timespan object. 
    /// </returns>
    /// <url>http://extensionmethod.net/5515/csharp/string/stringtotimespan</url>
    public static TimeSpan StringToTimeSpan(this string time)
    {
      TimeSpan timespan;
      var result = TimeSpan.TryParse(time, out timespan);
      return result ? timespan : new TimeSpan(0, 0, 0);
    }

    /// <summary>
    /// Gets specified number of characters from left of string
    /// </summary>
    /// <param name="value"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static string Left(this string value, int count)
    {
      return value.SafeSubstring(0, count);
    }

    /// <summary>
    /// Gets specified number of characters from right of string
    /// </summary>
    /// <param name="value"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static string Right(this string value, int count)
    {
      return value.SafeSubstring(value.Length - count, count);
    }

    /// <summary>Limit the text length</summary> 
    /// <param name="value">Text to limit</param> 
    /// <param name="maxLength">Maximum allowed number of characters 
    /// in the result</param> 
    /// <param name="showEllipsis"><code>true</code>=Limit 
    /// <paramref name="value"/> to first 
    /// (<paramref name="maxLength"/>-3) characters plus "...", 
    /// <code>false</code>=Limit <paramref name="value"/> to first 
    /// <paramref name="maxLength"/> characters</param> 
    /// <returns>Content of <paramref name="value"/>, but at most 
    /// <paramref name="maxLength"/> characters</returns> 
    /// <remarks>With <paramref name="showEllipsis"/> left to default 
    /// value of <code>true</code> the result will be "..." even if 
    /// you specify a maximum length less than or equal to 3.</remarks> 
    /// <url>http://extensionmethod.net/5528/csharp/string/limittextlength</url>
    public static string LimitTextLength(this string value, int maxLength, bool showEllipsis = true)
    {
      if (maxLength < 0) throw new ArgumentOutOfRangeException("maxLength", "Value must not be negative");
      if (string.IsNullOrWhiteSpace(value)) return string.Empty;
      var n = value.Length;
      var ellipsis = showEllipsis ? "..." : string.Empty;
      var minLength = ellipsis.Length;
      maxLength = Math.Max(minLength, maxLength);
      return n > maxLength ? value.Substring(0, Math.Min(maxLength - minLength, n)) + ellipsis : value;
    }

    /// <summary>
    /// Converts a string to a boolean value if possible
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is boolean; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentException">Value is not a boolean value.</exception>
    /// <url>http://extensionmethod.net/5427/csharp/string/asboolean</url>
    public static bool AsBoolean(this string value)
    {
      string[] booleanValues = new string[] { "false", "f", "true", "t", "yes", "no", "y", "n", "vrai", "faux" };
      var val = value.ToLower().Trim();
      return booleanValues.Contains(val);
    }

    /// <summary>
    /// Check if a string is a boolean value and throws an exception if not
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is boolean; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentException">Value is not a boolean value.</exception>
    /// <url>http://extensionmethod.net/5427/csharp/string/asboolean</url>
    public static bool IsBoolean(this string value)
    {
      var val = value.ToLower().Trim();
      if (val == "false")
        return false;
      if (val == "f")
        return false;
      if (val == "true")
        return true;
      if (val == "t")
        return true;
      if (val == "yes")
        return true;
      if (val == "no")
        return false;
      if (val == "y")
        return true;
      if (val == "n")
        return false;
      throw new ArgumentException("Value is not a boolean value.");
    }

    #endregion

    /// <summary>
    /// Returns true if this string is any of the provided strings. Equivalent to IN operator in SQL. It eliminates the need to write something like 'if (foo == "foo1" || foo == "foo2" || foo == "foo3")' 
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="values">The values.</param>
    /// <returns></returns>
    /// <url>http://extensionmethod.net/1858/csharp/string/in</url>
    public static bool In(this string s, params string[] values)
    {
      return values.Any(x => x.Equals(s));
    }

    /// <summary>
    /// Remove from the given string, all characters provided in a params array of chars
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="chars">The chars.</param>
    /// <returns></returns>
    /// <url>http://extensionmethod.net/1991/csharp/string/deletechars</url>
    public static string DeleteChars(this string input, params char[] chars)
    {
      return new string(input.Where((ch) => !chars.Contains(ch)).ToArray());
    }

    /// <summary>
    /// Repeats the specified input.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="count">The repeat count.</param>
    /// <returns></returns>
    public static string Repeat(this string input, int count)
    {
      if (input.Length == 1)
        return new string(input[0], count);

      var sb = new StringBuilder(count * input.Length);
      while (count-- > 0)
        sb.Append(input);
      return sb.ToString();
    }
    /// <summary>
    /// Safe substring.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    /// <url>https://sharpsnippets.wordpress.com/2014/01/25/safe-substring/</url>
    public static string SafeSubstring(this string input, int startIndex, int length)
    {
      return new string((input ?? string.Empty).Skip(startIndex).Take(length).ToArray());
    }

    /// <summary>
    /// Suppresses the leading zero.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns></returns>
    public static string SuppressLeadingZero(this string input)
    {
      return input.TrimStart('0');
    }

    /// <summary>
    /// Tests whether the contents of a string is a numeric value
    /// </summary>
    /// <param name = "input">String to check</param>
    /// <returns>
    /// Boolean indicating whether or not the string contents are numeric
    /// </returns>
    /// <remarks>
    /// Contributed by Kenneth Scott
    /// </remarks>
    public static bool IsNumeric(this string input)
    {
      float output;
      return float.TryParse(input, out output);
    }

    /// <summary>Convert text's case to a title case</summary>
    /// <remarks>UppperCase characters is the source string after the first of each word are lowered, unless the word is exactly 2 characters</remarks>
    public static string ToTitleCase(this string value)
    {
      return ToTitleCase(value, CultureInfo.CurrentCulture);
    }

    /// <summary>Convert text's case to a title case</summary>
    /// <remarks>UppperCase characters is the source string after the first of each word are lowered, unless the word is exactly 2 characters</remarks>
    public static string ToTitleCase(this string value, CultureInfo culture)
    {
      return culture.TextInfo.ToTitleCase(value);
    }
        
    /// <summary>Uppercase First Letter</summary>
    /// <param name = "value">The string value to process</param>
    public static string ToUpperFirstLetter(this string value)
    {
      if (string.IsNullOrWhiteSpace(value)) return string.Empty;

      char[] valueChars = value.ToCharArray();
      valueChars[0] = char.ToUpper(valueChars[0]);

      return new string(valueChars);
    }

    /// <summary>
    /// Determines whether the string is equal to any of the provided values.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="comparisonType"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool EqualsAny(this string value, StringComparison comparisonType, params string[] values)
    {
      return values.Any(v => value.Equals(v, comparisonType));
    }

    /// <summary>
    /// Wildcard comparison for any pattern
    /// </summary>
    /// <param name="value">The current <see cref="System.String"/> object</param>
    /// <param name="patterns">The array of string patterns</param>
    /// <returns></returns>
    public static bool IsLikeAny(this string value, params string[] patterns)
    {
      return patterns.Any(p => value.IsLike(p));
    }

    /// <summary>
    /// Wildcard comparison
    /// </summary>
    /// <param name="value"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static bool IsLike(this string value, string pattern)
    {
      if (value == pattern) return true;

      if (pattern[0] == '*' && pattern.Length > 1)
      {
        for (int index = 0; index < value.Length; index++)
        {
          if (value.Substring(index).IsLike(pattern.Substring(1)))
            return true;
        }
      }
      else if (pattern[0] == '*')
      {
        return true;
      }
      else if (pattern[0] == value[0])
      {
        return value.Substring(1).IsLike(pattern.Substring(1));
      }
      return false;
    }

    /// <summary>
    /// Split a string with NewLine caracter.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <returns></returns>
    public static IEnumerable<string> ToLines(this string s)
    {
      if (!string.IsNullOrEmpty(s))
      {
        return s.Split(new string[] { "\r\n", Environment.NewLine }, StringSplitOptions.None);
      }
      else { return new string[0]; }
    }

    /// <summary>
    /// Ensures that the string ends with the prefix passed in parameter.
    /// </summary>
    /// <param name="value">Character string</param>
    /// <param name="prefix">Prefix to add</param>
    /// <returns>The string including the prefix</returns>
    /// <exemple>
    /// Dim extension = "txt"
    /// dim filename = String.Concat(file.name, extension.EnsureStartsWith("."))
    /// </exemple>
    public static string EnsureStartsWith(this string value, string prefix)
    {
      return value.StartsWith(prefix) ? value : string.Concat(prefix, value);
    }

    /// <summary>
    /// Ensures that the string ends with the suffix passed in parameter.
    /// </summary>
    /// <param name="value">Character string</param>
    /// <param name="suffix">Suffix to add</param>
    /// <returns>The string including the suffix</returns>
    /// <exemple>
    /// dim directoryname = "c:\temp"
    /// directoryname = directoryname.EnsureEndsWith("\")
    /// </exemple>
    public static string EnsureEndsWith(this string value, string suffix)
    {
      return value.EndsWith(suffix) ? value : string.Concat(value, suffix);
    }

  }

}
