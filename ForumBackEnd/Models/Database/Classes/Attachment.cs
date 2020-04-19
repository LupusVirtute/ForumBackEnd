using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumBackEnd.Models.Database.Classes
{
    public class Attachment
    {
        private int idAttachment;
        public string link;

        public Attachment(int idAttachment, string link)
        {
            this.idAttachment = idAttachment;
            this.link = link;
        }
    }
}