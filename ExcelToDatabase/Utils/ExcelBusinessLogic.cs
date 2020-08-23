using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDatabase.Utils
{
	public class ExcelBusinessLogic  : IExcelBusinessLogic 
	{
		public string ConnectionString { get; set; }
		public ExcelBusinessLogic (string filePath)
		{
			ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= " + filePath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";
		}
		public List<string> GetColumnNames(string sheetName, out string error)
		{
			return ExcelDataAccess.GetColumnNames(ConnectionString, sheetName, out error);
		}
		public String[] GetSheetNames(out string error)
		{
			return ExcelDataAccess.GetSheetNames(ConnectionString, out error);
		}
		public DataTable GetRecords(string sheetName, out string error)
		{
			return ExcelDataAccess.GetRecords(ConnectionString, sheetName, out error);
		}
	}
}
