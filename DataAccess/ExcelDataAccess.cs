using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public static class ExcelDataAccess 
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public static bool TestConnection(string connectionString, out string error)
		{
			error = null;
			return true;
		}
		public static String[] GetSheetNames(string connectionString , out string error)
		{
			OleDbConnection connection = null;
			DataTable datatable = null;
			error = null;

			try
			{
				connection = new OleDbConnection(connectionString);

				connection.Open();

				datatable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

				if (datatable == null)
				{
					
					return null;
				}

				String[] excelSheets = new String[datatable.Rows.Count];
				int i = 0;

				foreach (DataRow row in datatable.Rows)
				{
					excelSheets[i] = row["TABLE_NAME"].ToString();
					i++;
				}
				return excelSheets;
			}
			catch (Exception e)
			{
				log.Error(e.Message);
				error = e.Message;
				return null;
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
					connection.Dispose();
				}
				if (datatable != null)
				{
					datatable.Dispose();
				}
			}
		}
	

		public static List<string> GetColumnNames(string connectionString, string sheetName, out string error)
		{
			error = null;
			List<string> columns = new List<string>();
			try
			{
				OleDbConnection connection = new OleDbConnection();
				connection.ConnectionString = connectionString;
				OleDbCommand command = new OleDbCommand
					(
						$"SELECT * FROM [{sheetName}]", connection
					);
				DataSet dataSet = new DataSet();
				OleDbDataAdapter adapter = new OleDbDataAdapter(command);
				adapter.Fill(dataSet);
				DataTable dataTable = dataSet.Tables[0];
				DataColumnCollection datacolumns = dataTable.Columns;

				foreach (DataColumn column in datacolumns)
				{
					columns.Add(column.ColumnName);
				}
				return columns;
			}
			catch (Exception e )
			{
				log.Error(e.Message);
				error = e.Message;
			}
			return null;
		}

		public static DataTable GetRecords(string connectionString, string sheetName, out string error)
		{
			error = null;
			try
			{
				OleDbConnection connection = new OleDbConnection();
				connection.ConnectionString = connectionString;
				OleDbCommand command = new OleDbCommand
					(
						$"SELECT * FROM [{sheetName}]", connection
					);
				DataSet dataSet = new DataSet();
				OleDbDataAdapter adapter = new OleDbDataAdapter(command);
				adapter.Fill(dataSet);
				return dataSet.Tables[0];
			}
			catch (Exception e )
			{
				log.Error(e.Message);
				error = e.Message;
			}
			return null;
		}
	}
}
