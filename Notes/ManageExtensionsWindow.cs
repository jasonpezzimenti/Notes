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
	public partial class ManageExtensionsWindow : Form
	{
		public ManageExtensionsWindow()
		{
			InitializeComponent();
		}

		private void ManageExtensionsWindow_Shown(object sender, EventArgs e)
		{
			if (Window.extensions != null)
			{
				list.BeginUpdate();

				foreach (Extension extension in Window.extensions)
				{
					if (extension != null)
					{
						ListViewItem item = new ListViewItem();
						item.Text = extension.Author;

						item.SubItems.Add(extension.Name);
						item.SubItems.Add(extension.Description);

						item.Tag = extension;

						list.Items.Add(item);
					}
				}

				list.EndUpdate();
			}
		}

		private void list_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (list.Items != null)
			{
				if (list.Items.Count >= 1)
				{
					if (list.SelectedItems != null)
					{
						Extension extension = list.SelectedItems[0].Tag as Extension;

						if (extension != null)
						{
							using (ExtensionInformation informationWindow = new ExtensionInformation())
							{
								informationWindow.authorName = extension.Author;
								informationWindow.name = extension.Name;
								informationWindow.description = extension.Description;

								if (informationWindow.ShowDialog(this) == DialogResult.OK)
								{
								}
							}
						}
					}
				}
			}
		}
	}
}
