using System;

namespace pwExtensionsLibrary
{
  public static class DateExtensions
  {

    /// <summary>
    /// Calculate age in year since a given date until today
    /// </summary>
    /// <param name="dateOfBirth">La date</param>
    /// <returns>Calculated age</returns>
    public static Int32 CalculateAge(this DateTime dateOfBirth)
    {
      return CalculateAge(dateOfBirth, System.DateTime.Today);
    }

    /// <summary>
    /// Calculate age in year since a given date until reference date
    /// </summary>
    /// <param name="dateOfBirth">La date</param>
    /// <param name="dateReference">Date de référence</param>
    /// <returns>Calculated age</returns>
    public static Int32 CalculateAge(this DateTime dateOfBirth, DateTime dateReference)
    {
      Int32 years = dateReference.Year - dateOfBirth.Year;

      if (dateReference.Month < dateOfBirth.Month || (dateReference.Month == dateOfBirth.Month && dateReference.Day < dateOfBirth.Day))
      {
        years -= 1;
      }

      return years;

    }

    /// <summary>
    /// Returns number of days in a month
    /// </summary>
    /// <param name="value">Th date</param>
    /// <returns>Number of days in a month</returns>
    public static Int32 GetCountDaysOfMonth(this DateTime value)
    {
      System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
      System.Globalization.Calendar calendar = dfi.Calendar;

      return calendar.GetDaysInMonth(value.Year, value.Month);
    }

    /// <summary>
    /// Returns the day number in the year
    /// </summary>
    /// <param name="value">The date</param>
    /// <returns>The day number in the year</returns>
    public static Int32 GetDayOfYear(this DateTime value)
    {
      System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
      System.Globalization.Calendar calendar = dfi.Calendar;

      return calendar.GetDayOfYear(value);
    }

    /// <summary>
    /// Returns first day of the month
    /// </summary>
    /// <param name="value">The date</param>
    /// <returns></returns>
    public static DateTime GetFirstDayOfMonth(this DateTime value)
    {
      return new System.DateTime(value.Year, value.Month, 1);
    }

    /// <summary>
    /// Returns last day of the month in DateTime format
    /// </summary>
    /// <param name="value">The date</param>
    /// <returns></returns>
    /// <url>https://www.extensionmethod.net/1644/csharp/datetime/getlastdayofmonth</url>
    public static DateTime GetLastDayOfMonth(this DateTime value)
    {
      System.DateTime nextMonth = value.AddMonths(1);

      return new System.DateTime(nextMonth.Year, nextMonth.Month, 1).AddDays(-1);
    }

    ///// <summary>
    ///// Gets the last the day of month.
    ///// </summary>
    ///// <param name="date">The date.</param>
    ///// <returns></returns>
    //public static DateTime LastDayOfMonth(this DateTime date)
    //{
    //  return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    //}

    /// <summary>
    /// Indicates if the specified date is the date of the day
    /// </summary>
    /// <param name="value">La date</param>
    /// <returns><c>true</c> si la date spécifiée est la date du jour, sinon <c>false</c>.</returns>
    public static bool IsToday(this DateTime value)
    {
      return value == DateTime.Today;
    }

    /// <summary>
    /// Indicates if the specified date is a weekend
    /// </summary>
    /// <param name="value">La date</param>
    /// <returns><c>true</c> si la date spécifiée est un weekend, sinon <c>false</c>.</returns>
    public static bool IsWeekend(this DateTime value)
    {
      return value.DayOfWeek == DayOfWeek.Saturday | value.DayOfWeek == DayOfWeek.Sunday;
    }


    /// <summary>
    /// Returns the week's number from the given date
    /// </summary>
    /// <param name="value">La date</param>
    /// <returns>Le n° de la semaine</returns>
    public static Int32 GetWeekOfYear(this DateTime value)
    {
      System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
      System.Globalization.Calendar calendar = dfi.Calendar;

      return calendar.GetWeekOfYear(value, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
    }

    /// <summary>
    /// Determines if the date is between two provided dates.
    /// </summary>
    /// <param name="date">The date</param>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="compareTime">if set to <c>true</c> [compare time].</param>
    /// <returns>
    ///   <c>true</c> if the specified start date is between; otherwise, <c>false</c>.
    /// </returns>
    /// <url>http://www.extensionmethod.net/2133/csharp/datetime/isbetween</url>
    public static Boolean IsBetween(this DateTime date, DateTime startDate, DateTime endDate, Boolean compareTime = false)
    {
      return compareTime ?
              date >= startDate && date <= endDate :
              date.Date >= startDate.Date && date.Date <= endDate.Date;
    }

    /// <summary>
    /// Sets the time on the specified DateTime value.
    /// </summary>
    /// <param name = "date">The base date.</param>
    /// <param name = "time">The TimeSpan to be applied.</param>
    /// <returns>
    /// The DateTime including the new time value
    /// </returns>
    public static DateTime SetTime(this DateTime date, TimeSpan time)
    {
      return date.Date.Add(time);
    }

    /// <summary>
    /// Sets the time on the specified DateTime value using the specified time zone.
    /// </summary>
    /// <param name = "date">The base date.</param>
    /// <param name = "time">The TimeSpan to be applied.</param>
    /// <param name = "localTimeZone">The local time zone.</param>
    /// <returns>/// The DateTimeOffset including the new time value/// </returns>
    public static DateTimeOffset SetTime(this DateTimeOffset date, TimeSpan time, TimeZoneInfo localTimeZone)
    {
      var localDate = date.ToLocalDateTime(localTimeZone);
      localDate.SetTime(time);
      return localDate.ToDateTimeOffset(localTimeZone);
    }

    /// <summary>
    /// Sets the time on the specified DateTimeOffset value using the local system time zone.
    /// </summary>
    /// <param name = "date">The base date.</param>
    /// <param name = "hours">The hours to be set.</param>
    /// <param name = "minutes">The minutes to be set.</param>
    /// <param name = "seconds">The seconds to be set.</param>
    /// <returns>The DateTimeOffset including the new time value</returns>
    public static DateTimeOffset SetTime(this DateTimeOffset date, int hours, int minutes, int seconds)
    {
      return date.SetTime(new TimeSpan(hours, minutes, seconds));
    }

    /// <summary>
    /// Converts a DateTime into a DateTimeOffset using the local system time zone.
    /// </summary>
    /// <param name = "localDateTime">The local DateTime.</param>
    /// <returns>The converted DateTimeOffset</returns>
    public static DateTimeOffset ToDateTimeOffset(this DateTime localDateTime)
    {
      return localDateTime.ToDateTimeOffset(null);
    }

    /// <summary>
    /// Converts a DateTime into a DateTimeOffset using the specified time zone.
    /// </summary>
    /// <param name = "localDateTime">The local DateTime.</param>
    /// <param name = "localTimeZone">The local time zone.</param>
    /// <returns>The converted DateTimeOffset</returns>
    public static DateTimeOffset ToDateTimeOffset(this DateTime localDateTime, TimeZoneInfo localTimeZone)
    {
      localTimeZone = (localTimeZone ?? TimeZoneInfo.Local);

      if (localDateTime.Kind != DateTimeKind.Unspecified)
        localDateTime = new DateTime(localDateTime.Ticks, DateTimeKind.Unspecified);

      return TimeZoneInfo.ConvertTimeToUtc(localDateTime, localTimeZone);
    }

    /// <summary>
    /// Sets the time on the specified DateTimeOffset value using the local system time zone.
    /// </summary>
    /// <param name = "date">The base date.</param>
    /// <param name = "time">The TimeSpan to be applied.</param>
    /// <returns>The DateTimeOffset including the new time value</returns>
    public static DateTimeOffset SetTime(this DateTimeOffset date, TimeSpan time)
    {
      return date.SetTime(time, null);
    }

    /// <summary>
    /// Converts a DateTimeOffset into a DateTime using the specified time zone.
    /// </summary>
    /// <param name = "dateTimeUtc">The base DateTimeOffset.</param>
    /// <param name = "localTimeZone">The time zone to be used for conversion.</param>
    /// <returns>The converted DateTime</returns>
    public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeUtc, TimeZoneInfo localTimeZone)
    {
      localTimeZone = (localTimeZone ?? TimeZoneInfo.Local);

      return TimeZoneInfo.ConvertTime(dateTimeUtc, localTimeZone).DateTime;
    }

  }
}
