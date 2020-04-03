using ForumBackEnd.Models.Database.Queries;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ForumBackEnd.Models.Database.Classes
{
	public class User
	{
		private string username;
		private string email;
		private string description;
		private string avatarFilePath;
		private string nickEffects;
		private DateTime registrationDate;
		private DateTime lastVisit;

		public User(string sessionID)
		{
			if (string.IsNullOrEmpty(sessionID))
			{
				#if DEBUG
					throw new ArgumentNullException("sessionID", "id of the session is null");
				#else
					return;
				#endif
			}
			DataSet sessionDataSet = new DataSet();
			SqlCommand command = new SqlCommand(UserQueries.JoinSessionTables);
			command.Parameters.AddWithValue("@session", sessionID);
			sessionDataSet = DBManager.ExecuteCommand(command);

			DataRow userDataRow = sessionDataSet.Tables[0].Rows[0];
			BuildUser(userDataRow);
		}
		public User(string email, string password)
		{
			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
			{
				#if DEBUG
					throw new ArgumentNullException("email/password", "is null");
				#else
						return;
				#endif
			}
			
			SqlCommand command = new SqlCommand(UserQueries.UserByMailAndPassword);
			command.Parameters.AddWithValue("@email",email);
			command.Parameters.AddWithValue("@password",password);



		}
		public User(DataRow dr){
			BuildUser(dr);
		}

		private void BuildUser(DataRow dataRow)
		{
			username = DBManager.GetValue(dataRow["username"], "INCORRECT VALUE");
			email = DBManager.GetValue(dataRow["email"], "INCORRECT VALUE");
			description = DBManager.GetValue(dataRow["description"], "INCORRECT VALUE");
			avatarFilePath = DBManager.GetValue(dataRow["avatarfilepath"], "INCORRECT VALUE");
			nickEffects = DBManager.GetValue(dataRow["nickeffects"], "INCORRECT VALUE");
			registrationDate = DBManager.GetValue(dataRow["registrationdate"], DateTime.Now);
			lastVisit = DBManager.GetValue(dataRow["lastvisit"], DateTime.Now);
		}


		public static User GetUserByID(int id)
		{
			if (id > -1)
			{
				return null;
			}
			DataSet userData = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE ID = @id");
			sqlCommand.Parameters.AddWithValue("@id", id);
			userData = DBManager.ExecuteCommand(sqlCommand);
			return new User(userData.Tables[0].Rows[0]);
		}
		public static string GenerateSession(int uid)
		{
			string sessionID = Utilities.Utility.GenerateRandomString(255);

			return sessionID;
		}

	}
}
