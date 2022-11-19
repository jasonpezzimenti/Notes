using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Notes.Note;

namespace Notes
{
	public partial class ViewAttachmentWindow : Form
	{
		[DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
		private static extern bool PlaySound(string szSound, System.IntPtr hMod, PlaySoundFlags flags);

		[System.Flags]
		public enum PlaySoundFlags : int
		{
			SND_SYNC = 0x0000,
			SND_ASYNC = 0x0001,
			SND_NODEFAULT = 0x0002,
			SND_LOOP = 0x0008,
			SND_NOSTOP = 0x0010,
			SND_NOWAIT = 0x00002000,
			SND_FILENAME = 0x00020000,
			SND_RESOURCE = 0x00040004
		}

		public Note thisNote;

		public bool needsSaving = false;

		public ViewAttachmentWindow(Note note)
		{
			InitializeComponent();

			thisNote = note;

			list.ContextMenu = contextMenu1;
		}

		private void ViewAttachmentWindow_Shown(object sender, EventArgs e)
		{
			list.BeginUpdate();

			foreach(Note.Attachment attachment in thisNote.Attachments)
			{
				if(attachment != null)
				{
					ListViewItem item = new ListViewItem();
					item.Text = Path.GetFileNameWithoutExtension(attachment.FileName);
					item.SubItems.Add(attachment.FileName);
					item.SubItems.Add(attachment.Type);
					item.Tag = attachment;

					list.Items.Add(item);
				}
			}

			list.EndUpdate();
		}

		private void transferToNoteContextMenuItem_Click(object sender, EventArgs e)
		{
			if(list.Items.Count > 0)
			{
				if (list.SelectedItems != null)
				{
					if (list.SelectedItems[0].Tag != null)
					{
						Attachment attachment = list.SelectedItems[0].Tag as Attachment;

						if(attachment != null)
						{
							// Show the dialog so the user can select which note to attach this attachment to.
							using (NoteSelectionWindow dialog = new NoteSelectionWindow())
							{
								if(dialog.ShowDialog(this) == DialogResult.OK)
								{
									Group group = dialog.selectedGroup;
									Note note = dialog.selectedNote;

									int indexOfGroup = Array.IndexOf(Window.stack.ToArray(), group);
									int indexOfNote = Array.IndexOf(Window.stack[indexOfGroup].Notes.ToArray(), note);

									Window.stack.Get(indexOfGroup).Notes[indexOfNote].Attachments.Add(attachment);

									this.DialogResult = DialogResult.OK;
								}
							}
						}
					}
				}
			}
		}

		private void menuItem1_Click(object sender, EventArgs e)
		{
			if (list.SelectedItems != null)
			{
				if (list.SelectedItems[0].Tag != null)
				{
					Attachment attachment = list.SelectedItems[0].Tag as Attachment;

					if (attachment != null)
					{
						byte[] data = attachment.FileData;

						try
						{
							File.WriteAllBytes(attachment.FileName, data);

							if (File.Exists(attachment.FileName))
							{
								PlaySound(data.ToString(), new System.IntPtr(), PlaySoundFlags.SND_SYNC);
							}
						}
						catch (Exception exception)
						{
							throw exception;
						}
					}
				}
			}
		}

		private void list_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if(list.Items != null)
			{
				if(list.Items.Count >= 1)
				{
					if(list.SelectedItems != null)
					{
						Attachment attachment = list.SelectedItems[0].Tag as Attachment;

						if (attachment != null)
						{
							byte[] data = attachment.FileData;

							string content = System.Text.Encoding.Default.GetString(data);

							File.WriteAllBytes(attachment.FileName, data);

							if (File.Exists(attachment.FileName))
							{
								Process.Start(attachment.FileName);
							}
						}
					}
				}
			}
		}

		private void menuItem4_Click(object sender, EventArgs e)
		{
			if(list.Items != null)
			{
				if(list.SelectedItems != null)
				{
					Attachment attachment = list.SelectedItems[0].Tag as Attachment;

					if(attachment != null)
					{
						Group group = Window.stack.Where<Group>(g => g.Notes.Contains(thisNote)).FirstOrDefault();

						if(group != null)
						{
							int indexOfGroup = Array.IndexOf(Window.stack.ToArray(), group);
							int indexOfNote = Array.IndexOf(group.Notes.ToArray(), thisNote);

							thisNote.Attachments.Remove(attachment);
							Window.stack[indexOfGroup].Notes[indexOfNote] = thisNote;

							list.Items.Remove(list.SelectedItems[0]);

							needsSaving = true;
						}
					}
				}
			}
		}

		private void ViewAttachmentWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;

			this.DialogResult = DialogResult.OK;

			e.Cancel = false;
		}
	}
}
