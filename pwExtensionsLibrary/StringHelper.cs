using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwExtensionsLibrary
{
  public static class StringHelper
  {
    /// <summary>
    /// Return a random string of a chosen length.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <param name="withUpperCase">if set to <c>true</c> [with upper case].</param>
    /// <param name="withAccents">if set to <c>true</c> [with accents].</param>
    /// <param name="withNumbers">if set to <c>true</c> [with numbers].</param>
    /// <param name="withSpecialChars">if set to <c>true</c> [with special chars].</param>
    /// <returns></returns>
    /// <url>http://extensionmethod.net/5538/csharp/string/randomstring</url>
    public static string RandomString(int length, bool withUpperCase, bool withAccents, bool withNumbers, bool withSpecialChars)
    {
      Random random = new Random((int)DateTime.Now.Ticks);
      StringBuilder sb = new StringBuilder();
      string validChars = "abcdefghijklmnopqrstuvwxyz";
      if (withUpperCase) validChars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      if (withAccents) validChars += "éèçàùíúóùìòá";
      if (withAccents & withUpperCase) validChars += "ÉÈÇÀÙÍÚÓÙÌÒÁ";
      if (withNumbers) validChars += "0123456789";
      if (withSpecialChars) validChars += @" !""#$%&'()*+,-./:;<=>?@[]^_`{}|~";
      char c;
      for (int i = 0; i < length; i++)
      {
        c = validChars[random.Next(0, validChars.Length)];
        sb.Append(c);
      }
      return sb.ToString();
    }
  }
}
