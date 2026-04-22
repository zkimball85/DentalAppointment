using System.Text.RegularExpressions;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace DentalAppointment;

// Main form for scheduling dental appointments.
// Handles UI initialization, input validation and persistence of appointments to a JSON file.
public partial class Form1 : Form
{
    // Constructor: initialize components and wire event handlers.
    public Form1()
    {
        // Populate combo boxes and configure controls on load
        InitializeComponent();
        Load += Form1_Load;

        // Handle confirmation click
        btnConfirm.Click += BtnConfirm_Click; 
    }

    // Form load event: populate selection lists and configure the appointment picker.
    private void Form1_Load(object? sender, EventArgs e)
    {
        // Add a small set of example doctors and office locations. Replace with data source as needed.
        cboDoctor.Items.AddRange(new[] { "Dr. Smith", "Dr. Johnson", "Dr. Lee" });
        cboOfficeLocation.Items.AddRange(new[] { "Main Office", "West Branch", "East Branch" });

        // Select the first item if available to provide a sensible default.
        if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;
        if (cboOfficeLocation.Items.Count > 0) cboOfficeLocation.SelectedIndex = 0;

        // Configure the date/time picker: custom format and prevent selecting past dates.
        dtpAppointment.Format = DateTimePickerFormat.Custom;
        dtpAppointment.CustomFormat = "MMMM dd, yyyy - h:mm tt";
        dtpAppointment.MinDate = DateTime.Now;
    }

    // Confirm button click: validate input, create an Appointment object and persist it to a JSON file.
    // Help was received from ChatGPT to implement this method.
    private async void BtnConfirm_Click(object? sender, EventArgs e)
    {
        var errors = new List<string>();

        // Read and trim user input
        var fullName = txtFullName.Text.Trim();
        var phone = txtPhoneNumber.Text.Trim();
        var reason = txtReason.Text.Trim();

        // Basic validations
        if (string.IsNullOrWhiteSpace(fullName))
            errors.Add("Full name is required.");

        if (!IsValidPhone(phone))
            errors.Add("Phone number is invalid. Use formats like (123) 456-7890 or 123-4567.");

        if (cboDoctor.SelectedItem is null)
            errors.Add("Please select a doctor.");

        if (cboOfficeLocation.SelectedItem is null)
            errors.Add("Please select an office location.");

        if (dtpAppointment.Value < DateTime.Now)
            errors.Add("Appointment date/time must be in the future.");

        // If any validation errors were found, show a message and abort saving
        if (errors.Count > 0)
        {
            MessageBox.Show(string.Join("\n", errors), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Build the appointment model from the form values
        var appointment = new Appointment
        {
            FullName = fullName,
            PhoneNumber = phone,
            Doctor = cboDoctor.SelectedItem!.ToString()!,
            AppointmentDate = dtpAppointment.Value,
            OfficeLocation = cboOfficeLocation.SelectedItem!.ToString()!,
            Reason = reason
        };

        try
        {
            // Persist appointments into a JSON array stored next to the application binary.
            // Used ChatGPT to implement file handling and JSON serialization logic.
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appointments.json");
            List<Appointment> list = new();

            // If file exists, try to load existing appointments. If parsing fails, start fresh.
            // Used ChatGPT to implement robust file reading and error handling logic.
            if (File.Exists(path))
            {
                try
                {
                    var existing = await File.ReadAllTextAsync(path);
                    var deserialized = JsonSerializer.Deserialize<List<Appointment>>(existing);
                    if (deserialized is not null) list = deserialized;
                }
                catch
                {
                    // If deserialization fails, continue with an empty list
                }
            }

            list.Add(appointment);
            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(path, json);

            MessageBox.Show("Appointment confirmed and saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form fields to defaults after successful save
            txtFullName.Clear();
            txtPhoneNumber.Clear();
            txtReason.Clear();
            dtpAppointment.Value = DateTime.Now;
            if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;
            if (cboOfficeLocation.Items.Count > 0) cboOfficeLocation.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            // Show a user-friendly error if saving fails
            MessageBox.Show($"Failed to save appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Validate common US-style phone number formats.
    // Accepts 7-digit (xxx-xxxx) or 10-digit (with area code) variants.
    private bool IsValidPhone(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;

        // Extract digits only to allow flexible input like (123) 456-7890 or 123.456.7890
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

        // Return true if any pattern matches the raw input string
        return patterns.Any(p => Regex.IsMatch(phoneNumber, p));
    }

    // Simple DTO used to serialize appointment data to JSON.
    private sealed class Appointment
    {
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Doctor { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string OfficeLocation { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
