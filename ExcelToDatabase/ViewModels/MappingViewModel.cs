using Caliburn.Micro;
using ExcelToDatabase.Models;
using ExcelToDatabase.Services;
using ExcelToDatabase.Utils;
using System.Collections.Generic;


namespace ExcelToDatabase.ViewModels
{
	public class MappingViewModel : PropertyChangedBase
	{
		public IWindowManager window { get; set; }
		public IDialogManagerService DialogManager { get; set; }
		public List<MappingItem> MappingItems { get; set; }
		public List<string> SourceColumns { get; set; }
		public string TableName { get; set; }
		public string SheetName { get; set; }
	
		public MappingViewModel(IDialogManagerService dialogManager)
		{
			MappingItems = new List<MappingItem>();
			DialogManager = dialogManager;
			SourceColumns = new List<string>();
		}

		public void Execute()
		{
			var excelUtils = IoC.Get<IExcelUtils>("ExcelUtils"); 
			var sqlServerUtils = IoC.Get<ISqlServerUtils>("SqlUtils");
			var table =  excelUtils.GetRecords(SheetName,out string error);
			if (error != null)
			{
				DialogManager.ShowErrorMessageBox(error,"Somthing went wrong !");
			}
			else
			{
				var filtredTable = DatatableHandler.FilterDataTable(table, SourceColumns);

				Dictionary<string, string> mapping = new Dictionary<string, string>();
				foreach (var item in MappingItems)
				{
					mapping.Add(item.SourceColumn, item.DestinationColumn);
				}
				var finalResult = DatatableHandler.ChangeColumnNames(filtredTable, mapping);

				// Add default values and convert types

				var ColumnInformation = sqlServerUtils.GetColumnsInformation(TableName, out string error3);

				finalResult = DatatableHandler.ColumnConvertTypes(finalResult, ColumnInformation);
				finalResult = DatatableHandler.ColumnReplaceNullValues(finalResult, ColumnInformation);

				bool isInserted = sqlServerUtils.InsertRecords(TableName, finalResult, out string error2);
				if (!isInserted)
				{
					DialogManager.ShowErrorMessageBox(error2, "Failed To Execute !");
				}
				else
				{
					DialogManager.ShowSuccessMessageBox("Process executed successfully ! ", "Success");
				}
			}
			
		}

	}



}
