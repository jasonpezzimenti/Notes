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
	public partial class ConfirmationWindow : Form
	{
		public ConfirmationWindow()
		{
			InitializeComponent();
		}

		private void applyChangesButton_Clicked(object sender, ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonClickedEventArgs e)
		{
			this.DialogResult = DialogResult.No;
		}

		private void button1_Confirmed(object sender, ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonConfirmedEventArgs e)
		{
			this.DialogResult = DialogResult.Yes;
		}
	}
}
