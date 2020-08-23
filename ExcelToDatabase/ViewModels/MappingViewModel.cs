using Caliburn.Micro;
using ExcelToDatabase.Models;
using ExcelToDatabase.Services;
using ExcelToDatabase.Utils;
using System.Collections.Generic;
using System.Data;

namespace ExcelToDatabase.ViewModels
{
	public class MappingViewModel : PropertyChangedBase
	{
		public IWindowManager window { get; set; }
		public IDialogManagerService DialogManager { get; set; }
		public IExcelBusinessLogic ExcelBusinessLogic { get; set; }
		public ISqlServerBusinessLogic SqlServerBusinessLogic { get; set; }
		public List<MappingItem> MappingItems { get; set; }
		public List<string> SourceColumns { get; set; }
		public string TableName { get; set; }
		public string SheetName { get; set; }
	
		public MappingViewModel(IDialogManagerService dialogManager,IExcelBusinessLogic excelBusinessLogic , ISqlServerBusinessLogic sqlServerBusinessLogic)
		{
			MappingItems = new List<MappingItem>();
			DialogManager = dialogManager;
			SourceColumns = new List<string>();
			ExcelBusinessLogic = excelBusinessLogic;
			SqlServerBusinessLogic = sqlServerBusinessLogic;
		}

		public void Execute()
		{


			DataTable sourceTable =  ExcelBusinessLogic.GetRecords(SheetName,out string error);
			if (error != null)
			{
				DialogManager.ShowErrorMessageBox(error,"Somthing went wrong !");
			}
			else
			{
				

				Dictionary<string, string> mapping = new Dictionary<string, string>();
				
				foreach (MappingItem item in MappingItems)
				{
					if (item.SourceColumn == null)
					{
						DialogManager.ShowErrorMessageBox("Please specify the source column for each destination column !", "Error");
						return;
					}
					mapping.Add(item.DestinationColumn, item.SourceColumn);
				}




				DataTable tableSchema = SqlServerBusinessLogic.GetTableSchema(TableName, out string error3);

				DataTable finalResult = DatatableHandler.PrepareTable(sourceTable, tableSchema,mapping);

				bool isInserted = SqlServerBusinessLogic.InsertRecords(TableName, finalResult, out string error2);
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
