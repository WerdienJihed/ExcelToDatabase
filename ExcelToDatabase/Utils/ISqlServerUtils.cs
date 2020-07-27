using System.Collections.Generic;
using System.Data;

namespace ExcelToDatabase.Utils
{
	public interface ISqlServerUtils
	{
		string ConnectionString { get; set; }

		List<string> GetColumnNames(string tableName, out string error);
		DataTable GetTableInformation(string tableName, out string error);
		List<string> GetTableNames(out string error);
		bool InsertRecords(string tableName, DataTable dataTable, out string error);
		bool TestConnection(out string error);
	}
}