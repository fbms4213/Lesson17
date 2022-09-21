using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Lesson17_Regex;


// Regex
// Log
// Reflection
// Attribute
// {static} Local function
// Ildasm
// Questions



#nullable disable

class Program
{
    static void Main()
    {
        string pattern = @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$";
        string text = "";

        // Regex regex = new Regex(pattern);
        // Console.WriteLine(regex.IsMatch(text));



        MailAddress mailAddress = new MailAddress(text);
    }
}