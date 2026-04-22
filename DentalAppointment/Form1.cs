using System.Text.RegularExpressions;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace DentalAppointment;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Load += Form1_Load;
        btnConfirm.Click += BtnConfirm_Click;
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        // Populate doctors and office locations
        cboDoctor.Items.AddRange(new[] { "Dr. Smith", "Dr. Johnson", "Dr. Lee" });
        cboOfficeLocation.Items.AddRange(new[] { "Main Office", "West Branch", "East Branch" });

        if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;
        if (cboOfficeLocation.Items.Count > 0) cboOfficeLocation.SelectedIndex = 0;

        // Configure appointment date/time
        dtpAppointment.Format = DateTimePickerFormat.Custom;
        dtpAppointment.CustomFormat = "MMMM dd, yyyy - h:mm tt";
        dtpAppointment.MinDate = DateTime.Now;
    }

    private async void BtnConfirm_Click(object? sender, EventArgs e)
    {
        var errors = new List<string>();

        var fullName = txtFullName.Text.Trim();
        var phone = txtPhoneNumber.Text.Trim();
        var reason = txtReason.Text.Trim();

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

        if (errors.Count > 0)
        {
            MessageBox.Show(string.Join("\n", errors), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

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
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appointments.json");
            List<Appointment> list = new();

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

            // Reset form
            txtFullName.Clear();
            txtPhoneNumber.Clear();
            txtReason.Clear();
            dtpAppointment.Value = DateTime.Now;
            if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;
            if (cboOfficeLocation.Items.Count > 0) cboOfficeLocation.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to save appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
