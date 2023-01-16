using System;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace pwExtensionsLibrary
{
  public static class DataGridViewExtensions
  {
    /// <summary>
    /// Prevents DataGridView from flickering
    /// </summary>
    /// <param name="dgv"></param>
    /// <param name="setting"></param>
    /// <url>https://stackoverflow.com/questions/41893708/how-to-prevent-datagridview-from-flickering-when-scrolling-horizontally</url>
    public static void DoubleBuffered(this DataGridView dgv, bool setting)
    {
      Type dgvType = dgv.GetType();
      PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
      pi.SetValue(dgv, setting, null);
    }
  }
}
