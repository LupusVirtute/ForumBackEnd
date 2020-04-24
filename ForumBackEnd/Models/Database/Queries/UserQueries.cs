namespace ForumBackEnd.Models.Database.Queries
{
	public static class UserQueries
    {
		public const string JoinSessionTables =
			"SELECT" +
			// Session Data
			" Sessions.userid," +
			" Sessions.sessionexpired," +
			// User Data
			" Users.username," +
			" Users.email," +
			" Users.description," +
			" Users.avatarfilepath," +
			" Users.nickeffects," +
			" Users.registrationdate," +
			" Users.lastvisit" +
			// Rest of the query
			" FROM Sessions" +
			" INNER JOIN Users ON Sessions.userid = Users.id" +
			" WHERE Sessions.sessionid = @session ";
		public const string UserByMailAndPassword = 
			"SELECT username," +
			" id,"+
			" description," +
			" avatarfilepath," +
			" nickeffects," +
			" registrationdate," +
			" lastivisit" +
			" WHERE email = @email AND pass = @password";
		/// <summary>
		/// Parameters <br/>
		/// @uid - user id <br/>
		/// @sessionid <br/>
		/// @sessionExpirationDate <br/>
		/// </summary>
		public const string PutSessionID =
		" INSERT INTO Sessions" +
		" (userid,sessionid,sessionexpired)" +
		" VALUES(@uid,@sessionid,@sessionExpirationDate)";
		public const string PutUser =
		" INSERT INTO Users" +
		" (email,pass)" +
		" VALUES (@email,@pass)";
		public const string UserInfo =
		" SELECT" +
		" username," +
		" description," +
		" avatarfilepath," +
		" nickeffects," +
		" registrationdate," +
		" lastvisit," +
		" postcount" +
		" FROM Users" +
		" WHERE email = @email";
	}
}
