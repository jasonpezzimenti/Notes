using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
	[DataContract]
	public class PreviousVersion
	{
		[DataMember]
		public Note Note { get; set; }

		[DataMember]
		public DateTime DateCreated { get; set; }

		[DataMember]
		public DateTime DateLocked { get; set; }

		[DataMember]
		public bool Locked { get; set; }

		public PreviousVersion() { }
	}
}
