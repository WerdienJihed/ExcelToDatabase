using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDatabase.Models
{
	public class MappingItem
	{
		public string DestinationColumn { get; set; }
		public string SourceColumn { get; set; }
		public MappingItem(string destinationColumn, string sourceColumn)
		{
			DestinationColumn = destinationColumn;
			SourceColumn = sourceColumn;
		}
	}
}
