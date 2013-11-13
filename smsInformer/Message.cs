using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsInformer
{
    enum Status : byte { needSend = 1, sended = 2, delivered = 3, sendAttemptsExhaust = 4 };
    class Message
    {
        int uid;
        string requestNum;
        string phoneNum;
        string messageText;
        DateTime messageSended;
        DateTime messageDelivered;
        Status status;

        public Message(int uid, string requestNum, string phoneNum, string messageText, DateTime messageSended, DateTime messageDelivered, Status status)
        {
            this.uid = uid;
            this.requestNum = requestNum;
            this.phoneNum = phoneNum;
            this.messageText = messageText;
            this.messageSended = messageSended;
            this.messageDelivered=messageDelivered;
            this.status=status;
        }
    }
}
