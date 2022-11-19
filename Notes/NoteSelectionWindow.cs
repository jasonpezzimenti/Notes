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
	public partial class NoteSelectionWindow : Form
	{
		public Note selectedNote;
		public Group selectedGroup;

		public NoteSelectionWindow()
		{
			InitializeComponent();

			
		}

		private void NoteSelectionWindow_Shown(object sender, EventArgs e)
		{
			foreach(Group group in Window.stack)
			{
				foreach(Note note in group.Notes)
				{
					listView1.BeginUpdate();

					ListViewItem item = new ListViewItem(group.Name);
					item.SubItems.Add(note.Name);

					listView1.Items.Add(item);

					listView1.EndUpdate();
				}
			}
		}

		private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Group group = Window.stack.Where<Group>(g => g.Name == listView1.SelectedItems[0].Text).FirstOrDefault();

			if (group != null)
			{
				Note note = group.Notes.Where<Note>(n => n.Name == listView1.SelectedItems[0].SubItems[1].Text).FirstOrDefault();
				if (note != null)
				{

					selectedGroup = group;
					selectedNote = note;

					this.DialogResult = DialogResult.OK;
				}
			}
		}
	}
}
