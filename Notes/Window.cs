using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Windows.Shell;

namespace Notes
{
	public partial class Window : Form
	{
		[DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

		public FindAndReplace findAndReplaceWindow;
		public ApplicationSettings applicationSettings;

		private Timer autoSaveTimer;

		public static StackList<Group> stack;
		public StackList<Group> groupsToDelete;
		public static List<Extension> extensions;
		private List<int> queryMatches = new List<int>();

		private string previousName = String.Empty,
			selectedGroupName,
			dragDropContent;
		private bool nodeClicked;
		private static bool needsSaving;
		private string searchableContent;
		private string match;
		private int matches, matchIndex = -1;
		private string query;


		public static Form window = null;
		public static CustomTreeView thisList;
		public static TextBox thisEditor;
		private string editorContent;

		public Window()
		{
			InitializeComponent();

			window = this;

			findAndReplaceWindow = new FindAndReplace();
			findAndReplaceWindow.findButton.Click += FindButton_Click;
			findAndReplaceWindow.findTextField.TextChanged += FindTextField_TextChanged;
			findAndReplaceWindow.replaceAllButton.Click += ReplaceAllButton_Click;

			stack = new StackList<Group>();
			groupsToDelete = new StackList<Group>();

			list.ContextMenu = listContextMenu;

			applicationSettings = new ApplicationSettings();
			extensions = new List<Extension>();

			thisList = new CustomTreeView();
			thisList = list;

			autoSaveTimer = new Timer();
			autoSaveTimer.Interval = 15000;
			autoSaveTimer.Tick += AutoSaveTimer_Tick;

			thisEditor = new TextBox();
			thisEditor.TextChanged += ThisEditor_TextChanged;
		}

		private void AutoSaveTimer_Tick(object sender, EventArgs e)
		{
			if (autoSaveMainMenuItem.Checked)
			{
				// Super buggy. Don't enable until fixed.
				//statePanel.Text = "State: Creating Previous Version.";

				//// Get the selected note.
				//if (list.SelectedNode.Parent != null)
				//{
				//	string groupName = list.SelectedNode.Parent.Text;
				//	string noteName = list.SelectedNode.Text;

				//	Group thisGroup = stack.Where(g => g.Name == groupName).FirstOrDefault();

				//	if (thisGroup != null)
				//	{
				//		Note note = thisGroup.Notes.Where(n => n.Name == noteName).FirstOrDefault();

				//		if (note != null)
				//		{
				//			PreviousVersion version = new PreviousVersion();
				//			version.DateCreated = DateTime.Now;

				//			note.Content = editorContent;

				//			version.Note = note;

				//			note.PreviousVersions.Add(version);

				//			statePanel.Text = "State: Previous Version created.";
				//		}
				//	}
				//}

				statePanel.Text = "State: Auto-saving changes.";
				statePanel.Text = "State: Writing to disk.";

				foreach (Group group in stack)
				{
					JsonSerializerOptions options = new JsonSerializerOptions()
					{
						IncludeFields = true
					};

					try
					{
						string data = JsonSerializer.Serialize(group, options);

						if (!String.IsNullOrEmpty(data))
						{
							statePanel.Text = "Writing " + Program.documentFolderPath + @"\Groups" + @"\" + group.Name + ".json to disk.";
							File.WriteAllText(Program.documentFolderPath + @"\Groups" + @"\" + group.Name + ".json", data, Encoding.UTF8);
						}
					}
					catch (Exception exception)
					{
						statePanel.Text = "State: Abnormal.";
					}
				}

				statePanel.Text = "State: Deleting Groups that are no longer needed.";

				DeleteGroupsNotNeeded();

				statePanel.Text = "State: Saving Settings.";

				string settingsData = JsonSerializer.Serialize(applicationSettings);

				if (!String.IsNullOrEmpty(settingsData))
				{
					if (!Directory.Exists(Program.documentFolderPath + @"\Settings\"))
					{
						Directory.CreateDirectory(Program.documentFolderPath + @"\Settings");
					}

					File.WriteAllText(Program.documentFolderPath + @"\Settings\Settings.json", settingsData, Encoding.UTF8);
				}

				needsSaving = false;
				changesNeedSavingPanel.Text = "";



				statePanel.Text = "State: Idle.";
			}
		}

		private void ReplaceAllButton_Click(object sender, EventArgs e)
		{
			if (editor.Enabled)
			{
				if (editor.Text.Length >= 1)
				{
					editor.Text = editor.Text.Replace(findAndReplaceWindow.findTextField.Text, findAndReplaceWindow.replaceWithTextField.Text);
				}
			}
		}

		private void FindTextField_TextChanged(object sender, EventArgs e)
		{
			query = findAndReplaceWindow.findTextField.Text;
		}

		public void ProtectNote(Note note)
		{

		}

		public static void UnprotectNote(Note note)
		{

		}

		public byte[] EncryptString(string content, byte[] key, byte[] IV)
		{
			byte[] result = new byte[0];

			if (!String.IsNullOrEmpty(content) && key != null && key.Length >= 1 && IV != null && IV.Length >= 1)
			{
				using (Aes AESAlgorithm = Aes.Create())
				{
					AESAlgorithm.Key = key;
					AESAlgorithm.IV = IV;

					ICryptoTransform encryptor = AESAlgorithm.CreateEncryptor(AESAlgorithm.Key, AESAlgorithm.IV);

					using (MemoryStream memoryStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
						{
							using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
							{
								streamWriter.Write(content);
							}

							result = memoryStream.ToArray();
						}
					}
				}
			}

			return result;
		}

		public string DecryptString(byte[] cipherText, byte[] key, byte[] IV)
		{
			string result = String.Empty;

			if (cipherText != null && cipherText.Length >= 1 && key != null && key.Length >= 1 && IV != null && IV.Length >= 1)
			{
				using (Aes aesAlgorithm = Aes.Create())
				{
					aesAlgorithm.Key = key;
					aesAlgorithm.IV = IV;

					ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor(aesAlgorithm.Key, aesAlgorithm.IV);

					using (MemoryStream memoryStream = new MemoryStream(cipherText))
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
						{
							using (StreamReader streamReader = new StreamReader(cryptoStream))
							{
								result = streamReader.ReadToEnd();
							}
						}
					}
				}
			}

			return result;
		}

		private void ThisEditor_TextChanged(object sender, EventArgs e)
		{
			editor.Text = thisEditor.Text;
		}

		//public void Interpret(StackList<Token> tokens)
		//{
		//	bool isExpectingType = true,
		//		isExpectingIdentifier = false,
		//		lookingForNote,
		//		isExpectingAction = false,
		//		isSettingContent = false,
		//		isExpectingString = false;
		//	TreeNode selectedNode;

		//	List<Token> theseTokens = tokens.ToList<Token>();
		//	theseTokens.Reverse();

		//	foreach (Token token in theseTokens)
		//	{
		//		Console.WriteLine(token.Type + " " + token.Value);
		//	}

		//	if (theseTokens != null)
		//	{
		//		Note note = new Note();
		//		Group group = new Group();

		//		for (int index = 0; index < theseTokens.Count; index++)
		//		{
		//			if (isExpectingType)
		//			{
		//				if (theseTokens[index].Type == "Type")
		//				{
		//					if (theseTokens[index].Value == "Note")
		//					{
		//						isExpectingIdentifier = true;
		//						isExpectingType = false;
		//						lookingForNote = true;
		//					}
		//				}
		//			}
		//			else if (isExpectingIdentifier)
		//			{
		//				if (theseTokens[index].Type == "Identifier")
		//				{
		//					// We have an identifier.
		//					if (theseTokens[index].Value == "SelectedNote")
		//					{
		//						// See if the list is null and if there is a selected node (note).
		//						if (list.Nodes != null && list.SelectedNode != null)
		//						{
		//							// Get the selected node.
		//							if (list.SelectedNode.Parent != null)
		//							{
		//								// This is not the Parent Node.
		//								selectedNode = list.SelectedNode;

		//								if (selectedNode != null)
		//								{
		//									isExpectingAction = true;
		//									isExpectingIdentifier = false;

		//									continue;
		//								}
		//							}
		//						}
		//					}
		//				}
		//			}
		//			else if (isExpectingAction)
		//			{
		//				if (theseTokens[index].Type == "Action")
		//				{
		//					if (theseTokens[index].Value == "SetContent")
		//					{
		//						isSettingContent = true;
		//						isExpectingAction = false;
		//						isExpectingString = true;
		//					}
		//				}
		//			}
		//			else if (isExpectingString)
		//			{
		//				if (theseTokens[index].Type == "Identifier")
		//				{
		//					string content = theseTokens[index].Value;

		//					// Get the note and add the content to it.
		//					Group thisGroup = stack.Where(i => i.Name == list.SelectedNode.Parent.Text).FirstOrDefault();

		//					Note thisNote = thisGroup.Notes.Where(n => n.Name == list.SelectedNode.Text).FirstOrDefault();

		//					if (thisNote != null)
		//					{
		//						editor.Text = content;
		//					}
		//				}
		//			}
		//		}
		//	}
		//}

		private void FindButton_Click(object sender, EventArgs e)
		{
			if (editor.Enabled)
			{
				if (editor.Text.Length >= 1)
				{
					for (int index = 0; index < editor.Text.Length; index++)
					{
						for (int indexOfQuery = 0; indexOfQuery < query.Length; indexOfQuery++)
						{
							if (editor.Text[index] == query[indexOfQuery])
							{
								queryMatches.Add(index);
								break;
							}
						}
					}

					editor.SelectionStart = queryMatches[0];
					editor.SelectionLength = query.Length;
					queryMatches.RemoveAt(0);
				}
			}
		}

		private void newGroupMenuItem_Click(object sender, EventArgs e)
		{
			CreateNewGroup();
			ConveyThatChangesNeedSaving();

		}

		private void newNoteMenuItem_Click(object sender, EventArgs e)
		{
			list.BeginUpdate();

			list.SelectedNode.Nodes.Add("Untitled").Tag = stack.Count + 1.ToString();

			if (list.SelectedNode.Parent == null)
			{
				Group group = stack.Where<Group>(g => g.Name == list.SelectedNode.Text).FirstOrDefault();

				if (group != null)
				{
					group.Notes.Add(new Note()
					{
						Name = "Untitled",
						Created = DateTime.Now
					});
				}
			}

			list.EndUpdate();

			if (list.SelectedNode.Parent != null)
			{
				// We have a Parent Node. Expand it for the User.
				list.SelectedNode.Parent.Expand();

			}

			ConveyThatChangesNeedSaving();
		}

		private void newGroupContextMenuItem_Click(object sender, EventArgs e)
		{
			CreateNewGroup();

			ConveyThatChangesNeedSaving();
		}

		private void CreateNewGroup()
		{
			using (NewGroupWindow newGroupWindow = new NewGroupWindow())
			{
				if (newGroupWindow.ShowDialog(this) == DialogResult.OK)
				{
					string groupName = newGroupWindow.groupName;

					if (!String.IsNullOrEmpty(groupName))
					{
						// Create a new TreeView Group.
						Group group = new Group();
						group.Id = stack.Count;
						group.Name = groupName;
						group.Notes.Add(new Note() { Name = "Untitled" });

						stack.Add(group);

						list.BeginUpdate();

						list.Nodes.Add(groupName);

						list.EndUpdate();

						thisList = list;
					}
				}
			}
		}

		private void CreateNewGroup(string name)
		{
			// Create a new TreeView Group.
			Group group = new Group();
			group.Id = stack.Count;
			group.Name = name;
			group.Notes.Add(new Note() { Name = "Untitled" });

			stack.Add(group);

			list.BeginUpdate();

			TreeNode node = list.Nodes.Add(name);

			list.EndUpdate();

			if (node != null)
			{
				list.SelectedNode = node;
				node.EnsureVisible();

				CreateNewNote();
			}
		}

		private void newNoteContextMenuItem_Click(object sender, EventArgs e)
		{
			CreateNewNote();
			ConveyThatChangesNeedSaving();

		}

		private void CreateNewNote()
		{
			list.BeginUpdate();

			if (list.SelectedNode != null)
			{
				list.SelectedNode.Nodes.Add("Untitled");

				Group group = stack.Where<Group>(g => g.Name == list.SelectedNode.Text).FirstOrDefault();

				if (group != null)
				{
					group.Notes.Add(new Note()
					{
						Name = "Untitled",
						Created = DateTime.Now
					});
				}
				else
				{
				}
			}

			list.EndUpdate();

			if (list.SelectedNode.Parent != null)
			{
				// We have a Parent Node. Expand it for the User.
				list.SelectedNode.Parent.Expand();

			}

			thisList = list;
		}

		private void renameContextMenuItem_Click(object sender, EventArgs e)
		{
			RenameNode();
		}

		private void RenameNode()
		{
			if (list.LabelEdit)
			{
				if (list.Nodes != null && list.Nodes.Count >= 1)
				{
					list.SelectedNode.BeginEdit();
				}
			}
		}

		private void editor_TextChanged(object sender, EventArgs e)
		{
			if (!nodeClicked)
			{
				if (list.SelectedNode != null && list.SelectedNode.Parent != null)
				{
					editorContent = editor.Text;

					Group group = stack.Where<Group>(g => g.Name == list.SelectedNode.Parent.Text).FirstOrDefault();

					int indexOfGroup = Array.IndexOf(stack.ToArray(), group);

					if (indexOfGroup > -1)
					{
						if (group != null)
						{
							Note note = group.Notes.Where<Note>(n => n.Name == list.SelectedNode.Text).FirstOrDefault();

							if (note != null)
							{
								int indexOfNote = Array.IndexOf(group.Notes.ToArray(), note);

								if (indexOfNote > -1)
								{
									stack[indexOfGroup].Notes[indexOfNote].Content = editor.Text;
									stack[indexOfGroup].Notes[indexOfNote].LastEdited = DateTime.Now;

									note = null;
									group = null;

									needsSaving = true;

									changesNeedSavingPanel.Width = 149;
									changesNeedSavingPanel.Text = "Changes need saving.";
								}
							}
						}
					}
				}
			}
			else
			{
				nodeClicked = false;
			}

			// Update the Line-count and Character-count.
			lineCountPanel.Text = "Lines: " + editor.Lines.Count();
			characterCountPanel.Text = "Characters: " + editor.Text.Length;
		}

		private void Window_Shown(object sender, EventArgs e)
		{
			// Hide the Form until it's read to be displayed so you don't see
			// the form moving around while it's being centered.
			// Can't remember if this is an actual problem or not. But doing it anyway.
			this.Hide();

			//PerformStartupOperations();

			//CreateStartupNote();
			//AddExistingNotesToList();

			// Load app and user settings.
			if (File.Exists(Program.documentFolderPath + @"\Settings\Settings.json"))
			{
				string appSettingsData = File.ReadAllText(Program.documentFolderPath + @"\Settings\Settings.json");

				if (!String.IsNullOrEmpty(appSettingsData))
				{
					applicationSettings = JsonSerializer.Deserialize<ApplicationSettings>(appSettingsData);

					if (applicationSettings != null)
					{
						if (applicationSettings.WindowState == FormWindowState.Normal)
						{
							this.Size = applicationSettings.WindowSize;

							if (applicationSettings.RememberWindowPosition)
							{
								if (applicationSettings.WindowPosition == Point.Empty)
								{
									this.StartPosition = FormStartPosition.CenterScreen;
								}
								else
								{
									this.Location = applicationSettings.WindowPosition;
								}
							}
							else
							{
								this.StartPosition = FormStartPosition.CenterScreen;
							}

							this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2), (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2));
						}
						else if (applicationSettings.WindowState == FormWindowState.Minimized)
						{
							this.WindowState = FormWindowState.Minimized;
						}
						else if (applicationSettings.WindowState == FormWindowState.Maximized)
						{
							this.WindowState = FormWindowState.Maximized;
						}

						splitContainer1.SplitterDistance = applicationSettings.SplitterPosition;

						if (applicationSettings.AutoSaveChanges)
						{
							autoSaveTimer.Start();
							autoSaveMainMenuItem.Checked = true;
						}
						else
						{
							autoSaveTimer.Stop();
							autoSaveMainMenuItem.Checked = false;
						}
					}
				}
			}

			statePanel.Text = "State: Importing Notes.";

			foreach (Group group in Program.stack)
			{
				stack.Add(group);
			}

			Program.stack = null;

			list.BeginUpdate();

			foreach (Group group in stack)
			{
				TreeNode groupNode = list.Nodes.Add(group.Name);

				if (groupNode != null)
				{
					foreach (Note note in group.Notes)
					{
						if (String.IsNullOrEmpty(note.Name))
						{
							note.Name = "Untitled";
						}

						groupNode.Nodes.Add(note.Name);
					}
				}
			}

			list.EndUpdate();



			if (File.Exists(Program.documentFolderPath + @"\Extensions.json"))
			{
				string data = File.ReadAllText(Program.documentFolderPath + @"\Extensions.json");

				if (data != null)
				{
					JsonSerializerOptions options = new JsonSerializerOptions()
					{
						IncludeFields = true
					};

					extensions = (List<Extension>)JsonSerializer.Deserialize(data, typeof(List<Extension>));

					if (extensions != null && extensions.Count >= 1)
					{
						foreach (Extension extension in extensions)
						{
							string filePath = extension.Path;

							if (File.Exists(filePath))
							{
								MenuItem item = new MenuItem(extension.Name);
								item.Tag = extension;
								item.ShowShortcut = true;

								if (extension.Shortcut != null)
								{
									// Get the shortcut for this menu item.
									string[] shortcutKeys = extension.Shortcut.Split('+');
									string shortcutString = shortcutKeys[0] + shortcutKeys[1];

									/// Jimi from StackOverflow: https://stackoverflow.com/a/74311095/20283719
									var shortcut = Enum.Parse(typeof(Shortcut), shortcutString);

									item.Shortcut = (Shortcut)shortcut;
								}

								item.Click += MenuItem_Click;

								if (extension.AffectedEntity == "Group")
								{
									if (extension.MenuBound)
									{
										menuItem43.MenuItems.Add(item);
									}
									else
									{
										item.Visible = false;
										menuItem43.MenuItems.Add(item);
									}
								}
								else
								{
									if (extension.MenuBound)
									{
										menuItem46.MenuItems.Add(item);
									}
									else
									{
										item.Visible = false;
										menuItem46.MenuItems.Add(item);
									}
								}
							}
						}
					}
				}
			}

			changesNeedSavingPanel.Width = 0;
			changesNeedSavingPanel.Text = "";

			statePanel.Text = "State: Idle.";

			this.Show();
		}

		private void AddExistingNotesToList()
		{
			foreach (Group group in Program.stack)
			{
				CreateNewGroup(group.Name);

				TreeNode[] nodes = list.Nodes.Find(group.Name, true);

				foreach (TreeNode node in nodes)
				{
					try
					{
						foreach (Note note in group.Notes)
						{
							node.Nodes.Add(note.Name);
						}
					}
					catch (Exception exception)
					{
						throw exception;
					}
				}
			}
		}

		private void PersistChangesToNote(TreeNode e, string content)
		{
			if (e != null)
			{
				string name = e.Text;

				Group group = stack.Where<Group>(g => g.Name == e.Parent.Text).FirstOrDefault();

				if (group != null)
				{
					int indexOfGroup = Array.IndexOf(stack.ToArray(), group);

					Note note = group.Notes.Where<Note>(n => n.Name == name).FirstOrDefault();

					if (note != null)
					{
						int indexOfNote = Array.IndexOf(group.Notes.ToArray(), note);

						stack[indexOfGroup].Notes[indexOfNote].Content = content;
					}
				}
			}
		}

		private void PersistGroupNameChange(TreeNode e, string previousName, string name)
		{
			if (e != null)
			{
				Group group = stack.Where<Group>(g => g.Name == previousName).FirstOrDefault();

				if (group != null)
				{
					int indexOfGroup = Array.IndexOf(stack.ToArray(), group);

					stack[indexOfGroup].Name = name;
				}
			}
		}

		private void CreateStartupNote()
		{
			if (Directory.Exists(Program.documentFolderPath + @"\Groups"))
			{
				if (!list.Nodes.ContainsKey("Miscellaneous"))
				{
					CreateNewGroup("Miscellaneous");
				}
			}
		}

		private void deleteContextMenuItem_Click(object sender, EventArgs e)
		{
			DeleteSelectedNoteOrGroup();

			ConveyThatChangesNeedSaving();
		}

		private void DeleteSelectedNoteOrGroup()
		{
			statePanel.Text = "State: Working.";

			if (list.Nodes != null && list.Nodes.Count >= 1)
			{
				// Determine whether the selected Node has a Parent.
				if (list.SelectedNode.Parent == null)
				{
					// There is no Parent Node. That means this is the Parent Node.
					// Delete its corresponding Group, and then delete the node.
					if (MessageBox.Show(this, "Are you sure you want to delete this Group?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Group group = stack.Where<Group>(g => g.Name == list.SelectedNode.Text).FirstOrDefault();

						if (group != null)
						{
							if (File.Exists(Program.documentFolderPath + @"\Groups" + @"\" + group.Name + ".json"))
							{
								try
								{
									File.Delete(Program.documentFolderPath + @"\Groups" + @"\" + group.Name + ".json");

									stack.RemoveByItem(group);
									list.Nodes.Remove(list.SelectedNode);
									needsSaving = true;
								}
								catch (Exception exception)
								{
									throw exception;
								}
							}
						}
					}
				}
				else
				{
					// There is a Parent Node, and this is its Child Node.
					if (MessageBox.Show(this, "Are you sure you want to delete this Note?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Group group = stack.Where<Group>(g => g.Name == list.SelectedNode.Parent.Text).FirstOrDefault();

						if (group != null)
						{
							int indexOfGroup = Array.IndexOf(stack.ToArray(), group);

							Note note = group.Notes.Where<Note>(n => n.Name == list.SelectedNode.Text).FirstOrDefault();

							if (note != null)
							{
								int indexOfNote = Array.IndexOf(group.Notes.ToArray(), note);

								stack[indexOfGroup].Notes.RemoveAt(indexOfNote);
								list.Nodes.Remove(list.SelectedNode);
							}
						}
					}
				}
			}

			statePanel.Text = "State: Idle.";
		}

		private Note GetSelectedNoteFromGroup(Group group, string noteName)
		{
			return group.Notes.Where<Note>((value, i) => value.Name == noteName).FirstOrDefault();
		}

		private void saveMenuItem_Click(object sender, EventArgs e)
		{
			statePanel.Text = "State: Writing to disk.";

			foreach (Group group in stack)
			{
				JsonSerializerOptions options = new JsonSerializerOptions()
				{
					IncludeFields = true
				};

				string data = JsonSerializer.Serialize(group, options);

				if (!String.IsNullOrEmpty(data))
				{
					File.WriteAllText(Program.documentFolderPath + @"\Groups" + @"\" + group.Name + ".json", data, Encoding.UTF8);
				}
			}

			statePanel.Text = "State: Deleting Groups no longer needed.";

			DeleteGroupsNotNeeded();

			statePanel.Text = "State: Saving Settings.";

			string settingsData = JsonSerializer.Serialize(applicationSettings);

			if (!String.IsNullOrEmpty(settingsData))
			{
				if (!Directory.Exists(Program.documentFolderPath + @"\Settings\"))
				{
					Directory.CreateDirectory(Program.documentFolderPath + @"\Settings");
				}

				File.WriteAllText(Program.documentFolderPath + @"\Settings\Settings.json", settingsData, Encoding.UTF8);
			}

			needsSaving = false;
			changesNeedSavingPanel.Text = "";

			statePanel.Text = "State: Idle.";
		}

		private void DeleteGroupsNotNeeded()
		{
			if (groupsToDelete != null)
			{
				foreach (Group group in groupsToDelete)
				{
					try
					{
						//File.Delete(Program.documentFolderPath + @"\Groups" + @"\" + group.Name + ".json");
					}
					catch (Exception exception)
					{
						throw exception;
					}
				}
			}
		}

		//private void list_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		//{
		//	if (e.Node.Parent == null)
		//	{
		//		// We're dealing with a Parent Node.
		//		Console.WriteLine("The Parent Node is NULL.");
		//	}
		//	else
		//	{
		//		DisplayNote(e);
		//	}
		//}

		private void DisplayNote(TreeNodeMouseClickEventArgs e)
		{
			nodeClicked = true;


			string name = e.Node.Text;

			this.Text = name + " - " + "Notes";

			// Determine whether we're dealing with a Parent or Child Node.
			if (list.Nodes.Count >= 1)
			{
				if (list.SelectedNode != null)
				{
					var selectedNode = list.SelectedNode;

					if (selectedNode.Nodes.Count < 1)
					{
						// This is the Parent Node.

					}
					else
					{
						// Get the Group associated with the TreeNode.
						if (e.Node.Parent != null)
						{
							string groupName = selectedGroupName;

							Group group = stack.Where<Group>(g => g.Name == groupName).FirstOrDefault();

							if (group != null)
							{
								// Get the note.
								Note note = group.Notes.Where<Note>(n => n.Name == e.Node.Text).FirstOrDefault();

								if (note != null)
								{
									string content = note.Content;
									editor.Text = content;
									searchableContent = editor.Text;
									content = String.Empty;
								}
								else
								{
									editor.Text = String.Empty;
								}
							}
						}
						else
						{
						}
					}
				}
			}
		}

		//private void list_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		//{
		//	if (e.Button == MouseButtons.Left)
		//	{
		//		if (e.Node.Parent == null)
		//		{
		//			selectedGroupName = e.Node.Text;

		//			if (editor.Enabled)
		//			{
		//				editor.Enabled = false;
		//			}
		//		}
		//		else
		//		{
		//			DisplayPropertiesWindow();

		//			//[Obsolete]
		//			//DisplayNote(e);

		//			//if (!editor.Enabled)
		//			//{
		//			//	editor.Enabled = true;
		//			//}
		//		}
		//	}
		//}

		private void DisplayPropertiesWindow()
		{
			if (list.SelectedNode.Parent == null)
			{
				// Display Properties for a Group.
			}
			else
			{
				Group group = stack.Where<Group>(g => g.Name == list.SelectedNode.Parent.Text).FirstOrDefault();

				if (group != null)
				{
					int indexOfGroup = Array.IndexOf(stack.ToArray(), group);

					Note note = group.Notes.Where<Note>(n => n.Name == list.SelectedNode.Text).FirstOrDefault();

					if (note != null)
					{
						int indexOfNote = stack[indexOfGroup].Notes.IndexOf(note);

						using (PropertiesWindow window = new PropertiesWindow(list.SelectedNode.Text, list.SelectedNode.Parent.Text, note.Created, note.LastEdited, note))
						{
							if (window.ShowDialog(this) == DialogResult.OK)
							{
								// Save any changes maded inside the Properties window.
								statePanel.Text = "Changing Note name.";

								string noteName = window.noteName;
								stack[indexOfGroup].Notes[indexOfNote].Name = noteName;
								list.SelectedNode.Text = noteName;

								statePanel.Text = "State: Idle.";

								statePanel.Text = "State: Restoring Previous Version of this Note.";

								list.SelectedNode.Text = window.selectedNote.Name;
								editor.Text = window.selectedNote.Content;

								needsSaving = true;
							}
						}
					}
				}
			}
		}

		private void Window_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;

			if (needsSaving)
			{
				if (MessageBox.Show(this, "Are you sure you want to exit without saving changes?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					// Save changes.
					foreach (Group group in stack)
					{
						JsonSerializerOptions options = new JsonSerializerOptions()
						{
							IncludeFields = true
						};

						try
						{
							string data = JsonSerializer.Serialize(group, options);

							if (!String.IsNullOrEmpty(data))
							{
								File.WriteAllText(Program.documentFolderPath + @"\Groups" + @"\" + group.Name + ".json", data, Encoding.UTF8);
							}
						}
						catch (Exception exception)
						{
							statePanel.Text = "State: Abnormal.";
						}
					}

					DeleteGroupsNotNeeded();

					needsSaving = false;

					if (extensions != null && extensions.Count >= 1)
					{
						var data = JsonSerializer.Serialize(extensions);

						if (!String.IsNullOrEmpty(data))
						{
							File.WriteAllText(Program.documentFolderPath + @"\Extensions.json", data);
						}
					}
					e.Cancel = false;
				}
				else
				{
					if (extensions != null && extensions.Count >= 1)
					{
						var data = JsonSerializer.Serialize(extensions);

						if (!String.IsNullOrEmpty(data))
						{
							File.WriteAllText(Program.documentFolderPath + @"\Extensions.json", data);
						}
					}
				}


				if (applicationSettings != null)
				{
					applicationSettings.WindowState = this.WindowState;

					var settingsData = JsonSerializer.Serialize(applicationSettings);

					if (!String.IsNullOrEmpty(settingsData))
					{
						File.WriteAllText(Program.documentFolderPath + @"\Settings\Settings.json", settingsData);
					}
				}
			}
			else
			{
				if (extensions != null && extensions.Count >= 1)
				{
					var data = JsonSerializer.Serialize(extensions);

					if (!String.IsNullOrEmpty(data))
					{
						File.WriteAllText(Program.documentFolderPath + @"\Extensions.json", data);
					}
				}

				if (applicationSettings != null)
				{
					applicationSettings.WindowState = this.WindowState;

					var settingsData = JsonSerializer.Serialize(applicationSettings);

					if (!String.IsNullOrEmpty(settingsData))
					{
						File.WriteAllText(Program.documentFolderPath + @"\Settings\Settings.json", settingsData);
					}
				}

				e.Cancel = false;
			}
		}

		private void createBackupMenuItem_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				folderBrowserDialog.Description = "Choose where to save your Backup.";
				folderBrowserDialog.ShowNewFolderButton = true;

				if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
				{
					try
					{
						ZipFile.CreateFromDirectory(Program.documentFolderPath + "Groups", folderBrowserDialog.SelectedPath);
					}
					catch (Exception exception)
					{
						throw exception;
					}
				}
			}
		}

		private void listContextMenu_Popup(object sender, EventArgs e)
		{
			// Determins whether there is a Parent Node.
			if (list.Nodes != null && list.Nodes.Count >= 1)
			{
				if (list.SelectedNode.Parent == null)
				{
					// We're dealing with the parent node so we don't want certain things available.
					attachmentsListContextMenuItem.Visible = false;
					attachmentsSeparator.Visible = false;
				}
				else
				{
					attachmentsListContextMenuItem.Visible = true;
					attachmentsSeparator.Visible = true;
				}

				if (list.SelectedNode != null)
				{
					newNoteContextMenuItem.Enabled = true;

				}
				else
				{
					newNoteContextMenuItem.Enabled = false;
				}
			}
			else
			{
				newNoteContextMenuItem.Enabled = false;
			}
		}

		private void menuItem8_Popup(object sender, EventArgs e)
		{
			// Determins whether there is a Parent Node.
			if (list.Nodes != null && list.Nodes.Count >= 1)
			{
				if (list.SelectedNode != null)
				{
					newNoteMenuItem.Enabled = true;

				}
				else
				{
					newNoteMenuItem.Enabled = false;
				}
			}
			else
			{
				newNoteMenuItem.Enabled = false;
			}
		}

		private void importMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.Multiselect = true;
				dialog.Filter = "Zip Files (*.zip)|*.zip";

				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					string filePath = dialog.FileName;

					try
					{
						ZipFile.ExtractToDirectory(filePath, Program.documentFolderPath + @"\Groups");

						DirectoryInfo directoryInformation = new DirectoryInfo(Program.documentFolderPath + @"\Groups");
						if (directoryInformation.Exists)
						{
							string[] files = Directory.EnumerateFiles(Program.documentFolderPath + @"\Groups").ToArray();

							if (files != null)
							{
								foreach (string file in files)
								{
									// Load all Groups and display them in the TreeView control.

									try
									{
										Group group = JsonSerializer.Deserialize<Group>(file);

										if (group != null)
										{
											stack.Add(group);
										}
									}
									catch (Exception exception)
									{
									}
								}
							}
							else
							{
								MessageBox.Show(this, "There are no groups to import or importing them was unsuccessful.", "Import Unsuccessful", MessageBoxButtons.OK);
							}
						}
					}
					catch (Exception exception)
					{
						throw exception;
					}
				}
			}
		}

		private void menuItem20_Click(object sender, EventArgs e)
		{
			if (editor.CanUndo)
			{
				editor.Undo();
			}
		}

		private void menuItem21_Click(object sender, EventArgs e)
		{
			if (editor.CanUndo)
			{
				editor.Undo();
			}
		}

		private void menuItem23_Click(object sender, EventArgs e)
		{
			editor.Cut();
		}

		private void menuItem24_Click(object sender, EventArgs e)
		{
			editor.Copy();
		}

		private void menuItem25_Click(object sender, EventArgs e)
		{
			editor.Paste();
		}

		private void menuItem27_Click(object sender, EventArgs e)
		{
			editor.SelectAll();
		}

		private void menuItem28_Click(object sender, EventArgs e)
		{
			editor.SelectedText = String.Empty;
		}

		private void menuItem30_Click(object sender, EventArgs e)
		{
			if (editor.Enabled)
			{
				editor.Text.Insert(editor.SelectionStart, DateTime.Now.ToString("g"));
			}
		}

		private void menuItem14_Click(object sender, EventArgs e)
		{
			using (PrintDialog dialog = new PrintDialog())
			{
				dialog.AllowPrintToFile = true;
				dialog.AllowSelection = true;
				dialog.AllowSomePages = true;

				dialog.ShowNetwork = true;

				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					// TODO: Print the document.

				}
			}
		}

		private void menuItem13_Click(object sender, EventArgs e)
		{
			using (PrintPreviewDialog dialog = new PrintPreviewDialog())
			{
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					// TODO: PrintPreview.
				}
			}
		}

		private void wordWrapMenuItem_Click(object sender, EventArgs e)
		{
			if (wordWrapMenuItem.Checked)
			{
				wordWrapMenuItem.Checked = false;
				editor.WordWrap = false;
			}
			else
			{
				wordWrapMenuItem.Checked = true;
				editor.WordWrap = true;
			}
		}

		private void menuItem35_Click(object sender, EventArgs e)
		{
			using (FontDialog dialog = new FontDialog())
			{
				dialog.AllowScriptChange = true;
				dialog.AllowSimulations = true;
				dialog.AllowVectorFonts = true;
				dialog.AllowVerticalFonts = true;

				dialog.ShowApply = true;
				dialog.ShowColor = true;

				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					editor.Font = dialog.Font;
					editor.ForeColor = dialog.Color;

					// Change the Font globally.
					needsSaving = true;
					ConveyThatChangesNeedSaving();
				}
			}
		}

		private void editor_DragDrop(object sender, DragEventArgs e)
		{
			if (!String.IsNullOrEmpty(dragDropContent))
			{
				editor.Text = editor.Text + dragDropContent;
			}
		}

		private void menuItem17_Click(object sender, EventArgs e)
		{
			statePanel.Text = "State: Loading Extension.";

			// TEST CODE ONLY:
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.Multiselect = false;
				dialog.Title = "Import an Extension";

				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					string file = dialog.FileName;

					if (File.Exists(file))
					{
						try
						{
							ZipFile.ExtractToDirectory(file, Path.GetDirectoryName(file));

							// See if ExtensionInformation.json has been extracted.
							string directory = Path.GetDirectoryName(file);

							if (File.Exists(directory + @"\ExtensionInformation.json"))
							{
								string extensionInformationData = File.ReadAllText(directory + @"\ExtensionInformation.json");

								if (!String.IsNullOrEmpty(extensionInformationData))
								{
									Extension extension = new Extension();
									extension = JsonSerializer.Deserialize<Extension>(extensionInformationData);

									if (extension != null)
									{
										if (!extensions.Contains(extension))
										{
											statePanel.Text = "State: Idle.";

											if (extension.MenuBound)
											{
												MenuItem item = new MenuItem(extension.Name);
												item.Tag = extension;
												item.ShowShortcut = true;

												if (extension.Shortcut != null)
												{
													// Get the shortcut for this menu item.
													string[] shortcutKeys = extension.Shortcut.Split('+');
													string shortcutString = shortcutKeys[0] + shortcutKeys[1];

													/// Jimi from StackOverflow: https://stackoverflow.com/a/74311095/20283719
													var shortcut = Enum.Parse(typeof(Shortcut), shortcutString);

													item.Shortcut = (Shortcut)shortcut;
												}

												item.Click += MenuItem_Click;

												if (extension.AffectedEntity == "Group")
												{
													if (extension.MenuBound)
													{
														menuItem43.MenuItems.Add(item);
													}
													else
													{
														item.Visible = false;
														menuItem43.MenuItems.Add(item);
													}
												}
												else
												{
													if (extension.MenuBound)
													{
														menuItem46.MenuItems.Add(item);
													}
													else
													{
														item.Visible = false;
														menuItem46.MenuItems.Add(item);
													}
												}

												extensions.Add(extension);
											}
										}

										if (File.Exists(directory + @"\Extension.nisl"))
										{
											// The extension exists.
											// Store its location inside its corresponding Extension thingy.
											extensions[extensions.IndexOf(extension)].Path = (directory + @"\Extension.nisl");

											string extensionInformationDataToBeSaved = JsonSerializer.Serialize(extension);

											try
											{
												File.WriteAllText(directory + @"\ExtensionInformation.json", extensionInformationDataToBeSaved);

												// TODO: Do something.
												// I forgot what I had to do here.
											}
											catch (Exception exception)
											{
												throw exception;
											}
										}
									}
								}
							}

							statePanel.Text = "State: Idle.";

							// See if Extension.json has been extracted.
						}
						catch (Exception exception)
						{
							throw exception;
						}
					}
				}
			}
		}

		private void MenuItem_Click(object sender, EventArgs e)
		{
			// TODO: Run the extension.
			Extension extension = ((MenuItem)sender).Tag as Extension;

			if (extension != null)
			{
				// We've got an extension. Now load it for interpretation.
				if (File.Exists(extension.Path))
				{
					try
					{
						string content = File.ReadAllText(extension.Path);

						if (!String.IsNullOrEmpty(content))
						{
							// Run the tokenizer over the extension.
							statePanel.Text = "State: Tokenizing.";

							Tokenizer tokenizer = new Tokenizer();
							tokenizer.Tokenize(content);

							// Now run the interpreter.
							statePanel.Text = "State: Interpreting the Extension.";

							Interpreter interpreter = new Interpreter(tokenizer.tokens);
							interpreter.Interpret(list, editor);

							statePanel.Text = "State: Idle.";
						}
					}
					catch (Exception exception)
					{
						throw exception;
					}
				}
			}
		}

		private void DisplayMethodInformation(MethodInfo[] methodInformation)
		{
			for (int index = 0; index < methodInformation.Length; index++)
			{
				MethodInfo information = (MethodInfo)methodInformation[index];


				object result = information.Invoke(this, new object[] { editor.Text });

				string[] results = (string[])result;

				foreach (string r in results)
				{
				}
			}
		}

		private void menuItem19_Click(object sender, EventArgs e)
		{
			// TODO: Save stuff.

			this.Dispose(true);
		}

		private void propertiesContextMenuItem_Click(object sender, EventArgs e)
		{
			DisplayPropertiesWindow();
		}

		private void list_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (e.Node.Parent == null)
				{
					selectedGroupName = e.Node.Text;

					if (editor.Enabled)
					{
						editor.Enabled = false;
					}
				}
				else
				{
					DisplayPropertiesWindow();

					//[Obsolete]
					//DisplayNote(e);

					//if (!editor.Enabled)
					//{
					//	editor.Enabled = true;
					//}
				}
			}
		}

		private void list_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			string name = e.Label;

			if (e.Node != null)
			{
				if (list.SelectedNode.Nodes.Count == 0)
				{
					Group group = stack.Where<Group>(i => i.Name == e.Node.Parent.Text).FirstOrDefault();

					if (group != null)
					{
						int index = Array.IndexOf(stack.ToArray(), group);

						Note note = stack[index].Notes.Where(i => i.Name == previousName).FirstOrDefault();

						if (note != null)
						{
							int indexOfNote = Array.IndexOf(stack[index].Notes.ToArray(), note);

							stack[index].Notes[indexOfNote].Name = name;
							ConveyThatChangesNeedSaving();

						}
					}
				}
				else
				{
					// We're working with a Group node.					
					Group group = stack.Where<Group>(g => g.Name == previousName).FirstOrDefault();

					if (group != null)
					{
						groupsToDelete.Add(group);
					}

					PersistGroupNameChange(list.SelectedNode, previousName, e.Label);
					needsSaving = true;
					ConveyThatChangesNeedSaving();
				}
			}
		}

		private void list_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (list.SelectedNode.Text == "Miscellaneous")
			{
				e.CancelEdit = true;
			}

			previousName = list.SelectedNode.Text;
		}

		private void list_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				DeleteSelectedNoteOrGroup();
				ConveyThatChangesNeedSaving();

			}
			else if (e.KeyCode == Keys.F2)
			{
				RenameNode();
				ConveyThatChangesNeedSaving();
			}
		}

		public void ConveyThatChangesNeedSaving()
		{
			if (applicationSettings != null)
			{
				if (applicationSettings.AutoSaveChanges)
				{
					this.changesNeedSavingPanel.Text = "Changes will be saved.";
				}
				else
				{
					this.changesNeedSavingPanel.Text = "Changes need saving.";
				}
			}
			else
			{
				this.changesNeedSavingPanel.Text = "Changes need saving.";
			}
		}

		private void openMenuItem_Click(object sender, EventArgs e)
		{
			//using (OpenFileDialog openFileDialog = new OpenFileDialog())
			//{
			//	openFileDialog.Multiselect = true;
			//	openFileDialog.Title = "Open"

			//	if(openFileDialog.ShowDialog(this) == DialogResult.OK)
			//	{

			//	}
			//}
		}

		private void menuItem40_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.Title = "Open Note(s)";
				dialog.Multiselect = true;

				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					if (dialog.FileNames != null)
					{
						string[] files = dialog.FileNames;

						foreach (string file in files)
						{
							using (StreamReader reader = new StreamReader(file))
							{
								reader.BaseStream.Position = 0;

								string content = String.Empty;

								try
								{
									while (!reader.EndOfStream)
									{
										content += reader.ReadToEnd();
									}

									if (!String.IsNullOrEmpty(content))
									{
										if (list.SelectedNode != null)
										{
											if (list.SelectedNode.Parent == null)
											{
												// This is the parent node.
												list.BeginUpdate();

												TreeNode thisNode = list.SelectedNode.Nodes.Add(Path.GetFileNameWithoutExtension(file));

												Group group = stack.Where(g => g.Name == list.SelectedNode.Text).FirstOrDefault();

												if (group != null)
												{
													group.Notes.Add(new Note()
													{
														Name = Path.GetFileNameWithoutExtension(file),
														Content = content,
														Created = DateTime.Now
													});

													needsSaving = true;
													ConveyThatChangesNeedSaving();

													list.EndUpdate();
												}
											}
											else
											{
												list.BeginUpdate();

												TreeNode thisNode = list.SelectedNode.Parent.Nodes.Add(Path.GetFileNameWithoutExtension(file));

												Group group = stack.Where(g => g.Name == list.SelectedNode.Text).FirstOrDefault();

												if (group != null)
												{
													group.Notes.Add(new Note()
													{
														Name = Path.GetFileNameWithoutExtension(file),
														Content = content,
														Created = DateTime.Now
													});

													needsSaving = true;
													ConveyThatChangesNeedSaving();

													list.EndUpdate();
												}
											}
										}
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
			}
		}

		private void DisplayErrorIconInStatusBar()
		{
			StatusBarPanel panel = new StatusBarPanel();

			Bitmap bitmap = new Bitmap(Properties.Resources.erroricon);

			Graphics graphics = this.CreateGraphics();
			graphics.DrawImage(bitmap, 16, 16);

			IntPtr hIcon = bitmap.GetHicon();

			Icon icon = Icon.FromHandle(hIcon);

			panel.Icon = icon;
			panel.MinWidth = 32;
			panel.AutoSize = StatusBarPanelAutoSize.Contents;
			panel.Text = "Error";

			statusbar.Panels.Add(panel);

			graphics.Dispose();
		}

		// For test purposes only.
		private void menuItem41_Click(object sender, EventArgs e)
		{
			TokenizerWorkingOLD tokenizer = new TokenizerWorkingOLD();
			tokenizer.Tokenize("Note.SelectedNote.SetContent: \"Hello.\"");

			Interpreter interpreter = new Interpreter(tokenizer.tokens.ToList());
			interpreter.Interpret(list, editor);
		}

		private void Window_SizeChanged(object sender, EventArgs e)
		{
			applicationSettings.WindowSize = this.Size;
			applicationSettings.WindowState = this.WindowState;
			ConveyThatChangesNeedSaving();
		}

		private void attachFileContextMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.Multiselect = true;
				dialog.Title = "Attach File(s)";

				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					foreach (string file in dialog.FileNames)
					{
						if (File.Exists(file))
						{
							byte[] data = File.ReadAllBytes(file);

							// Get the selected note.
							if (list.SelectedNode.Parent != null)
							{
								string noteName = list.SelectedNode.Text;

								if (!String.IsNullOrEmpty(noteName))
								{
									Group group = stack.Where(g => g.Name == list.SelectedNode.Parent.Text).FirstOrDefault();

									if (group != null)
									{
										int indexOfGroup = Array.IndexOf(stack.ToArray(), group);

										Note note = group.Notes.Where<Note>(n => n.Name == noteName).FirstOrDefault();

										if (note != null)
										{
											int indexOfNote = Array.FindIndex(group.Notes.ToArray(), (n => n.Name == noteName));

											group.Notes[indexOfNote].Attachments.Add(new Note.Attachment()
											{
												FileData = data,
												FileName = file,
												Type = Path.GetExtension(file)
											});
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void menuItem45_Click(object sender, EventArgs e)
		{
			if (list.SelectedNode.Parent != null)
			{
				string noteName = list.SelectedNode.Text;

				Group group = stack.Where(g => g.Name == list.SelectedNode.Parent.Text).FirstOrDefault();

				if (group != null)
				{
					Note note = group.Notes.Where(n => n.Name == noteName).FirstOrDefault();

					if (note != null)
					{
						using (ViewAttachmentWindow dialog = new ViewAttachmentWindow(note))
						{
							if (dialog.ShowDialog(this) == DialogResult.OK)
							{
								// TODO: Something.
								statePanel.Text = "State: Idle.";

								needsSaving = true;
								ConveyThatChangesNeedSaving();
							}
						}
					}
				}
			}
		}

		private void menuItem49_Click(object sender, EventArgs e)
		{
			if (menuItem49.Checked)
			{
				menuItem49.Checked = false;
				EndRecording();
			}
			else
			{
				menuItem49.Checked = true;

				RecordAudio();
			}
		}

		// Darin Dimitrov: https://stackoverflow.com/a/3694293/20283719
		private void RecordAudio()
		{
			statePanel.Text = "State: Recording audio.";

			mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
			mciSendString("record recsound", "", 0, 0);
		}

		// Darin Dimitrov: https://stackoverflow.com/a/3694293/20283719
		private void EndRecording()
		{
			statePanel.Text = "State: Saving recording.";

			if (!Directory.Exists(Program.documentFolderPath))
			{
				Directory.CreateDirectory(Program.documentFolderPath);
			}

			mciSendString("save recsound " + Program.documentFolderPath + @"\Untitled.wav", "", 0, 0);
			mciSendString("close recsound ", "", 0, 0);

			statePanel.Text = "State: Idle.";

			statePanel.Text = "State: Attempting to attach Audio to selected Note.";

			if (list.SelectedNode.Parent != null)
			{
				string noteName = list.SelectedNode.Text;

				if (!String.IsNullOrEmpty(noteName))
				{
					Group group = stack.Where<Group>(g => g.Name == list.SelectedNode.Parent.Text).FirstOrDefault();

					if (group != null)
					{
						byte[] data = File.ReadAllBytes(Program.documentFolderPath + @"\Untitled.wav");

						string fileName = String.Empty;

						statePanel.Text = "State: Renaming audio file.";

						using (ChooseRecordingNameWindow dialog = new ChooseRecordingNameWindow())
						{
							if (dialog.ShowDialog(this) == DialogResult.OK)
							{
								fileName = dialog.recordingName;
							}
						}

						statePanel.Text = "State: Attaching Audio to selected Note.";

						group.Notes.Where<Note>(n => n.Name == noteName).FirstOrDefault().Attachments.Add(new Note.Attachment()
						{
							FileData = data,
							FileName = Program.documentFolderPath + @"\" + fileName + ".wav",
							Type = "*.wav"
						});

						statePanel.Text = "State: Idle.";

						needsSaving = true;
						ConveyThatChangesNeedSaving();
					}
				}
			}
		}

		private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
		{
			applicationSettings.SplitterPosition = splitContainer1.Panel1.Width;

			//needsSaving = true;
			ConveyThatChangesNeedSaving();
		}

		private void menuItem41_Click_1(object sender, EventArgs e)
		{
			using (About dialog = new About())
			{
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{

				}
			}
		}

		private void menuItem42_Click(object sender, EventArgs e)
		{
			if (list.SelectedNode.Parent != null)
			{
				// This is a note.
				Group group = stack.Where(g => g.Name == list.SelectedNode.Parent.Text).FirstOrDefault();

				if (group != null)
				{
					Note note = group.Notes.Where(n => n.Name == list.SelectedNode.Text).FirstOrDefault();

					if (note != null)
					{
						int indexOfGroup = Array.IndexOf(stack.ToArray(), group);
						int indexOfNote = Array.IndexOf(group.Notes.ToArray(), note);

						if (indexOfGroup >= 0 && indexOfNote >= 0)
						{
							ProtectNote(note);
						}
					}
				}
			}
		}

		private void autoSaveMainMenuItem_Click(object sender, EventArgs e)
		{
			if (autoSaveMainMenuItem.Checked)
			{
				autoSaveTimer.Stop();
				autoSaveMainMenuItem.Checked = false;
				applicationSettings.AutoSaveChanges = false;
			}
			else
			{
				autoSaveTimer.Start();
				autoSaveMainMenuItem.Checked = true;
				applicationSettings.AutoSaveChanges = true;
			}
		}

		private void Window_LocationChanged(object sender, EventArgs e)
		{
			if (applicationSettings.RememberWindowPosition)
			{
				applicationSettings.WindowPosition = this.Location;
				ConveyThatChangesNeedSaving();
			}
		}

		private void highlightContextMenuItem_Click(object sender, EventArgs e)
		{
			if (list.Nodes != null)
			{
				if (list.SelectedNode != null)
				{
					if (highlightContextMenuItem.Checked)
					{
						list.SelectedNode.BackColor = Color.FromArgb(255, 240, 250, 240);
						highlightContextMenuItem.Checked = false;
					}
					else
					{
						list.SelectedNode.BackColor = Color.FromArgb(240, 250, 240);
						highlightContextMenuItem.Checked = true;

					}
				}
			}
		}

		private void editor_DragLeave(object sender, EventArgs e)
		{

		}

		private void Window_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R)
			{
				EndRecording();
			}
		}

		private void menuItem31_Click(object sender, EventArgs e)
		{
			using (ManageExtensionsWindow window = new ManageExtensionsWindow())
			{
				if (window.ShowDialog(this) == DialogResult.OK)
				{

				}
			}
		}

		private void findAndReplace_Click(object sender, EventArgs e)
		{
			if (findAndReplaceWindow != null && !findAndReplaceWindow.IsDisposed)
			{
				findAndReplaceWindow.Show(this);
			}
		}

		private void list_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (e.Node.Parent != null)
				{
					// Hack to ensure that note is displayed when selected.
					//list.SelectedNode = e.Node.Parent;
					//list.SelectedNode = e.Node;

					e.Node.Parent.Toggle();
					e.Node.Parent.Toggle();

					DisplayNote(e);

					if (!editor.Enabled)
					{
						editor.Enabled = true;
					}
				}

				if (e.Node.Parent == null)
				{
					selectedGroupName = e.Node.Text;

					if (editor.Enabled)
					{
						editor.Enabled = false;
					}
				}
				else
				{
					DisplayNote(e);

					if (!editor.Enabled)
					{
						editor.Enabled = true;
					}
				}
			}
			else
			{
				// Hack to ensure that the Node is selected without first having to LEFT-click it.
				list.SelectedNode = e.Node;
			}
		}

		private void editor_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;

			if (e.Data != null)
			{
				if (e.Data.GetDataPresent(DataFormats.Text, true))
				{
					dragDropContent = (string)e.Data.GetData(DataFormats.Text, true);
				}
			}
		}
	}
}