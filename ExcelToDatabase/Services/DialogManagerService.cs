
using System.Windows.Forms;

namespace ExcelToDatabase.Services
{
	public class DialogManagerService : IDialogManagerService
	{
		public bool ShowDialogMessageBox(string message , string caption)
		{
			DialogResult result = 
				MessageBox.Show(message,caption,
			MessageBoxButtons.YesNo);
			switch (result)
			{
				case DialogResult.Yes:
					return true;
				case DialogResult.No:
					return false;
				default:
					return false;
			}
		}

		public void ShowErrorMessageBox(string message ,string caption)
		{
			MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ShowSuccessMessageBox(string message ,string caption)
		{
			MessageBox.Show(message, caption);
		}
	}
}
