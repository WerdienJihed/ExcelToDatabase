using ExcelToDatabase.Models;
using log4net;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDatabase.Utils
{
	public static class DatatableHandler
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		
		public static DataTable PrepareTable(DataTable SourceTable, DataTable tableSchema, Dictionary<string, string> mapping)
		{
			DataTable Result = tableSchema.Clone();

			foreach (DataRow originalRow in SourceTable.Rows)
			{
				DataRow ResultRow = PrepareRow(originalRow, tableSchema, mapping);
				Result.Rows.Add(ResultRow.ItemArray);
			}


			return Result;
		}

		private static DataRow PrepareRow(DataRow originalRow, DataTable tableSchema, Dictionary<string, string> mapping)
		{
			DataRow dataRow = tableSchema.NewRow();

			foreach (var item in mapping)
			{
				string destinationColumn = item.Key;
				string sourceColumn  = item.Value;


				
				Type columnType = tableSchema.Columns[destinationColumn].DataType;
				var value = originalRow[sourceColumn];
				bool isDestinationColumnNullable = tableSchema.Columns[destinationColumn].AllowDBNull; 
				
				if (value == null && !isDestinationColumnNullable)
				{
					value = GetDefaultValueForNullColumn(columnType);
					dataRow[destinationColumn] = value;
				}
				else
				{
					try
					{
						dynamic convertedValue = TryToConvertTheValue(value,columnType);
						dataRow[destinationColumn] = convertedValue;
					}
					catch (Exception e)
					{
						log.Error(e.Message);
					}
				}
			}

			foreach (DataColumn dataColumn in dataRow.Table.Columns)
			{
				bool columnExisteInMapping = mapping.Any(c => c.Key == dataColumn.ColumnName); 
				if (!dataColumn.AllowDBNull && !columnExisteInMapping)
				{
					dataRow[dataColumn] = GetDefaultValueForNullColumn(dataColumn.DataType);
				}
			}
			
			return dataRow; 
		}

		private static dynamic TryToConvertTheValue(object value, Type columnType)
		{
			string valueConvertedToString = value.ToString(); 
			switch (columnType.ToString())
			{
				case "System.String":
					return valueConvertedToString;
				case "System.Guid":
					return Guid.Parse(valueConvertedToString);
				case "System.int":
					return int.Parse(valueConvertedToString);
				case "System.DateTime":
					return DateTime.Parse(valueConvertedToString);
				default:
					throw new Exception($"Convertion to type : {columnType} is not supported yet !");
			}
		}

		private static object GetDefaultValueForNullColumn(Type columnType)
		{
			object value;
			switch (columnType.ToString())
			{
				case "System.String":
					value = string.Empty;
					break;
				case "System.Guid":
					value = Guid.NewGuid();
					break;
				case "System.int":
					value = 0;
					break;
				case "System.DateTime":
					value = DateTime.Now;
					break;
				default:
					value = "";
					break;
			}

			return value;
		}

		//public static DataTable FilterDataTable (DataTable originalTable, List<string> columnNames)
		//{
		//	DataTable result = originalTable.Copy();
		//	foreach (DataColumn column in originalTable.Columns)
		//	{
		//		bool existe = columnNames.Any(c => c == column.ColumnName);
		//		if (!existe)
		//		{
		//			result.Columns.Remove(column.ColumnName); 
		//		}
		//	}
		//	return result; 
		//}

		//public static DataTable ChangeColumnNames(DataTable originalTable , Dictionary<string,string> mapping )
		//{
		//	DataTable result = originalTable.Copy();
		//	foreach (DataColumn column in originalTable.Columns)
		//	{
		//		var destinationColumnName = mapping.SingleOrDefault(c => c.Key == column.ColumnName).Value;

		//		result.Columns[column.ColumnName].ColumnName = destinationColumnName; 
		//	}
		//	return result;
		//}

		//public static DataTable ColumnConvertTypes(DataTable originalTable, List<Column> columnInformation)
		//{
		//	DataTable result = originalTable.Clone();
		//	foreach (DataColumn column in result.Columns)
		//	{
		//		Type columnType = columnInformation.SingleOrDefault(c => c.Name == column.ColumnName).Type;

		//		result.Columns[column.ColumnName].DataType = columnType;
		//	}
		//	foreach (DataRow row in originalTable.Rows)
		//	{
		//		try
		//		{
		//			result.ImportRow(row);
		//		}
		//		catch (Exception e)
		//		{
		//			log.Error(e.Message, e);
		//		}

		//	}
		//	return result;
		//}

		//public static DataTable ColumnReplaceNullValues(DataTable originalTable, List<Column> columnInformation)
		//{
		//	DataTable result = originalTable.Copy();


		//	foreach (Column column in columnInformation)
		//	{
		//		bool existe = originalTable.Columns.Contains(column.Name);
		//		if (!existe)
		//		{
		//			if (!column.IsNullable)
		//			{
		//				DataColumn dataColumn = new DataColumn();
		//				dataColumn.ColumnName = column.Name;
		//				dataColumn.DataType = column.Type;
		//				dataColumn.AllowDBNull = column.IsNullable;
		//				result.Columns.Add(dataColumn);
		//			}
		//		}
		//	}


		//	foreach (DataRow row in result.Rows)
		//	{
		//		foreach (DataColumn column in result.Columns)
		//		{
		//			bool isNullable = columnInformation.SingleOrDefault(c => c.Name == column.ColumnName).IsNullable;
		//			Type columnType = columnInformation.SingleOrDefault(c => c.Name == column.ColumnName).Type;

		//			if (!isNullable && row[column.ColumnName] is DBNull)
		//			{
		//				switch (columnType.ToString())
		//				{
		//					case "System.String":
		//						row[column] = string.Empty;
		//						break;
		//					case "System.Guid":
		//						row[column] = Guid.NewGuid();
		//						break;
		//					case "System.int":
		//						row[column] = 0;
		//						break;
		//					case "System.DateTime":
		//						row[column] = DateTime.Now;
		//						break;
		//					default:
		//						row[column] = "";
		//						break;
		//				}
		//			}
		//		}
		//	}
		//	return result;
		//}
	}
}
