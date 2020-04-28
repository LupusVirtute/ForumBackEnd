using ForumBackEnd.Models.Database.Classes;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ForumBackEnd.Models.Utilities
{
	public static class Utility
	{
		public static string GetStringTime(DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
		}
		public static string GenerateRandomString(int length)
		{
			const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+|}{:\";<>,./?\\";
			StringBuilder randomStringBuilder = new StringBuilder();
			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
			{
				byte[] uintBuffer = new byte[sizeof(uint)];
				while (length-- > 0)
				{
					rng.GetBytes(uintBuffer);
					uint num = BitConverter.ToUInt32(uintBuffer, 0);
					int character = (int)(num % (uint)Chars.Length);
					randomStringBuilder.Append(Chars[character]);
				}
			}
			return randomStringBuilder.ToString();
		}
		public static bool DoesSessionIDExist(string sessionID)
		{
			return !string.IsNullOrEmpty(sessionID) &&
			GlobalAppValues.sessions.Any(o => o.SessionID == sessionID);
		}
		public static Session GetUserSession(int userid){
			if (userid < 0) 
				return null;
			
			return GlobalAppValues.sessions.FirstOrDefault(o => o.UserID == userid && !o.IsSessionExpired());
		}
	}
}
