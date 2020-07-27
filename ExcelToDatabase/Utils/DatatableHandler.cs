using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDatabase.Utils
{
	public static class DatatableHandler
	{
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
	}
}
