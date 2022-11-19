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
	public partial class ChooseRecordingNameWindow : Form
	{
		public string recordingName = String.Empty;

		public ChooseRecordingNameWindow()
		{
			InitializeComponent();
		}

		private void applyChangesButton_Confirmed(object sender, ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonConfirmedEventArgs e)
		{
			recordingName = recordingNameTextField.Text;

			this.DialogResult = DialogResult.OK;
		}
	}
}
