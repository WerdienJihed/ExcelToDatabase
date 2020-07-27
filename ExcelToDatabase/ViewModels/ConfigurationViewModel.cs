﻿using Caliburn.Micro;
using ExcelToDatabase.Models;
using ExcelToDatabase.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExcelToDatabase.ViewModels
{
	public class ConfigurationViewModel 
	{
		public string TableName { get; set; }
		public string SheetName { get; set; }
		public BindableCollection<Column> ColumnsFromSql { get; set; }
		public BindableCollection<Column> ColumnsFromExcel { get; set; }
		public SimpleContainer Container { get; set; }
		public ConfigurationViewModel(SimpleContainer container)
		{
			Container = container;
			ColumnsFromSql = new BindableCollection<Column>();
			ColumnsFromExcel = new BindableCollection<Column>();
		}


		public void OnLoad()
		{
			var sqlServerUtils = IoC.Get<ISqlServerUtils>();
			var excelUtils = IoC.Get<IExcelUtils>();
			List<string> sqlcolumnNames = sqlServerUtils.GetColumnNames(TableName, out string columnsError);
			List<string> excelcolumnNames = excelUtils.GetColumnNames(SheetName, out string error);
			foreach (var item in sqlcolumnNames)
			{
				Column column = new Column();
				column.Name = item;
				ColumnsFromSql.Add(column);
			}
			foreach (var item in excelcolumnNames)
			{
				Column column = new Column();
				column.Name = item;
				ColumnsFromExcel.Add(column);
			}
		}

		public void OkBtn(Window window)
		{
			List<string> excelColumnNames = new List<string>(); 
			List<string> sqlColumnNames = new List<string>(); 

			foreach (var item in ColumnsFromExcel)
			{
				if (item.IsChecked)
				{
					excelColumnNames.Add(item.Name);
				}
			}
			foreach (var item in ColumnsFromSql)
			{
				if (item.IsChecked)
				{
					sqlColumnNames.Add(item.Name);
				}
			}
			ColumnNamesHolders columnNamesHolders = new ColumnNamesHolders(excelColumnNames, sqlColumnNames);
			Container.UnregisterHandler<ColumnNamesHolders>();
			Container.RegisterHandler(typeof(ColumnNamesHolders), "ColumnNamesHolders", container => new ColumnNamesHolders(excelColumnNames, sqlColumnNames));
			var x = IoC.Get<ColumnNamesHolders>(); 
			if (window != null)
			{
				window.Close();
			}
		}

	}
}