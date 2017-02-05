using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Web;

namespace TaxManager
{
    public class TaxManagerWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public TaxManagerWindowsService()
        {
            ServiceName = "TaxManagerWindowsService";
        }

        public static void Main()
        {
            ServiceBase.Run(new TaxManagerWindowsService());
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(TaxManagerService));

            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}