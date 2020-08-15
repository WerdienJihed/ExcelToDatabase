using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using log4net;

namespace DataAccess
{
	public static class SqlServerDataAccess 
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public static bool TestConnection(string connectionString , out string error)
		{
			error = null;
			try
			{
				using (SqlConnection con = new SqlConnection(connectionString))
				{
					con.Open();
					return true;
				}

			}
			catch (Exception e)
			{
				log.Error(e.Message);
				return false;
			}
		}
		public static List<string> GetTableNames(string connectionString, out string error)
		{
			error = null;
			List<string> tableNames = new List<string>();  

			try
			{
				using (SqlConnection con = new SqlConnection(connectionString))
				{
					con.Open();

					DataTable dt = con.GetSchema("Tables");

					foreach (DataRow row in dt.Rows)
					{
						string tablename = (string)row[2];
						tableNames.Add(tablename);
					}

				}
				return tableNames.OrderBy(t => t).ToList();
			}
			catch (Exception e)
			{
				log.Error(e.Message);
				error = e.Message;
			}

			return null;
		}

		public static List<string> GetColumnNames(string connectionString, string tableName, out string error)
		{
			error = null;
			List<string> columnsNames = new List<string>();
			DataTable table = new DataTable();
			try
			{
				using (SqlConnection con = new SqlConnection(connectionString))
				{
					con.Open();
					using (SqlCommand command = new SqlCommand($"SELECT TOP 0 * FROM dbo.{tableName}", con))
					{
						var reader = command.ExecuteReader();
						table = reader.GetSchemaTable();
					}
				}

				foreach (DataRow row in table.Rows)
				{
					string columnName = row.Field<string>("ColumnName");
					columnsNames.Add(columnName);
				}
				return columnsNames;
			}
			catch (Exception e)
			{
				log.Error(e.Message);
			}
			return null;
		}

		public static DataTable GetTableInformation(string connectionString, string tableName, out string error)
		{
			error = null;
			DataTable table = new DataTable();
			try
			{
				using (SqlConnection con = new SqlConnection(connectionString))
				{
					con.Open();
					using (SqlCommand command = new SqlCommand($"SELECT TOP 0 * FROM dbo.{tableName}", con))
					{
						var reader = command.ExecuteReader();
						table = reader.GetSchemaTable();
					}
				}
			}
			catch (Exception e)
			{
				log.Error(e.Message);
			}
			return table;
		}

		public static bool InsertRecords(string connectionString, string tableName, DataTable dataTable, out string error)
		{
			error = null;
			try
			{
				using (SqlConnection cnn = new SqlConnection(connectionString))
				{
					cnn.Open();
					using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString))
					{
						bulkCopy.DestinationTableName = tableName;
						foreach (DataColumn column in dataTable.Columns)
						{
							bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
						}
						bulkCopy.WriteToServer(dataTable);
					}
				}
			}
			
			catch (Exception e)
			{
				log.Error(e.Message);
				error = e.Message;
				return false;
			}
			return true;
		}

	}
}
