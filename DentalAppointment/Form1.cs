using System.Text.RegularExpressions;

namespace DentalAppointment;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private bool IsValidPhone(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;

        // Extract digits
        string digits = new string(phoneNumber.Where(char.IsDigit).ToArray());

        // Must be 7 digits (no area code) or 10 digits (with area code)
        if (digits.Length != 7 && digits.Length != 10)
            return false;

        // Regex patterns for allowed formats
        string[] patterns =
        {
            // 10-digit formats
            @"^\d{3}\.\d{3}\.\d{4}$",
            @"^\(\d{3}\)\s?\d{3}[- ]?\d{4}$",
            @"^\d{10}$",

            // 7-digit formats (area code optional)
            @"^\d{3}[- .]?\d{4}$"
        };

        // Check if the input matches any of the allowed patterns returns true if it does, otherwise false
        return patterns.Any(p => Regex.IsMatch(phoneNumber, p));
    }
}
