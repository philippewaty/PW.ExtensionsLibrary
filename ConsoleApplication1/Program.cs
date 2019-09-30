using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionsLibrary;

namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("STRING");
      Console.WriteLine("------");
      string test = "philippe.waty@medsoc@be";
      Console.WriteLine("abc".Repeat(3));
      Console.WriteLine(test.Repeat(2));
      Console.WriteLine(test.IsValidEmailAddress());
      test = "philippe.waty@medsoc";
      Console.WriteLine(test.IsValidEmailAddress());
      test = "philippe.waty@medsoc.be";
      Console.WriteLine(test.IsValidEmailAddress());
      Console.WriteLine("Suppress leading zero from 000123456789 : {0}", "000123456789".SuppressLeadingZero());

      Console.WriteLine("Format");
      Console.WriteLine(@"Bonjour {prenom} {nom} {mail}".Format(new { prenom = "Philippe", nom = "Waty", mail = "philippe.waty@medsoc.be" }));

      Console.WriteLine("Convertion");
      Console.WriteLine("123".ConvertTo().ToInt32());
      Console.WriteLine(123f.ConvertTo<Int32>());
      Console.WriteLine(123.ConvertTo<Int64>());
      Console.WriteLine("123d".ConvertTo<Double>(456, true));
      try
      {
        Console.WriteLine("123d".ConvertTo<Double>(456));
      }
      catch (Exception ex)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ForegroundColor = ConsoleColor.Gray;
      }
      Console.WriteLine("123d".IsNumeric());
      Console.WriteLine("123".IsNumeric());
      Console.WriteLine("123.456".IsNumeric());
      Console.WriteLine("123,456".IsNumeric());

      Console.WriteLine("SafeSubstring");
      Console.WriteLine("SafeSubstring".SafeSubstring(0, 5));
      Console.WriteLine("SafeSubstring".SafeSubstring(0, 50));
      Console.WriteLine("SafeSubstring".SafeSubstring(20, 5));

      var value = "123";
      var numeric = value.ConvertTo().ToInt32();

      string sample = null;
      int? k = sample.ConvertTo<int?>(); // returns null 
      DateTime? dn = "01/12/2008".ConvertTo<DateTime?>();

      DateTime myDate = DateTime.Today;

      Console.WriteLine(myDate.GetFirstDayOfMonth().ToString("dd/MM/yyyy"));
      Console.WriteLine(myDate.GetLastDayOfMonth().ToString("dd MMMM yyyy"));

      Console.WriteLine(String.Format("La date {0} est un weekend? : {1}", myDate.ToString("dd MMMM yyyy"), myDate.IsWeekend()));
      myDate = new DateTime(2012, 12, 23);
      Console.WriteLine(String.Format("La date {0} est un weekend? : {1}", myDate.ToString("dd MMMM yyyy"), myDate.IsWeekend()));
      Console.WriteLine(String.Format("La date {0} est la date du jour ? : {1}", myDate.ToString("dd MMMM yyyy"), myDate.IsToday()));
      myDate = DateTime.Today;
      Console.WriteLine(String.Format("La date {0} est la date du jour ? : {1}", myDate.ToString("dd MMMM yyyy"), myDate.IsToday()));
      Console.WriteLine(String.Format("Le n° du jour de {0} est {1}", myDate.ToString("dd MMMM yyyy"), myDate.GetDayOfYear()));

      myDate = new DateTime(2010, 2, 1);
      Console.WriteLine(String.Format("Nb jours dans {0} : {1}", myDate.ToString("dd/MM/yyyy"), myDate.GetCountDaysOfMonth()));
      myDate = new DateTime(2012, 2, 1);
      Console.WriteLine(String.Format("Nb jours dans {0} : {1}", myDate.ToString("dd/MM/yyyy"), myDate.GetCountDaysOfMonth()));
      myDate = new DateTime(2012, 3, 3);
      Console.WriteLine(String.Format("Nb jours dans {0} : {1}", myDate.ToString("dd/MM/yyyy"), myDate.GetCountDaysOfMonth()));
      myDate = new DateTime(2012, 4, 1);
      Console.WriteLine(String.Format("Nb jours dans {0} : {1}", myDate.ToString("dd/MM/yyyy"), myDate.GetCountDaysOfMonth()));
      myDate = new DateTime(2012, 7, 7);
      Console.WriteLine(String.Format("Nb jours dans {0} : {1}", myDate.ToString("dd/MM/yyyy"), myDate.GetCountDaysOfMonth()));

      myDate = new DateTime(1973, 10, 3);
      DateTime myDate2 = new DateTime(2013, 10, 3);
      Console.WriteLine(String.Format("Age de {0} au {1} : {2}", myDate.ToString("dd/MM/yyyy"), myDate2.ToString("dd/MM/yyyy"), myDate.CalculateAge(myDate2)));
      Console.WriteLine(String.Format("Age de {0} maintenant : {1}", myDate.ToString("dd/MM/yyyy"), myDate.CalculateAge()));
      Console.WriteLine(String.Format("N° de semaine de {0} : {1}", myDate.ToString("dd/MM/yyyy"), myDate.GetWeekOfYear()));

      Console.WriteLine("isDate 01/01/2018 ? {0}", "01/01/2018".IsDate());
      Console.WriteLine("isDate 29/02/2016 ? {0}", "29/02/2016".IsDate());
      Console.WriteLine("isDate 29/02/2017 ? {0}", "29/02/2017".IsDate());
      Console.WriteLine("isDate 01/01/2018test ? {0}", "01/01/2018test".IsDate());
      Console.WriteLine("isDate 32/01/2018 ? {0}", "32/01/2018".IsDate());
      Console.WriteLine("isDate 01/13/2018 ? {0}", "01/13/2018".IsDate());
      Console.WriteLine("22:03:34 -> {0}", "22:03:34".StringToTimeSpan());

      Console.WriteLine("23 March 2003 {0}", "23 March 2003".IsDate());
      Console.WriteLine("1 August -2003 {0}", "1 August -2003".IsDate());
      Console.WriteLine("2013-1-25 {0}", "2013-1-25".IsDate());
      Console.WriteLine("May 30, 2009 {0}", "May 30, 2009".IsDate());
      Console.WriteLine("23 JulyAugust 2003 {0}", "23 JulyAugust 2003".IsDate());
      Console.WriteLine("38 August 2003 {0}", "38 August 2003".IsDate());
      Console.WriteLine("2013-13-25 {0}", "2013-13-25".IsDate());
      Console.WriteLine("2013-10-92 {0}", "2013-10-92".IsDate());
      Console.WriteLine("-2013-1-3 {0}", "-2013-1-3".IsDate());
      Console.WriteLine("May 32, 2009 {0}", "May 32, 2009".IsDate());
      Console.WriteLine("One flew over the Cookoo's nest {0}", "One flew over the Cookoo's nest".IsDate());
      Console.WriteLine("'' {0}", "".IsDate());
      Console.WriteLine("empty string {0}", string.Empty.IsDate());
      Console.WriteLine("null string {0}", ((string)null).IsDate());

      string s = "ceci est un test";
      Console.WriteLine(String.Format("{0} finit par s : {1}", s, s.EnsureEndsWith("s")));
      Console.WriteLine(String.Format("{0} commence par 'un' : {1}", s, s.EnsureStartsWith("un ")));

      Console.WriteLine(ExtensionsLibrary.StringHelper.RandomString(10, false, true, false, false));
      Console.WriteLine(ExtensionsLibrary.StringHelper.RandomString(10, true, true, true, true));

      Console.WriteLine("The quick brown fox jumps over the lazy dog".LimitTextLength(20, false));
      Console.WriteLine("The quick brown fox jumps over the lazy dog".LimitTextLength(20, true));

      Console.WriteLine("Server in Electronics, Computers {0}", "Server".In("Electronics", "Computers"));
      Console.WriteLine("Server in Electronics, Computers, Server {0}", "Server".In("Electronics", "Computers", "Server"));

      string Text = "#Hello world. This is a [test]";
      Console.WriteLine("Delete chars [ ] : {0}", Text.DeleteChars('[', ']'));
      Console.WriteLine("Delete chars [ ] : {0}", Text.DeleteChars('e', 'i'));

      Console.WriteLine("");
      Console.WriteLine("DATES");
      Console.WriteLine("-----");
      Console.WriteLine("Last day of month Today : {0}", DateTime.Today.LastDayOfMonth());
      Console.WriteLine("Last day of month 01/02/2016 : {0}", new DateTime(2016, 2, 1).LastDayOfMonth());

      Console.WriteLine("isDateBetween : today bewteen 01/01/2017 and 31/07/2017 : {0}", DateTime.Today.IsBetween(new DateTime(2017, 1, 1), new DateTime(2017, 07, 31)));
      Console.WriteLine("isDateBetween : today bewteen 01/01/2017 and 31/07/2099 : {0}", DateTime.Today.IsBetween(new DateTime(2017, 1, 1), new DateTime(2099, 07, 31)));
      Console.WriteLine("isDateBetween : today bewteen 01/01/2018 and 31/07/2017 : {0}", DateTime.Today.IsBetween(new DateTime(2018, 1, 1), new DateTime(2017, 07, 31)));

      Console.WriteLine("");
      Console.WriteLine("BOOLAN");
      Console.WriteLine("-----");
      Console.WriteLine($"TRUE : {true.GetBoolString()}");
      Console.WriteLine($"FALSE : {false.GetBoolString()}");
      Console.WriteLine("y : {0}", "y".AsBoolean());
      Console.WriteLine("n : {0}", "n".AsBoolean());
      Console.WriteLine("non : {0}", "non".AsBoolean());
      Console.WriteLine("vrai : {0}", "vrai".AsBoolean());
      Console.WriteLine("faux : {0}", "faux".AsBoolean());
      Console.WriteLine("t : {0}", "t".AsBoolean());
      Console.WriteLine("1 : {0}", "1".AsBoolean());

      Console.WriteLine("");
      Console.WriteLine("NUMBER");
      Console.WriteLine("-----");
      Console.WriteLine(5.IsBetween(1, 10));
      Console.WriteLine(11.IsBetween(1, 10));

      Console.WriteLine("Appuyez sur une touche...");
      Console.ReadKey();
    }
  }

}
