# Process Manipulator Application

## Overview
The **prjProcessManipulator** application is a simple Windows Forms application designed to list, start, and stop system processes. It provides an interface where users can view currently running processes, start new processes by name, and terminate existing ones.

## Features
- **List all running processes**: Displays a list of active processes on the system.
- **Start a new process**: Allows the user to start a process by providing the process name.
- **Stop an existing process**: Terminates a process by its name.

## Components
- **Form1.cs**: The main form that hosts the interface and the core logic.
- **lbListProcess**: A ListBox that displays the running processes.
- **txtProcess**: A TextBox where the user enters the process name to start or stop.
- **cmbOperation**: A ComboBox where the user selects the operation (Start/Stop).
- **btnExecute**: A Button to execute the selected operation.

## Code Breakdown

### Form1 Constructor
```csharp
public Form1()
{
    InitializeComponent();
    ListAllProcesses();
}
```
Initializes the form and calls the `ListAllProcesses()` method to populate the process list on startup.

### ListAllProcesses Method
```csharp
public void ListAllProcesses()
{
    lbListProcess.Items.Clear();
    Process[] ProcessesList = Process.GetProcesses();

    foreach (var pr in ProcessesList)
    {
        lbListProcess.Items.Add(pr.ProcessName);
    }
}
```
Fetches all active processes using `Process.GetProcesses()` and displays their names in the list box.

### btnExecute_Click Event
```csharp
private void btnExecute_Click(object sender, EventArgs e)
{
    Process process = new Process();
    process.StartInfo.FileName = txtProcess.Text;

    if (cmbOperation.SelectedItem.ToString().Contains("Start"))
    {
        lbListProcess.Items.Add("Start was selected");
        process.Start();
    }
    else if (cmbOperation.SelectedItem.ToString().Contains("Stop"))
    {
        foreach (var proc in Process.GetProcessesByName(txtProcess.Text))
        {
            proc.Kill();
        }
    }

    ListAllProcesses();
}
```
Executes the user’s selected operation:
- **Start**: Adds a message to the list and starts the process entered in `txtProcess`.
- **Stop**: Finds and kills processes by the name provided in `txtProcess`.

## How to Use
1. **View running processes:** Launch the application to automatically see active processes.
2. **Start a process:** Enter the name of the executable (e.g., `notepad.exe`) in the text box, select `Start`, and click `Execute`.
3. **Stop a process:** Enter the process name (without the `.exe` extension), select `Stop`, and click `Execute`.

## Potential Improvements
- **Error Handling:** Add more specific error handling for missing processes or incorrect input.
- **UI Enhancements:** Display process details like ID and memory usage.
- **Process Filtering:** Add search or filter functionality for large process lists.
- **Confirmation Prompts:** Ask for confirmation before stopping critical processes.

## Requirements
- **.NET Framework**
- **Windows OS**

## Disclaimer
Use caution when stopping processes, as terminating critical system processes can affect system stability.

