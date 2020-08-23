using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Caliburn.Micro;
using ExcelToDatabase.Models;
using ExcelToDatabase.Services;
using ExcelToDatabase.Utils;

namespace ExcelToDatabase.ViewModels
{
	public class MainWindowViewModel : PropertyChangedBase
	{
		#region private fields
		private string selectedTable;
		private string selectedSheet;
		private string databaseName;
		private string serverName;
		private string path;
		#endregion

		#region Props
		public IWindowManager WindowManager { get; }
		public IDialogManagerService DialogManager { get; }
		public BindableCollection<string> Tables { get; set; }
		public BindableCollection<string> Sheets { get; set; }
		public SimpleContainer Container { get; }
		public string ServerName
		{
			get { return serverName; }
			set
			{
				serverName = value;
				NotifyOfPropertyChange(() => ServerName);
			}
		}
		public string DatabaseName
		{
			get { return databaseName; }
			set
			{
				databaseName = value;
				NotifyOfPropertyChange(() => DatabaseName);
			}
		}
		public string SelectedTable
		{
			get { return selectedTable; }
			set
			{
				selectedTable = value;
				NotifyOfPropertyChange(() => SelectedTable);
			}
		}
		public string SelectedSheet
		{
			get { return selectedSheet; }
			set
			{
				selectedSheet = value;
				NotifyOfPropertyChange(() => SelectedSheet);
			}
		}
		public string Path
		{
			get { return path; }
			set
			{
				path = value;
				NotifyOfPropertyChange(() => Path);
			}
		}
		#endregion


		public MainWindowViewModel(IWindowManager windowManager,IDialogManagerService dialogManager , SimpleContainer container)
		{
			WindowManager = windowManager;
			DialogManager = dialogManager;
			this.Container = container;
			Tables = new BindableCollection<string>();
			Sheets = new BindableCollection<string>();
		}


		public void Upload()
		{
			Path = GetPathFromFileDialog();
			
			if (!string.IsNullOrWhiteSpace(path))
			{
				RegisterExcelUtils(path);
				var excelUtils = IoC.Get<IExcelBusinessLogic >();
				string[] sheetNames = excelUtils.GetSheetNames(out string sheetError);
				Sheets.Clear();
				foreach (var item in sheetNames)
				{
					Sheets.Add(item);
				}
				SelectedSheet = Sheets[0];
			}
		}

		private void RegisterExcelUtils(string path)
		{
			Container.UnregisterHandler(typeof(IExcelBusinessLogic ), "ExcelUtils");
			Container.RegisterHandler(typeof(IExcelBusinessLogic ), "ExcelUtils", container => new ExcelBusinessLogic (path));
		}

		private string GetPathFromFileDialog()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
			fileDialog.ShowDialog();
			return fileDialog.FileName;
		}

		public void Connect()
		{
			if (string.IsNullOrWhiteSpace(ServerName) || string.IsNullOrWhiteSpace(databaseName))
			{
				DialogManager.ShowErrorMessageBox("server and databse cannot be empty !", "verification "); 
			}
			else
			{
				string connectionString = $"Server ={ServerName}; Database = {DatabaseName}; Trusted_Connection = True";
				ISqlServerBusinessLogic sqlServerBusinessLogic = new SqlServerBusinessLogic(connectionString);
				bool isValidConnectionString = sqlServerBusinessLogic.TestConnection(out string error);
				if (!isValidConnectionString)
				{
					DialogManager.ShowErrorMessageBox(error, "Error!");
				}
				else
				{
					Container.UnregisterHandler(typeof(ISqlServerBusinessLogic), "SqlUtils");
					Container.RegisterHandler(typeof(ISqlServerBusinessLogic), "SqlUtils", container => new SqlServerBusinessLogic(connectionString));
					var sqlServerUtils = IoC.Get<ISqlServerBusinessLogic>();
					List<string> tablesNames = sqlServerUtils.GetTableNames(out string tablesError);
					if (tablesError != null)
					{
						DialogManager.ShowErrorMessageBox(tablesError, "Connection Failed !");
					}
					else
					{
						Tables.Clear();

						foreach (var item in tablesNames)
						{
							Tables.Add(item);
						}
						SelectedTable = Tables[0];
					}
				}
			}

		}


		public void OpenColumnsConfiguration()
		{
			bool isValid = BasicValidation();
			if (isValid)
			{
				var vm = IoC.Get<ColumnsConfigurationViewModel>();
				vm.TableName = SelectedTable;
				vm.SheetName = SelectedSheet;
				WindowManager.ShowWindow(vm);
			}
		}

		private bool BasicValidation()
		{
			if (string.IsNullOrWhiteSpace(DatabaseName) || string.IsNullOrWhiteSpace(ServerName))
			{
				DialogManager.ShowErrorMessageBox("server and databse cannot be empty !", "verification ");
				return false;
			}
			if (string.IsNullOrWhiteSpace(Path))
			{
				DialogManager.ShowErrorMessageBox("Please select a file !", "verification ");
				return false;
			}
			if (string.IsNullOrWhiteSpace(SelectedTable))
			{
				DialogManager.ShowErrorMessageBox("Please select a table !", "verification ");
				return false;
			}
			if (string.IsNullOrWhiteSpace(SelectedSheet))
			{
				DialogManager.ShowErrorMessageBox("Please select a sheet !", "verification ");
				return false;
			}
			return true; 
		}

		public void OpenMapping()
		{
			bool isValid = BasicValidation();
			if (isValid)
			{
				var destinationColumns = IoC.Get<ColumnNamesHolders>("ColumnNamesHolders").DestinationColumnNames;
				var sourceColumns = IoC.Get<ColumnNamesHolders>("ColumnNamesHolders").SourceColumnNames;

				var vm = IoC.Get<MappingViewModel>();

				vm.SheetName = SelectedSheet;
				vm.TableName = SelectedTable;
				foreach (var item in destinationColumns)
				{
					vm.MappingItems.Add(new MappingItem(item, null));
				}
				foreach (var item in sourceColumns)
				{
					vm.SourceColumns.Add(item);
				}

				WindowManager.ShowWindow(vm);
			}
		}
	}
}
