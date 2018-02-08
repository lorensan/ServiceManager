using ServiceManager.ServicesController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceControllerClass scc = new ServiceControllerClass();
            //scc.ListServices();
            //scc.StopServices(new List<string>());
            //ServiceManager.Forms.ServiceManager sc = new Forms.ServiceManager();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServiceManager.Forms.ServiceManager());
        }
    }
}
