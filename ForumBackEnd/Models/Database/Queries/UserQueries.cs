namespace ForumBackEnd.Models.Database.Queries
{
	public class UserQueries
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
			" description," +
			" avatarfilepath," +
			" nickeffects," +
			" registrationdate," +
			" lastivisit" +
			" WHERE email = @email AND pass = @password";
	}
}
