using System;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace ExtensionsLibrary
{
  public static class DataGridViewExtensions
  {
    //https://stackoverflow.com/questions/41893708/how-to-prevent-datagridview-from-flickering-when-scrolling-horizontally
    public static void DoubleBuffered(this DataGridView dgv, bool setting)
    {
      Type dgvType = dgv.GetType();
      PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
      pi.SetValue(dgv, setting, null);
    }
  }
}
