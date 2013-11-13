using System;
using System.ServiceProcess;
using System.ComponentModel;
using System.Configuration.Install;

namespace smsInformer
{
    [RunInstaller(true)]
    public class smsInformerInstaller : Installer
    {
        private ServiceProcessInstaller smsInfromerServiceProcessInstaller;
        private ServiceInstaller smsInfromerServiceInstaller;

        public smsInformerInstaller()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.smsInfromerServiceProcessInstaller = new ServiceProcessInstaller();
            this.smsInfromerServiceProcessInstaller.Account = ServiceAccount.LocalSystem;
            this.smsInfromerServiceProcessInstaller.Username = null;
            this.smsInfromerServiceProcessInstaller.Password = null;
            this.smsInfromerServiceInstaller = new ServiceInstaller();
            this.smsInfromerServiceInstaller.Description = "smsInformer Service Template";
            this.smsInfromerServiceInstaller.DisplayName = "smsInformer Service";
            this.smsInfromerServiceInstaller.ServiceName = "smsInformer";
            this.smsInfromerServiceInstaller.StartType = ServiceStartMode.Manual;
            this.Installers.AddRange(new Installer[] { this.smsInfromerServiceProcessInstaller, this.smsInfromerServiceInstaller});
        }
    }
}
