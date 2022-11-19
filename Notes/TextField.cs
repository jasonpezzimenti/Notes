using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FILO;

namespace Notes
{
	public partial class TextField : Control
	{
		public FILO<Character> characters;

		public class Character
		{
			public char Value { get; set; }
			public Font Font { get; set; }
			public Color Color { get; set; }
			public SizeF Width { get; set; }
		}

		public TextField()
		{
			InitializeComponent();

			characters = new FILO<Character>();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			foreach(Character character in characters)
			{
			}
		}

		private void TextField_KeyDown(object sender, KeyEventArgs e)
		{
			char character = (char)e.KeyCode;

			// Measure the width of the character.
			Graphics graphics = this.CreateGraphics();

			SizeF size = graphics.MeasureString(character.ToString(), this.Font);

			characters.Add(new Character()
			{
				Value = character,
				Font = this.Font,
				Color = Color.Black
			});

			// Cause the window to re-paint.
			this.Refresh();
		}
	}
}
