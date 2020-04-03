using System;
using System.Data;
using System.Data.SqlClient;

namespace ForumBackEnd.Models.Database
{
	public class DBManager
	{
		public const string ConnectionString = "";
		public static DataSet ExecuteCommand(SqlCommand command)
		{
			DataSet data = new DataSet();
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				using (command)
				{
					using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
					{
						dataAdapter.Fill(data);
					}
				}
			}
			return data;
		}
		/// <summary>
		/// Gets value from DataRow and Checks if it's null<br/>
		/// if null gives out defaultValue
		/// </summary>
		/// <param name="row">DataRow to take value from</param>
		/// <param name="index">Index of value</param>
		/// <param name="defaultValue"></param>
		/// <returns>Value from this</returns>
		public static dynamic GetValue(DataRow row,string index,object defaultValue)
		{
			object value = row[index];

			if (value == DBNull.Value)
			{
				return defaultValue;
			}
			else
			{
				return value;
			}
		}
		/// <summary>
		/// Checks if value is DBNull and if is then returns defaultValue
		/// </summary>
		/// <param name="value">Value to check</param>
		/// <param name="defaultValue">defaultValue to return</param>
		/// <returns>value if value != DBNull</returns>
		public static dynamic GetValue(object value, object defaultValue = null)
		{
			return value == DBNull.Value ? defaultValue : value;
		}
		/// <summary>
		/// Checks if value passed to function is considered as ID of some sort
		/// </summary>
		/// <param name="value">ID to check</param>
		/// <returns></returns>
		public static bool IsIDSafe(object value)
		{
			return value.GetType() != typeof(int) || ((int)value) > -1;
		}
	}
}
