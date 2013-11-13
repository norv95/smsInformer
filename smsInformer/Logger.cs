using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace smsInformer
{
    class Logger
    {
        private string logFileName;
        private TextWriter writer;
        
        public Logger(string filename)
        {
            this.logFileName = filename;

            TextWriter w = File.AppendText(this.logFileName);
        }

        public bool logtofile(string logMessage)
        {
            writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            writer.WriteLine("  :");
            writer.WriteLine("  :{0}", logMessage);
            return true;
        }
        
    }
}
