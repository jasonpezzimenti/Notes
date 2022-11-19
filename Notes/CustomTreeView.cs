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
	public partial class CustomTreeView : TreeView
	{
		private Color alternativeBackgroundColor;

		public CustomTreeView()
		{
			InitializeComponent();

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}

		protected override void OnPaint(PaintEventArgs paintEventArguments)
		{
			base.OnPaint(paintEventArguments);
		}	
	}
}
