using System;
using System.ComponentModel;

namespace PW.ExtensionsLibrary
{
  public static class EnumExtension
  {
    /// <summary>
    /// Gets the enum description.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <url>https://www.extensionmethod.net/csharp/enum/getenumdescription-1</url>
    /// <returns></returns>
    public static string GetEnumDescription(this Enum value)
    {
      System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

      DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

      if (attributes != null && attributes.Length > 0)
        return attributes[0].Description;
      else
        return value.ToString();
    }
  }
}
