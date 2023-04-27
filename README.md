# ExtensionsLibrary
Compilation of useful C# extension methods to boost productivity for the .net developers.<br>
Some of them come from other projects/developers.

## Minimum requirements
Framework 4.5

## History
Version 1.0.1 27/04/2023
Added some extensions

Version 1.0.0 30/09/22019
First version

## List extensions for objects/data type
- Boolean
- Comparable
- Converter
- DataGridView
- Date
- DirectoryInfo
- Enumerable
- Object
- String

## List extensions for Boolean
- GetBoolString(this bool value) : returns "Yes" or "No"

## List extensions for Comparable
- IsBetween(this T value, T minValue, T maxValue)
- IsBetween(this T value, T minValue, T maxValue, , IComparer comparer)

## List extensions for DataGridView
- DoubleBuffered(this DataGridView dgv, bool setting) : Prevents DataGridView from flickering

## List extensions for Date
- CalculateAge(this DateTime dateOfBirth) : Calculate age in year since a given date until today
- CalculateAge(this DateTime dateOfBirth, DateTime dateReference) : Calculate age in year since a given date until reference date
- GetCountDaysOfMonth(this DateTime value) : Returns number of days in a month
- GetDayOfYear(this DateTime value) : Returns the day number in the year
- GetFirstDayOfMonth(this DateTime value) : Returns first day of the month
- GetLastDayOfMonth(this DateTime value) : Returns last day of the month in DateTime format
- IsToday(this DateTime value) : Indicates if the specified date is the date of the day
- IsWeekend(this DateTime value) : Indicates if the specified date is a weekend
- GetWeekOfYear(this DateTime value) : Returns the week's number from the given date
- IsBetween(this DateTime date, DateTime startDate, DateTime endDate, Boolean compareTime = false) : Determines if the date is between two provided dates.
- SetTime(this DateTime date, TimeSpan time) : Sets the time on the specified DateTime value.
- SetTime(this DateTimeOffset date, TimeSpan time, TimeZoneInfo localTimeZone) : Sets the time on the specified DateTime value using the specified time zone.
- SetTime(this DateTimeOffset date, int hours, int minutes, int seconds) : Sets the time on the specified DateTimeOffset value using the local system time zone.
- ToDateTimeOffset(this DateTime localDateTime) : Converts a DateTime into a DateTimeOffset using the local system time zone.
- ToDateTimeOffset(this DateTime localDateTime, TimeZoneInfo localTimeZone) : Converts a DateTime into a DateTimeOffset using the specified time zone.
- SetTime(this DateTimeOffset date, TimeSpan time) : Sets the time on the specified DateTimeOffest value using the local system time zone.
- ToLocalDateTime(this DateTimeOffset dateTimeUtc, TimeZoneInfo localTimeZone) : Converts a DateTimeOffset into a DateTime using the specified time zone.

## List extensions for DirectoryInfo
- GetFiles(this DirectoryInfo directory, params string[] patterns) : Gets all files in the directory matching one of the several (!) supplied patterns (instead of just one in the regular implementation).
- FindFileRecursive(this DirectoryInfo directory, string pattern) : Searches the provided directory recursively and returns the first file matching the provided pattern.
- FindFileRecursive(this DirectoryInfo directory, Func<FileInfo, bool> predicate) : Searches the provided directory recursively and returns the first file matching to the provided predicate.
- FindFilesRecursive(this DirectoryInfo directory, string pattern) : Searches the provided directory recursively and returns the all files matching the provided pattern.
- FindFilesRecursive(this DirectoryInfo directory, Func<FileInfo, bool> predicate) : Searches the provided directory recursively and returns the all files matching to the provided predicate.
- CopyTo(this DirectoryInfo sourceDirectory, string targetDirectoryPath) : Copies the entire directory to another one
- CopyTo(this DirectoryInfo sourceDirectory, DirectoryInfo targetDirectory) : Copies the entire directory to another one



## Sample usage
#### Strings
```C#
"SafeSubstring".SafeSubstring(0, 5); // returns "SafeS"
"SafeSubstring".SafeSubstring(0, 50); // returns "SafeSubstring"
"SafeSubstring".SafeSubstring(20, 5); // returns empty string

// Check email validity
"john.doe@gmail@com".IsValidEmailAddress(); // return false;
"john.doe@gmail".IsValidEmailAddress(); // return false;
"john.doe@gmail@com".IsValidEmailAddress(); // return true;

// Limit text length
"The quick brown fox jumps over the lazy dog".LimitTextLength(20, false); // returns "The quick brown fox"
"The quick brown fox jumps over the lazy dog".LimitTextLength(20, true); // returns "The quick brown f..."
```

