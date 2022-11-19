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
	public partial class CopyrightInformation : Form
	{
		public CopyrightInformation()
		{
			InitializeComponent();
		}

		private void CopyrightInformation_Shown(object sender, EventArgs e)
		{
			ListViewItem item = new ListViewItem();
			item.Text = "Jimi";
			item.SubItems.Add("Keyboard Shortcuts for Extensions");
			item.SubItems.Add("https://stackoverflow.com/a/74311095/20283719");

			listView1.Items.Add(item);

			ListViewItem item2 = new ListViewItem();
			item2.Text = "Darin Dimitrov";
			item2.SubItems.Add("Record sound");
			item2.SubItems.Add("https://stackoverflow.com/a/3694293/20283719");

			listView1.Items.Add(item2);

			ListViewItem item3 = new ListViewItem();
			item3.Text = "Ron Whittle";
			item3.SubItems.Add("Write Bytes to File.");
			item3.SubItems.Add("https://social.msdn.microsoft.com/Forums/en-US/21c8b442-b517-491c-b0bd-7d4d5b1e0e6b/recreating-a-file-locally-from-byte-array?forum=csharpgeneral");

			listView1.Items.Add(item3);
		}
	}
}
