using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDatabase.Utils
{
	public class SqlServerUtils : ISqlServerUtils
	{
		public string ConnectionString { get; set; }
		public SqlServerUtils(string connectionString)
		{
			ConnectionString = connectionString;
		}

		
		public bool TestConnection(out string error)
		{
			return SqlServerDataAccess.TestConnection(ConnectionString, out error);
		}
		public List<string> GetTableNames(out string error)
		{
			return SqlServerDataAccess.GetTableNames(ConnectionString, out error);
		}


		public List<string> GetColumnNames(string tableName, out string error)
		{
			return SqlServerDataAccess.GetColumnNames(ConnectionString, tableName, out error);
		}

		public DataTable GetTableInformation(string tableName, out string error)
		{
			return SqlServerDataAccess.GetTableInformation(ConnectionString, tableName, out error);
		}

		public bool InsertRecords(string tableName, DataTable dataTable, out string error)
		{
			return SqlServerDataAccess.InsertRecords(ConnectionString, tableName, dataTable, out error);
		}
	}
}
