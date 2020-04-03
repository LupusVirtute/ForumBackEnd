using System;
using System.Security.Cryptography;
using System.Text;

namespace ForumBackEnd.Models.Utilities
{
	public static class Utility
	{
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
	}
}