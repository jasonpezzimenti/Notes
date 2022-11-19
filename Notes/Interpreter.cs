using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
	public class Interpreter
	{
		private List<Token> theseTokens;

		public Interpreter(List<Token> tokens)
		{
			theseTokens = tokens.ToList<Token>();
		}

		public void Interpret(CustomTreeView list, TextBox editor)
		{
		}

		private Token Peek(int index)
		{
			return theseTokens[index];
		}

		private void Document_PrintPage(object sender, PrintPageEventArgs e)
		{
			e.Graphics.DrawString(Window.thisEditor.Text, Window.thisEditor.Font, Brushes.Black, 20, 20);
		}
	}
}
