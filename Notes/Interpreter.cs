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
		private List<TokenLESSOLD> theseTokens;

		public Interpreter(List<TokenLESSOLD> tokens)
		{
			theseTokens = tokens.ToList<TokenLESSOLD>();
		}

		public void Interpret(CustomTreeView list, TextBox editor)
		{

		}

		private TokenLESSOLD Peek(int index)
		{
			return theseTokens[index];
		}

		private void Document_PrintPage(object sender, PrintPageEventArgs e)
		{
			e.Graphics.DrawString(Window.thisEditor.Text, Window.thisEditor.Font, Brushes.Black, 20, 20);
		}
	}
}
