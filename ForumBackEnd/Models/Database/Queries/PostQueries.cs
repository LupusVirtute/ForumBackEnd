using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumBackEnd.Models.Database.Queries
{
    public static class PostQueries
    {
        public const string UserPosts =
        " SELECT Users.id " +
        " Post.id" +
        " Post.userid" +
        " Post.text" +
        " Post.ismodified" +
        " Post.datemodified" +
        " Post.topicid" +
        " Where Users.id=@id" +
        " INNER JOIN Users ON Post.userid=Users.id";
    }
}