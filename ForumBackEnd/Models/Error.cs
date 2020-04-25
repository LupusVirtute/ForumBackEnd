using ForumBackEnd.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumBackEnd.Models
{
    public class Error
    {
        ErrorCodes errorId;

        public Error(ErrorCodes error)
        {
            this.errorId = error;
        }
    }
}