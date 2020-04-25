using ForumBackEnd.Models;
using ForumBackEnd.Models.Database;
using ForumBackEnd.Models.Database.Classes;
using ForumBackEnd.Models.Database.Queries;
using ForumBackEnd.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ForumBackEnd.Controllers.UserEndpointAreas
{
    public class  LoginController : ApiController
    {
        public string Get(string password, string email)
        {
            User user = new User(email, password);
            if(user.SessionID==null)
            {
                return ObjectToJsonConverter.ObjectToJson(new Error(ErrorCodes.USER_NOT_IN_DB));
            }
            return ObjectToJsonConverter.ObjectToJson(user.SessionID);
        }
    }
}