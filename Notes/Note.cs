using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
	[DataContract]
	public class Note
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Content { get; set; }

		[DataMember]
		public bool Locked { get; set; }

		[DataMember]
		public DateTime Created { get; set; }

		[DataMember]
		public DateTime LastEdited { get; set; }

		[DataContract]
		public class Attachment
		{
			public byte[] FileData { get; set; } = null;
			public string Type { get; set; } = null;
			public string FileName { get; set; } = null;
		}

		[DataMember]
		public List<Attachment> Attachments;

		[DataMember]
		public List<PreviousVersion> PreviousVersions;

		public Note()
		{
			Attachments = new List<Attachment>();
			PreviousVersions = new List<PreviousVersion>();
		}
	}
}