using System.Collections.Generic;
using System.Windows.Forms;
using Caliburn.Micro;
using ExcelToDatabase.Models;
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


		public MainWindowViewModel(IWindowManager windowManager, SimpleContainer container)
		{
			WindowManager = windowManager;
			this.Container = container;
			Tables = new BindableCollection<string>();
			Sheets = new BindableCollection<string>();
			ServerName = "DESKTOP-KGDL9CK";
			DatabaseName = "Test";
			Path = @"C:\Users\PC\Desktop\TestFile.xlsx";
		}


		public void Upload()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
			fileDialog.ShowDialog();
			Path = fileDialog.FileName;
			Container.UnregisterHandler(typeof(IExcelUtils), "ExcelUtils");
			Container.RegisterHandler(typeof(IExcelUtils), "ExcelUtils", container => new ExcelUtils(Path));
			var excelUtils = IoC.Get<IExcelUtils>();
			string[] sheetNames = excelUtils.GetSheetNames(out string sheetError);
			Sheets.Clear();
			foreach (var item in sheetNames)
			{
				Sheets.Add(item);
			}
			SelectedSheet = Sheets[0];
		}
		public void Connect()
		{
			string connectionString = $"Server ={ServerName}; Database = {DatabaseName}; Trusted_Connection = True";
			Container.UnregisterHandler(typeof(ISqlServerUtils), "SqlUtils");
			Container.RegisterHandler(typeof(ISqlServerUtils), "SqlUtils", container => new SqlServerUtils(connectionString));

			var sqlServerUtils = IoC.Get<ISqlServerUtils>();
			List<string> tablesNames = sqlServerUtils.GetTableNames(out string tablesError);

			Tables.Clear();

			foreach (var item in tablesNames)
			{
				Tables.Add(item);
			}
			SelectedTable = Tables[0];
		}
		public void OpenConfiguration()
		{
			var vm = IoC.Get<ConfigurationViewModel>();
			vm.TableName = SelectedTable;
			vm.SheetName = SelectedSheet;
			WindowManager.ShowWindow(vm);
		}

		public void OpenMapping()
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
