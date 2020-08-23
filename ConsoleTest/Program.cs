using DataAccess;
using ExcelToDatabase.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
	class Program
	{
		static void Main(string[] args)
		{
			DataTable destinationTable = new DataTable();

			DataColumn dataColumn = new DataColumn("Id");
			dataColumn.DataType = typeof(Guid);
			dataColumn.AllowDBNull = false;

			DataColumn dataColumn2 = new DataColumn("Name");
			dataColumn2.DataType = typeof(string);
			dataColumn2.AllowDBNull = false;

			DataColumn dataColumn3 = new DataColumn("Email");
			dataColumn3.DataType = typeof(string);
			dataColumn3.AllowDBNull = true;

			DataColumn dataColumn4 = new DataColumn("CreatedOn");
			dataColumn4.DataType = typeof(DateTime);
			dataColumn4.AllowDBNull = false;

			destinationTable.Columns.Add(dataColumn);
			destinationTable.Columns.Add(dataColumn2);
			destinationTable.Columns.Add(dataColumn3);
			destinationTable.Columns.Add(dataColumn4);

			string filePath = @"C:\Users\PC\Desktop\MOCK_DATA.xlsx";
			string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= " + filePath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";

			DataTable sourceTable = ExcelDataAccess.GetRecords(connectionString, "Informations$", out string error);

			Dictionary<string, string> mapping = new Dictionary<string, string>();
			mapping.Add("Id","id"); 
			mapping.Add("Name", "first_name"); 
			mapping.Add("Email", "email");

			DataTable dataTable=  DatatableHandler.PrepareTable(sourceTable, destinationTable, mapping);

			Console.ReadLine(); 



		}
	}
}
