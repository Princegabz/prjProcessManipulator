using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjProcessManipulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ListAllProcesses();

        }

        public void ListAllProcesses()
        {
            lbListProcess.Items.Clear();
            Process[] ProcessesList = Process.GetProcesses();

            foreach (var pr in ProcessesList)
            {
                lbListProcess.Items.Add(pr.ProcessName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
