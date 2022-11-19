using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
	public partial class NewGroupWindow : Form
	{
		public string groupName;

		public NewGroupWindow()
		{
			InitializeComponent();

			//this.AcceptButton = (IButtonControl)okButton;
		}

		private void okButton_Clicked(object sender, ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonClickedEventArgs e)
		{
			if (groupNameTextField.Text.Length >= 1)
			{
				groupName = groupNameTextField.Text;

				this.DialogResult = DialogResult.OK;
			}
		}

		private void NewGroupWindow_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Escape)
			{
				this.DialogResult = DialogResult.Cancel;
			}
			else if(e.KeyChar == (char)Keys.Enter)
			{
				

				okButton.PerformClick();
			}
		}
	}
}
