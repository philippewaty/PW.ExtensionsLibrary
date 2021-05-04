using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.ExtensionsLibrary
{
  public static class DBCommandExtensions
  {

    /// <summary>
    /// ''' Shows the SQL of the CommandText property but replaces all of the parameters with their actual values.
    /// ''' </summary>
    /// ''' <param name="cmd"></param>
    /// ''' <returns></returns>
    /// ''' <remarks>
    /// ''' This will allow you to see the SQL with the real values behind the parameters so that you take that text
    /// ''' and paste it straight into a SQL editor to run without having to swap out parameters for values.
    /// ''' </remarks>
    public static string ActualCommandText(this IDbCommand cmd)
    {
      StringBuilder sb = new StringBuilder(cmd.CommandText);

      foreach (IDataParameter p in cmd.Parameters)
      {
        switch (p.DbType)
        {
          case DbType.AnsiString:
          case DbType.AnsiStringFixedLength:
          case DbType.Date:
          case DbType.DateTime:
          case DbType.DateTime2:
          case DbType.Guid:
          case DbType.String:
          case DbType.StringFixedLength:
          case DbType.Time:
          case DbType.Xml:
            {
              sb = sb.Replace(p.ParameterName, string.Format("'{0}'", p.Value?.ToString().Replace("'", "''")));
              break;
            }

          default:
            {
              sb = sb.Replace(p.ParameterName, p.Value?.ToString());
              break;
            }
        }
      }

      return sb.ToString();
    }


  }
}
