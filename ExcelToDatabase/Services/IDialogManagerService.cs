using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDatabase.Services
{
	public interface IDialogManagerService
	{
		void ShowSuccessMessageBox(string message ,string caption);
		void ShowErrorMessageBox(string message, string caption);
		bool ShowDialogMessageBox(string message, string caption);

	}
}
