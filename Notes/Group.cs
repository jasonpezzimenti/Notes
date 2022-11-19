using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
	[DataContract]
	[KnownType(typeof(Group))]
	public partial class Group
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public bool Locked { get; set; }

		[DataMember]
		public List<Note> Notes;

		public Group()
		{
			Notes = new List<Note>();
		}
	}
}
