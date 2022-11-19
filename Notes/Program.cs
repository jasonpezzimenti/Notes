using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
	internal static class Program
	{
		public static Stack<Group> stack;
		public static string documentFolderPath;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			stack = new Stack<Group>();
			documentFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Notes";

			if(!Directory.Exists(documentFolderPath + @"\Groups"))
			{
				Directory.CreateDirectory(documentFolderPath + @"\Groups");
			}
			else
			{
				foreach(string file in Directory.GetFiles(documentFolderPath + @"\Groups"))
				{
					string data = File.ReadAllText(file);

					if(!String.IsNullOrEmpty(data))
					{
						JsonSerializerOptions options = new JsonSerializerOptions()
						{
							IncludeFields = true
						};

						Group group = JsonSerializer.Deserialize<Group>(data, options);

						if(group != null)
						{
							stack.Push(group);
						}
					}
				}
			}

			//Tokenizer tokenizer = new Tokenizer();
			//tokenizer.Tokenize("@: Note.SelectedNote.GetContent;");
			//tokenizer.Tokenize("Note.SelectedNote.SetContent: \"something\"; Note.SelectedNote.SetContent: \"yay lol\";");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Window());
		}
	}
}
