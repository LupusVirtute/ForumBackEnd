using System;

namespace ForumBackEnd.Models.Database.Classes
{
    public class Session
    {
        int id;
        int uid;
        string sessionID;
        DateTime sessionExpired;
        public string SessionID {
            get{
                return sessionID;
            }
        }
        public Session(int id, int uid, string sessionID, DateTime sessionExpired)
        {
            this.id = id;
            this.uid = uid;
            this.sessionID = sessionID;
            this.sessionExpired = sessionExpired;
        }
    }
}
