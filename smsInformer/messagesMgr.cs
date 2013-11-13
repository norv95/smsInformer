using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace smsInformer
{
    class messagesMgr
    {
        connProp dataSourceConnectionProp;
        Logger smsLogger = new Logger("c:\\temp\\smsServiceLog");

        private Boolean setDataSource(string serverName,string serverPort,string dbName,string dbTable,string login,string password)
        {
            dataSourceConnectionProp=new connProp(login,password,serverName,dbName);
            return true;
        }
        private Boolean checkDbConnection(ref SqlConnection connection)
        { 
            string connectionString = "Data Source=" + dataSourceConnectionProp.GetServerName() + ";Initial Catalog=" + dataSourceConnectionProp.GetDataBaseName()
                + ";Integrated Security=false;User=" + dataSourceConnectionProp.GetLogin() + ";Password=" + dataSourceConnectionProp.GetPassword();

            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch
            {
                //if (ShowConnectionError == true)
                //    MessageBox.Show("Невозможно подключиться к серверу: " + aServerName + " база данных: " + aDataBaseName);
            }

            if (connection.State != System.Data.ConnectionState.Open)
                return false;
            else
            {
                return true;
            }
        }

        protected List<Message> getMessagesToSend(ref SqlConnection connection)
        {
            List<Message> Messages = new List<Message>();
            SqlDataAdapter MessagesDA = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand GetMessages;
            GetMessages= connection.CreateCommand();

            GetMessages.CommandText = "Select uid, requestNum, phoneNum, messageText, messageSended, messageDelivered, status " +
                                      "FROM smsMessages"+
                                      "WHERE (status = " + Status.needSend + " OR (status = " + Status.sended + ")";

            MessageBox.Show(GetMessages.CommandText);

            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {
                MessagesDA.SelectCommand = GetMessages;
                MessagesDA.Fill(ds);
            }
            catch (Exception e)
            {
                smsLogger.logtofile("SQL Exeption " + e.Message);
                return null;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime sendDate;
                DateTime deliverDate;

                foreach (DataRow messageRow in ds.Tables[0].Rows)
                {
                    //DateTime.TryParseExact(messageRow["messageSended"], CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

                    DateTime.TryParse(messageRow["messageSended"].ToString(), out sendDate);
                    DateTime.TryParse(messageRow["messageDelivered"].ToString(), out deliverDate);

                    Message smsMessage = new Message((int)messageRow["uid"],
                                            messageRow["requestNum"].ToString(),
                                            messageRow["phoneNum"].ToString(),
                                            messageRow["messageText"].ToString(),
                                            sendDate,
                                            deliverDate,
                                            (Status)messageRow["status"]);

                    Messages.Add(smsMessage);
                }
            }
            else
                return null;

            return Messages;
        }
        public boolean runWorkingCycle()
        {

            return true;
        }
    }
}
