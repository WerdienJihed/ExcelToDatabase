using ExcelToDatabase.Models;
using log4net;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDatabase.Utils
{
	public static class DatatableHandler
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public static DataTable FilterDataTable(DataTable originalTable, List<string> columnNames)
		{
			DataTable result = originalTable.Copy();
			foreach (DataColumn column in originalTable.Columns)
			{
				bool existe = columnNames.Any(c => c == column.ColumnName);
				if (!existe)
				{
					result.Columns.Remove(column.ColumnName); 
				}
			}
			return result; 
		}
		
		public static DataTable ChangeColumnNames(DataTable originalTable , Dictionary<string,string> mapping )
		{
			DataTable result = originalTable.Copy();
			foreach (DataColumn column in originalTable.Columns)
			{
				var destinationColumnName = mapping.SingleOrDefault(c => c.Key == column.ColumnName).Value;

				result.Columns[column.ColumnName].ColumnName = destinationColumnName; 
			}
			return result;
		}

		public static DataTable ColumnConvertTypes(DataTable originalTable, List<Column> columnInformation)
		{
			DataTable result = originalTable.Clone();
			foreach (DataColumn column in result.Columns)
			{
				Type columnType = columnInformation.SingleOrDefault(c => c.Name == column.ColumnName).Type;

				result.Columns[column.ColumnName].DataType = columnType;
			}
			foreach (DataRow row in originalTable.Rows)
			{
				try
				{
					result.ImportRow(row);
				}
				catch (Exception e)
				{
					log.Error(e.Message, e);
				}
				
			}
			return result;
		}

		public static DataTable ColumnReplaceNullValues(DataTable originalTable, List<Column> columnInformation)
		{
			DataTable result = originalTable.Copy();


			foreach (Column column in columnInformation)
			{
				bool existe = originalTable.Columns.Contains(column.Name);
				if (!existe)
				{
					if (!column.IsNullable)
					{
						DataColumn dataColumn = new DataColumn();
						dataColumn.ColumnName = column.Name;
						dataColumn.DataType = column.Type;
						dataColumn.AllowDBNull = column.IsNullable;
						result.Columns.Add(dataColumn);
					}
				}

			}


			foreach (DataRow row in result.Rows)
			{
				foreach (DataColumn column in result.Columns)
				{
					bool isNullable = columnInformation.SingleOrDefault(c => c.Name == column.ColumnName).IsNullable;
					Type columnType = columnInformation.SingleOrDefault(c => c.Name == column.ColumnName).Type;

					if (!isNullable && row[column.ColumnName] is DBNull)
					{
						switch (columnType.ToString())
						{
							case "System.String":
								row[column] = string.Empty;
								break;
							case "System.Guid":
								row[column] = Guid.NewGuid();
								break;
							case "System.int":
								row[column] = 0;
								break;
							case "System.DateTime":
								row[column] = DateTime.Now;
								break;
							default:
								row[column] = "";
								break;
						}
					}
				}
			}
			return result;
		}
	}
}
