using ForumBackEnd.Models;
using ForumBackEnd.Models.Database;
using ForumBackEnd.Models.Database.Classes;
using ForumBackEnd.Models.Database.Queries;
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
    public class InfoController : ApiController
    {
        public string Get(string email)
        {
            SqlCommand UserInfo = new SqlCommand(UserQueries.UserInfo);
            UserInfo.Parameters.AddWithValue("@email", email);
            DataSet userData = new DataSet();
            userData = DBManager.ExecuteCommand(UserInfo);
            return ObjectToJsonConverter.ObjectToJson(new User(userData.Tables[0].Rows[0]));
        }
    }
}