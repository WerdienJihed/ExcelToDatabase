using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDatabase.Models
{
	public class Column
	{
		public string Name { get; set; }
		public bool IsChecked { get; set; }
		public Type Type { get; set; }
		public bool IsNullable { get; set; }

		public Column()
		{
		}
	}
}
