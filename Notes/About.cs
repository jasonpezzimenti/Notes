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
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
		}

		private void button1_Clicked(object sender, ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonClickedEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void About_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			using (CopyrightInformation dialog = new CopyrightInformation())
			{
				if(dialog.ShowDialog(this) == DialogResult.OK)
				{

				}
			}
		}
	}
}
