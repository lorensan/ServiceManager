﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.ServicesController
{
    public class Services
    {
        public string ServiceName { get; set; }

        public ServiceControllerStatus ServiceStatus { get; set; }

    }
}
