using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDatabase.Utils
{
	public class ColumnNamesHolders
	{
		public List<string> SourceColumnNames { get; set; }
		public List<string> DestinationColumnNames { get; set; }
		public ColumnNamesHolders(List<string> sourceColumnNames , List<string> destinationColumnNames)
		{
			SourceColumnNames = sourceColumnNames;
			DestinationColumnNames = destinationColumnNames; 
		}

	}
}
