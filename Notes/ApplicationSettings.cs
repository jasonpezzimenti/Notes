using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
	[DataContract]
	public class ApplicationSettings
	{
		[DataMember]
		public Size WindowSize { get; set; }

		[DataMember]
		public bool RememberWindowSize { get; set; } = true;

		[DataMember]
		public bool RememberSplitterPosition { get; set; } = false;
		[DataMember]
		public int SplitterPosition { get; set; } = 236;
		[DataMember]
		public Color ListBackgroundColor { get; set; } = Color.WhiteSmoke;
		[DataMember]
		public Color EditorBackgroundColor { get; set; } = Color.FromArgb(250, 250, 250);
		[DataMember]
		public Color StatusBarBackgroundColor { get; set; }
		[DataMember]
		public bool AutoSaveChanges { get; set; }
		[DataMember]
		public bool RememberWindowPosition { get; set; } = true;
		[DataMember]
		public Point WindowPosition { get; set; } = Point.Empty;
		[DataMember]
		public FormWindowState WindowState { get; set; }
	}
}
