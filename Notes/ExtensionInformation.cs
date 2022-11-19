using Controls;
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
	public partial class ExtensionInformation : Form
	{
		public string authorName,
			title,
			website,
			email,
			name,
			description;

		private void button1_Clicked(object sender, ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonClickedEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void ExtensionInformation_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		public bool extensionEnabled = false;

		private void extensionSwitch_MouseClick(object sender, MouseEventArgs e)
		{
			if (((Switch)sender).CurrentState == Switch.SwitchStates.On)
			{
				extensionEnabled = true;
			}
			else
			{
				extensionEnabled = false;
			}
		}

		public ExtensionInformation()
		{
			InitializeComponent();
		}

		private void ExtensionInformation_Shown(object sender, EventArgs e)
		{
			authorNameLabel.Text = authorName;
			authorTitleLabel.Text = title;
			authorWebsiteLabel.Text = website;
			authorEmailAddressLabel.Text = email;
			extensionNameLabel.Text = name;
			descriptionLabel.Text = description;
		}
	}
}
