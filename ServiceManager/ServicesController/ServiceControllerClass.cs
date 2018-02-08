using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.ServicesController
{
    public static class ServiceControllerClass
    {

        #region ListServices
        
        public static List<Services> ListServices()
        {
            List<Services> servicesList = new List<Services>();
            ServiceController sc = new ServiceController();

            foreach (var service in ServiceController.GetServices())
            {
                servicesList.Add(new Services()
                {
                    ServiceName = service.ServiceName,
                    ServiceStatus = service.Status
                });
            }
            return servicesList;
        }

        public static List<Services> ListRunningServices()
        {
            List<Services> servicesList = new List<Services>();
            ServiceController sc = new ServiceController();

            foreach (var service in ServiceController.GetServices())
            {
                if(service.Status == ServiceControllerStatus.Running)
                servicesList.Add(new Services()
                {
                    ServiceName = service.ServiceName,
                    ServiceStatus = service.Status
                });
            }
            return servicesList;
        }

        public static List<Services> ListStoppedServices()
        {
            List<Services> servicesList = new List<Services>();
            ServiceController sc = new ServiceController();

            foreach (var service in ServiceController.GetServices())
            {
                if (service.Status == ServiceControllerStatus.Stopped)
                    servicesList.Add(new Services()
                    {
                        ServiceName = service.ServiceName,
                        ServiceStatus = service.Status
                    });
            }
            return servicesList;
        }
        
        #endregion

        public static void StopServices(string service)
        {
            ServiceController sc;
            sc = new ServiceController(service);
            sc.Stop();
        }

        public static void StartServices(string service)
        {
            ServiceController sc;
            sc = new ServiceController(service);
            sc.Start();
            
        }

        public static List<ServiceController> SearchServices(List<string> containsName, List<ServiceController> servicesList)
        {
            List<ServiceController> resultList = new List<ServiceController>();

            foreach (string toSearch in containsName)
            {
                foreach (var serviceName in servicesList)
                {
                    if (serviceName.ServiceName.Contains(toSearch))
                    {
                        if (!resultList.Contains(serviceName))
                            resultList.Add(serviceName);
                    }
                }
            }
            return servicesList;
        }
    }
}
