using ForumBackEnd.Models.Database;
using ForumBackEnd.Models.Database.Classes;
using ForumBackEnd.Models.Database.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ForumBackEnd.Controllers.UserEndpointAreas
{
    public class RegisterController : ApiController
    {
       
        public string Post (string password,string email)
        {
            SqlCommand createUser = new SqlCommand(UserQueries.PutUser);
            createUser.Parameters.AddWithValue("@email", email);
            createUser.Parameters.AddWithValue("@pass", password);
            DBManager.ExecuteCommand(createUser);
            return "Successful Registration";
        }
    }
}