# ExtensionsLibrary
Compilation of useful C# extension methods to boost productivity for the .net developers.<br>
Some of them come from other projects.

## Minimum requirements
Framework 4.5

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
