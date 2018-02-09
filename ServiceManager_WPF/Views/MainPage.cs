using ServiceManager_WPF.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ServiceManager_WPF.Views
{
    public partial class MainPage : UserControl
    {
        #region Complementary Function
        private void FilterByString(string sr)
        {
            List<Services> allservices = ServiceControllerClass.ListServices();
            List<Services> auxList = new List<Services>();

            foreach (Services serv in allservices)
            {
                if (serv.ServiceName.IndexOf(sr, StringComparison.OrdinalIgnoreCase) >= 0)
                    auxList.Add(serv);
            }
            serviceGrid.DataContext = auxList;
            BuildGrid();
        }

        private void BuildGrid()
        {
            ////Building Grid
            //serviceGrid.Columns[0].MinimumWidth = 590;

            //foreach (DataGridViewRow rowp in serviceGrid.Rows)
            //{
            //    int kia = rowp.Index;

            //    if (rowp.Cells[1].Value.ToString() == "Running")
            //    {
            //        //serviceGrid.Rows[rowp.Index].DefaultCellStyle.BackColor = Color.Green;
            //        serviceGrid.Rows[rowp.Index].DefaultCellStyle.ForeColor = Color.Black;
            //    }
            //    else
            //    {
            //        //serviceGrid.Rows[rowp.Index].DefaultCellStyle.BackColor = Color.FromArgb(255, 86, 83);
            //        serviceGrid.Rows[rowp.Index].DefaultCellStyle.ForeColor = Color.Red;
            //    }
            //}
        }
        #endregion
    }
}
