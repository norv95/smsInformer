using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsInformer
{
    class connProp
    {
        private string Login;
        private string Password;
        private string ServerName;
        private string DataBaseName;
        private string ConnectionString;
        public bool Opened;

        public connProp()
        {
            Login = "";
            Password = "";
            ServerName = "";
            DataBaseName = "";
            ConnectionString = "";
        }
        public connProp(string aLogin, string aPassword, string aServerName, string aDataBaseName)
        {
            Login = aLogin;/*Имя пользователя*/
            Password = aPassword;
            ServerName = aServerName;
            DataBaseName = aDataBaseName;
            ConnectionString = "Data Source=" + aServerName + ";Initial Catalog=" + aDataBaseName + ";Integrated Security=false;User=" + aLogin + ";Password=" + aPassword;
        }
        public bool SetConnProp(string aLogin, string aPassword, string aServerName, string aDataBaseName)
        {
            Login = aLogin;/*Имя пользователя*/
            Password = aPassword;
            ServerName = aServerName;
            DataBaseName = aDataBaseName;
            ConnectionString = "Data Source=" + aServerName + ";Initial Catalog=" + aDataBaseName + ";Integrated Security=false;User=" + aLogin + ";Password=" + aPassword;
            return true;
        }

        public bool IsAllMemberExist()
        {
            if (Login == null || Login == "" || Password == null || Password == "" ||
                ServerName == null || ServerName == "" || DataBaseName == null || DataBaseName == "" ||
                ConnectionString == null || ConnectionString == "")
                return false;
            else
                return true;
        }
        public string GetLogin()
        { return Login; }
        public string GetPassword()
        { return Password; }
        public string GetServerName()
        { return ServerName; }
        public string GetDataBaseName()
        { return DataBaseName; }
        public string GetConnectionString()
        { return ConnectionString; }
    }
}
