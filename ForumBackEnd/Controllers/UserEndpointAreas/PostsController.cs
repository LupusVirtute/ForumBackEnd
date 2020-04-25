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
    public class PostsController : ApiController
    {

        public string Get(int userId)
        {
            SqlCommand UserPosts = new SqlCommand(PostQueries.UserPosts);
            UserPosts.Parameters.AddWithValue("@id",userId);
            DataSet postData = new DataSet();
            postData= DBManager.ExecuteCommand(UserPosts);
            
            Post post = new Post(postData.Tables[0].Rows[0]);
            return ObjectToJsonConverter.ObjectToJson(post);
    }   }
}