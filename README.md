# DentalAppointment

DentalAppointment is a Windows desktop app built with **C#** and **WinForms** on **.NET 10** for creating and managing dental appointments. All appointment data is stored **locally** in an **XML file**, so the app works offline and does not require a server.

## Features

- Create new appointments (patient + date/time + notes)
- Edit/reschedule appointments
- Offline-first: stores data locally in XML

## Requirements

- Windows 10/11
- **.NET SDK 10** (to build/run from source)
- (Recommended) Visual Studio 2022 (or later) with the **.NET desktop development** workload

## Getting Started

### Clone

```bash
git clone https://github.com/zkimball85/DentalAppointment.git
cd DentalAppointment
```

### Build and Run (Visual Studio)

1. Open the solution (`.sln`) in Visual Studio
2. Set the startup project (if prompted)
3. Press **F5** (Run) or **Ctrl+F5** (Run without debugging)

### Build and Run (CLI)

From the repository root (or the project directory that contains the `.csproj`):

```bash
dotnet restore
dotnet build
dotnet run
```

## Local Data Storage (XML)

Appointments are persisted to an XML file on the local machine.

- Format: XML
- File location: **(fill in exact path)**  
  Examples:
  - `%APPDATA%\DentalAppointment\appointments.xml`
  - `%LOCALAPPDATA%\DentalAppointment\appointments.xml`
  - Next to the executable (not recommended if installed under `Program Files`)

### Resetting data

To clear all saved appointments, close the app and delete the XML file at the location above. The app will recreate it on next launch (if implemented).

## Usage

1. Launch the app
2. Add an appointment:
   - Patient name
   - Appointment date/time
   - Notes / reason (optional)
3. View upcoming appointments
4. Edit or remove appointments as needed

## Roadmap / Ideas

- Conflict detection (prevent overlapping appointments)
- Export schedule to CSV
- Print-friendly daily schedule view
- Basic reminders (Windows notifications)

## Contributing

1. Fork the repo
2. Create a branch: `git checkout -b feature/my-change`
3. Commit changes: `git commit -m "Describe change"`
4. Push and open a pull request

## Screenshots
<img width="390" height="328" alt="Screen Shot 2026-04-22 at 13 44 18 PM" src="https://github.com/user-attachments/assets/6f95d432-8a28-4c01-83d3-2d8ee65f6fc4" />

