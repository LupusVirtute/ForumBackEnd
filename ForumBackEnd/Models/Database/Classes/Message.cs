using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public Message(int messageId, User sendingUserId, User receiverUserId, List<Attachment> attachmentId, string content, DateTime postDate, DateTime dateOfReceipt)
        {
            this.messageId = messageId;
            this.sendingUserId = sendingUserId;
            this.receiverUserId = receiverUserId;
            this.attachmentId = attachmentId;
            this.content = content;
            this.postDate = postDate;
            this.dateOfReceipt = dateOfReceipt;

            
        }
    }
}