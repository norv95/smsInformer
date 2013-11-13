using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace smsInformer
{
    static class Program  
    {
        [STAThread]
        static void Main()
        {
            System.ServiceProcess.ServiceBase.Run(new smsInformer());
        }
    }
}
