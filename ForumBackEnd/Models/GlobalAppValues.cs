using ForumBackEnd.Models.Database;
using ForumBackEnd.Models.Database.Classes;
using ForumBackEnd.Models.Database.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ForumBackEnd.Models
{
	public static class GlobalAppValues
	{
		public static void Init(){
			InitSessions();
		}
		public static void InitSessions(){
			sessions = new List<Session>();
			DataSet data = new DataSet();
			data = DBManager.ExecuteCommand(new SqlCommand(GeneralQueries.AllFromSessions));
			DataRowCollection dataRows = data.Tables[0].Rows;
			for (int i = 0, l = dataRows.Count; i < l; i++)
				sessions.Add(new Session(dataRows[0]));
		}
		public static List<Session> sessions;

	}
}
