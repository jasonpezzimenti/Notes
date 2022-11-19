using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
	[DataContract]
	public class Extension
	{
		[DataMember]
		public string Name { get; set; } = "Extension";
		[DataMember]
		public string Author { get; set; } = "Anonymous";
		[DataMember]
		public string Description { get; set; } = "An extension for Notes.";
		[DataMember]
		public string Path { get; set; } = "";
		[DataMember]
		public string Shortcut { get; set; }
		[DataMember]
		public bool MenuBound { get; set; }
		[DataMember]
		public string AffectedEntity { get; set; } = "Note";
	}
}
