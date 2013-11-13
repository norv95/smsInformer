using System;
using System.ServiceProcess;
using System.Diagnostics;
using System.Text;

namespace smsInformer
{
    class smsInformer : ServiceBase
    {
        messagesMgr msgMgr = new messagesMgr();
        public smsInformer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.EventLog.WriteEntry("smsInformer has Started");

            System.Threading.Timer CheckTimer = new System.Threading.Timer(sendSms, null, 1000, 1000);
        }

        protected override void OnStop()
        {
            this.EventLog.WriteEntry("smsInformer has Stoped");
        }

        private void InitializeComponent()
        {
            this.ServiceName = "smsInformer";
            this.CanStop = true;
            this.AutoLog = false;
            this.EventLog.Log = "Application";
            this.EventLog.Source = "smsInformer";
        }

        private void sendSms(object state)
        {
            if (msgMgr.runWorkingCycle()==false)
                this.EventLog.WriteEntry('msgMgr working cycle FAILED');
        }
    }
}
