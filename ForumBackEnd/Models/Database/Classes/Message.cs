using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ForumBackEnd.Models.Database.Queries;
using ForumBackEnd.Models.Utilities;

namespace ForumBackEnd.Models.Database.Classes
{
    public class Message
    {
        private int messageId;
        private User sendingUserId;
        private User receiverUserId;
        private List<Attachment> attachmentId;
        public string topic;
        public string content;
        public DateTime postDate;
        public DateTime dateOfReceipt;

        public Message(int messageId)
        {
           DataSet MessageDataSet=new DataSet();
           SqlCommand command=new SqlCommand(MessageQueries.SearchMessageId);
           command.Parameters.AddWithValue("@Message",MessageId);
           MessageDataSet=DBManager.ExecuteCommand(command);
           DataRow MessageDataRow=MessageDataSet.Tables[0].Rows[0];
           MessageBuilder(MessageDataRow);
        }
        private void MessageBuilder(DataRow dataRow)
        {
            sendingUserId  = DBManager.GetValue(dataRow["sendingUserId"]       ,null);
            receiverUserId = DBManager.GetValue(dataRow["receiverUserId"]      ,null);
            topic          = DBManager.GetValue(dataRow["topic"]               ,"INCORRECT VALUE");
            content        = DBManager.GetValue(dataRow["content"]             ,"INCORRECT VALUE");
            postDate       = DBManager.GetValue(dataRow["postDate"]            ,DateTime.Now);
            dateOfReceipt  = DBManager.GetValue(dataRow["dateOfReceipt"]       ,DateTime.Now);
            attachmentId   = DBManager.GetValue(dataRow["attachmentId"]        ,null);
        }
    }
}