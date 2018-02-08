using ServiceManager.ServicesController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManager.Forms
{
    public partial class ServiceManager : Form
    {
        public ServiceManager()
        {
            InitializeComponent();textBox1.Focus();
        }

        private void ServiceManager_Load(object sender, EventArgs e)
        {
            serviceGrid.DataSource=ServiceControllerClass.ListServices();
            
            BuildGrid();
        }

        private void UpdateTable()
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1_KeyUp(null, null);
            }
            else
            {
                if (radioButton1.Checked)
                {
                    radioButton1_CheckedChanged(null, null);
                }
                else if (radioButton2.Checked)
                {
                    radioButton2_CheckedChanged(null, null);
                }
                else if (radioButton3.Checked)
                {
                    radioButton3_CheckedChanged(null, null);
                }
            }
        }

        private void FilterByString(string sr)
        {
            List<Services> allservices = ServiceControllerClass.ListServices();
            List<Services> auxList = new List<Services>();

            foreach (Services serv in allservices)
            {
                    if(serv.ServiceName.IndexOf(sr, StringComparison.OrdinalIgnoreCase) >= 0)
                    auxList.Add(serv);
            }
            serviceGrid.DataSource = auxList;
            BuildGrid();
        }

        private void BuildGrid()
        {
            //Building Grid
            serviceGrid.Columns[0].MinimumWidth = 590;

            foreach (DataGridViewRow rowp in serviceGrid.Rows)
            {
                int kia = rowp.Index;

                if (rowp.Cells[1].Value.ToString() == "Running")
                {
                    //serviceGrid.Rows[rowp.Index].DefaultCellStyle.BackColor = Color.Green;
                    serviceGrid.Rows[rowp.Index].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    //serviceGrid.Rows[rowp.Index].DefaultCellStyle.BackColor = Color.FromArgb(255, 86, 83);
                    serviceGrid.Rows[rowp.Index].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// Refrescar ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serviceGrid_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ServiceControllerClass.ListServices();
                BuildGrid();
            }
        }

        /// <summary>
        /// Arrancar servicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<string> servicesToStart = new List<string>();
            foreach (DataGridViewRow  row in serviceGrid.SelectedRows)
            {
                if (row.Cells[1].Value.ToString() != "Running")
                {
                    servicesToStart.Add(row.Cells[0].Value.ToString());
                }
            }
            foreach (string service in servicesToStart)
            {
                logBox.Items.Add("STARTING: " + service);
                ServiceControllerClass.StartServices(service);
            }
        }

        /// <summary>
        /// Parar servicios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<string> servicesToStop = new List<string>();
            foreach (DataGridViewRow row in serviceGrid.SelectedRows)
            {
                if (row.Cells[1].Value.ToString() != "Stopped")
                {
                    servicesToStop.Add(row.Cells[0].Value.ToString());
                }
            }
            foreach(string service in servicesToStop)
            {
                logBox.Items.Add("STOPPING: " + service);
                ServiceControllerClass.StopServices(service);
            }
        }

        /// <summary>
        /// Show running Services
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            logBox.Items.Add("FILTER: Runnings services selected.");
            serviceGrid.DataSource = ServiceControllerClass.ListRunningServices();
            BuildGrid();
        }

        /// <summary>
        /// Show stopped services
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            logBox.Items.Add("FILTER: Stopped services selected.");
            serviceGrid.DataSource = ServiceControllerClass.ListStoppedServices();
            BuildGrid();
        }
        /// <summary>
        /// Show all services
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            logBox.Items.Add("FILTER: All services selected.");
            serviceGrid.DataSource = ServiceControllerClass.ListServices();
            BuildGrid();
        }

        /// <summary>
        /// Press key in textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (!String.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                FilterByString(textBox1.Text);
            }
        }

        private void ServiceManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                UpdateTable();
            }
        }

        private void ServiceManager_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateTable();
        }
    }
}
