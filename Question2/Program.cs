using System;

class Program
{
    static void Main(string[] args)
    {
        // Input string to test the methods
        string inputString = "xyxyxy Hello World xyxy";

        // Test the methods
        Console.WriteLine(CountXYCharacters(inputString));
        Console.WriteLine(Alternate3Characters(inputString));
        Console.WriteLine(StartsWithNumeric(inputString));
        Console.WriteLine(InsertHyphens(inputString));
        Console.WriteLine(StripSpecialCharacters(inputString));
        Console.WriteLine(EndsWithCom(inputString));
    }

    // This method returns the number of times 'x' or 'y' appears in a string
    // Input: a string called "inputString"
    // Output: an integer representing the count of 'x' and 'y' characters
    public static int CountXYCharacters(string inputString)
    {
        int count = 0;

        // Loop through each character in the string
        for (int i = 0; i < inputString.Length; i++)
        {
            // If the current character is 'x' or 'y', increment the count
            if (inputString[i] == 'x' || inputString[i] == 'y')
            {
                count++;
            }
        }

        return count;
    }

    // This method returns a new string made up of every alternate 3 characters
    // Input: a string called "inputString"
    // Output: a new string made up of every alternate 3 characters
    public static string Alternate3Characters(string inputString)
    {
        string result = "";

        // Loop through each group of 3 characters in the string
        for (int i = 0; i < inputString.Length; i += 6)
        {
            // Add the first character of the group to the result
            result += inputString[i];

            // If the second character of the group exists, add it to the result
            if (i + 2 < inputString.Length)
            {
                result += inputString[i + 2];
            }

            // If the third character of the group exists, add it to the result
            if (i + 4 < inputString.Length)
            {
                result += inputString[i + 4];
            }
        }

        return result;
    }

    // This method returns true if the string starts with a numeric character
    // Input: a string called "inputString"
    // Output: a boolean indicating whether the string starts with a numeric character
    public static bool StartsWithNumeric(string inputString)
    {
        // Check if the first character is a numeric character
        return Char.IsDigit(inputString[0]);
    }

    // This method returns a new string with a '-' inserted after every third character
    // Input: a string called "inputString"
    // Output: a new string with '-' inserted after every third character
    public static string InsertHyphens(string inputString)
    {
        string result = "";

        // Loop through each character in the string
        for (int i = 0; i < inputString.Length; i++)
        {
            // If this is the third, sixth, ninth, etc. character, add a hyphen to the result
            if (i > 0 && (i + 1) % 3 == 0)
            {
                result += '-';
            }

            // Add the current character to the result
            result += inputString[i];
        }

        return result;
    }

    // This method returns a new string with special characters removed
    // Input: a string called "inputString"
    // Output:
    public static string StripSpecialCharacters(string inputString)
    {
        string result = "";

        // Loop through each character in the string
        for (int i = 0; i < inputString.Length; i++)
        {
            // If the current character is not a special character, add it to the result
            if (inputString[i] != '$' && inputString[i] != '%' && inputString[i] != ',' && inputString[i] != ' ')
            {
                result += inputString[i];
            }
        }

        return result;
    }

    // This method returns true if the string ends with ".com"
    // Input: a string called "inputString"
    // Output: a boolean indicating whether the string ends with ".com"
    public static bool EndsWithCom(string inputString)
    {
        // Check if the last four characters of the string are ".com"
        return inputString.Length >= 4 && inputString.Substring(inputString.Length - 4) == ".com";
    }
}
