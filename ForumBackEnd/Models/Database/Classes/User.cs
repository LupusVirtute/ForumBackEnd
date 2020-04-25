using ForumBackEnd.Models.Database.Queries;
using System;
using System.Data;
using System.Data.SqlClient;
using ForumBackEnd.Models.Utilities;

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
		private string sessionId;

		public string SessionID
		{
			get
			{
				return sessionId;
			}
		}
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
			if(!Utility.DoesSessionIDExist(sessionID)){
				#if DEBUG
					throw new ArgumentNullException("sessionID", "id of the session doesn't exist");
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
			DataSet data = new DataSet();
			data = DBManager.ExecuteCommand(command);
			BuildUser(data.Tables[0].Rows[0]);
			sessionId=GenerateSession((int)data.Tables[0].Rows[0]["id"]);
		}
		public User(DataRow dr){
			BuildUser(dr);
		}

		private void BuildUser(DataRow dataRow)
		{
			username			= DBManager.GetValue(dataRow["username"]				, "INCORRECT VALUE");
			email				= DBManager.GetValue(dataRow["email"]					, "INCORRECT VALUE");
			description			= DBManager.GetValue(dataRow["description"]				, "INCORRECT VALUE");
			avatarFilePath		= DBManager.GetValue(dataRow["avatarfilepath"]			, "INCORRECT VALUE");
			nickEffects			= DBManager.GetValue(dataRow["nickeffects"]				, "INCORRECT VALUE");
			registrationDate	= DBManager.GetValue(dataRow["registrationdate"]		, DateTime.Now);
			lastVisit			= DBManager.GetValue(dataRow["lastvisit"]				, DateTime.Now);
		}


		public static User GetUserByID(int id)
		{
			if (id < 0)
			{
				return null;
			}
			
			DataSet userData = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE id = @id");
			sqlCommand.Parameters.AddWithValue("@id", id);
			userData = DBManager.ExecuteCommand(sqlCommand);

			return new User(userData.Tables[0].Rows[0]);
		}

		public static string GenerateSession(int uid)
		{
			Session userSession;
			if ((userSession = Utility.GetUserSession(uid)) == null)
			{
				return userSession.SessionID;
			}


			string sessionID = Utility.GenerateRandomString(Config.sessionNameLength);

			while (Utility.DoesSessionIDExist(sessionID))
				sessionID = Utility.GenerateRandomString(Config.sessionNameLength);

			int nextID = DBManager.GetTableColumnNextIncrement("Sessions","id");
			DateTime expired = DateTime.Now.AddDays(Config.AuthDays);

			GlobalAppValues.sessions.Add(
				new Session(
						nextID,
						uid,
						sessionID,
						expired
					)
				);

			SqlCommand putInSession = new SqlCommand(UserQueries.PutSessionID);
			putInSession.Parameters.AddWithValue("@uid",uid);
			putInSession.Parameters.AddWithValue("@sessionid",sessionID);
			putInSession.Parameters.AddWithValue("@sessionexpired",expired);

			DBManager.ExecuteCommandNoReturn(putInSession);
			return sessionID;
		}

	}
}
