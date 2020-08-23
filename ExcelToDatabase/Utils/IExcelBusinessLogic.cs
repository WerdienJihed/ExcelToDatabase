using System.Collections.Generic;
using System.Data;

namespace ExcelToDatabase.Utils
{
	public interface IExcelBusinessLogic 
	{
		string ConnectionString { get; set; }
		string[] GetSheetNames(out string error); 
		List<string> GetColumnNames(string sheetName, out string error);
		DataTable GetRecords(string sheetName, out string error);

	}
}