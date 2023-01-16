using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwExtensionsLibrary
{
  public static class BooleanExtensions
  {
    /// <summary>
    /// Gets the boolean in string.
    /// </summary>
    /// <param name="value">if set to <c>true</c> [value].</param>
    /// <returns></returns>
    /// <url>http://extensionmethod.net/5540/csharp/string/getboolstring</url>
    public static string GetBoolString(this bool value)
    {
      return value ? "Yes" : "No";
    }
  }
}
