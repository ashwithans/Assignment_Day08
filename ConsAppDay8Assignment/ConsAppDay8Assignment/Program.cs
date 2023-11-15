using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter a piece of text:");
            string inputText = Console.ReadLine();

            int wordCount = CountWords(inputText);
            Console.WriteLine($"Word Count: {wordCount}");

            Console.Write("Enter your email address: ");
            string emailAddress = Console.ReadLine();

            if (ValidateEmailAddress(emailAddress))
            {
                Console.WriteLine("Email Address: " + emailAddress);
            }
            else
            {
                Console.WriteLine("Invalid Email Address");
            }

            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();

            string extractedPhoneNumber = ExtractMobileNumber(phoneNumber);
            if (extractedPhoneNumber != null)
            {
                Console.WriteLine("Phone Number: " + extractedPhoneNumber);
            }
            else
            {
                Console.WriteLine("Invalid Phone Number");
            }

            Console.Write("Enter a custom regular expression: ");
            string customRegexPattern = Console.ReadLine();

            string[] customRegexMatches = PerformCustomRegexSearch(inputText, customRegexPattern);
            Console.WriteLine("Custom Regex Search Results:");
            foreach (var match in customRegexMatches)
            {
                Console.WriteLine(match);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static int CountWords(string text)
    {
        string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    static bool ValidateEmailAddress(string emailAddress)
    {
        var emailRegex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
        return emailRegex.IsMatch(emailAddress);
    }

    static string ExtractMobileNumber(string text)
    {
        var mobileRegex = new Regex(@"\b\d{10}\b");
        var match = mobileRegex.Match(text);

        return match.Success ? match.Value : null;
    }

    static string[] PerformCustomRegexSearch(string text, string pattern)
    {
        var customRegex = new Regex(pattern);
        var matches = customRegex.Matches(text);

        string[] customRegexMatches = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            customRegexMatches[i] = matches[i].Value;
        }

        return customRegexMatches;
    }
}
