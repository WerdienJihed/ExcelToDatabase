using Caliburn.Micro;
using ExcelToDatabase.Models;
using ExcelToDatabase.Utils;
using System.Collections.Generic;


namespace ExcelToDatabase.ViewModels
{
	public class MappingViewModel : PropertyChangedBase
	{
		public IWindowManager window { get; set; }
		public List<MappingItem> MappingItems { get; set; }
		public List<string> SourceColumns { get; set; }
		public string TableName { get; set; }
		public string SheetName { get; set; }
	
		public MappingViewModel()
		{
			MappingItems = new List<MappingItem>();
			SourceColumns = new List<string>();
		}

		public void Execute()
		{
			var excelUtils = IoC.Get<IExcelUtils>("ExcelUtils"); 
			var sqlServerUtils = IoC.Get<ISqlServerUtils>("SqlUtils");
			var table =  excelUtils.GetRecords(SheetName,out string error);
			var filtredTable = DatatableHandler.FilterDataTable(table,SourceColumns);

			Dictionary<string, string> mapping = new Dictionary<string, string>(); 
			foreach (var item in MappingItems)
			{
				mapping.Add(item.SourceColumn, item.DestinationColumn);
			}
			var finalResult = DatatableHandler.ChangeColumnNames(filtredTable, mapping);

			bool isInserted = sqlServerUtils.InsertRecords(TableName, finalResult, out string error2);
			if (isInserted)
			{
				//
			}
		}

	}



}
