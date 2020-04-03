using System;
using System.Data;

namespace ForumBackEnd.Models.Database.Classes
{
    public class Session
    {
        int id;
        int uid;
        string sessionID;
        DateTime sessionExpired;
        public int UserID {
            get {
                return uid;
            }
        }
        public string SessionID {
            get{
                return sessionID;
            }
        }
        public bool IsSessionExpired(){
            return DateTime.Now > sessionExpired;
        }

        public Session(int id, int uid, string sessionID, DateTime sessionExpired)
        {
            this.id = id;
            this.uid = uid;
            this.sessionID = sessionID;
            this.sessionExpired = sessionExpired;
        }
        public Session(DataRow row){
            id = DBManager.GetValue(row["id"]);
            uid = DBManager.GetValue(row["userid"]);
            sessionID = DBManager.GetValue(row["sessionid"]);
            sessionExpired = DBManager.GetValue(row["sessionexpired"]);
        }
    }
}
