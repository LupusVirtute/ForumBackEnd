using ForumBackEnd.Models.Database.Classes;
using System.Collections.Generic;
using System.Linq;

namespace ForumBackEnd.Models
{
	public class StaticItems
	{
		public static List<Session> sessions = new List<Session>();
		public static bool DoesSessionIDExist(string sessionID){
			return  !string.IsNullOrEmpty(sessionID) 
			&& sessions.Any(o => o.SessionID == sessionID);
		}
	}
}
