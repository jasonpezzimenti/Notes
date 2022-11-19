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
	public partial class PropertiesWindow : Form
	{
		public string noteName;
		public Note thisNote;
		public Note selectedNote;

		public PropertiesWindow(string name, string groupName, DateTime created, DateTime edited,Note note = null)
		{
			InitializeComponent();

			noteName = name;
			noteNameTextField.Text = name;
			locationLabel.Text = Program.documentFolderPath + @"\Groups\" + groupName + @"\" + name;
			dateCreatedLabel.Text = created.ToString();
			lastEditedLabel.Text = edited.ToString();

			thisNote = note;
		}

		private void cancelButton_Clicked(object sender, ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonClickedEventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void noteNameTextField_TextChanged(object sender, EventArgs e)
		{

		}

		private void applyChangesButton_Confirmed(object sender, ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonConfirmedEventArgs e)
		{
			noteName = noteNameTextField.Text;

			if(versionList.Items != null)
			{
				if(versionList.SelectedItems.Count >= 1)
				{
					Note note = versionList.SelectedItems[0].Tag as Note;

					if(note != null)
					{
						selectedNote = note;
					}
				}
			}
		}

		private void button1_Clicked(object sender, ALMSTWKND.UI.WindowsForms.Controls.Button.ButtonClickedEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void PropertiesWindow_Shown(object sender, EventArgs e)
		{
			if(thisNote != null)
			{
				foreach(PreviousVersion version in thisNote.PreviousVersions)
				{
					if (!version.Locked)
					{
						ListViewItem item = new ListViewItem();
						item.Text = version.Note.Name;
						item.Tag = thisNote;
						item.SubItems.Add(version.DateCreated.ToString());

						versionList.Items.Add(item);
					}
				}
			}
		}
	}
}
