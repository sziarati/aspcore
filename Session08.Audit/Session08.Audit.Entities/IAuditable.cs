using System;

namespace Session08.Audit.Entities
{
	public interface IAuditable
	{
		public int InsertBy { get; set; }
		public int UPdateBy { get; set; }
		public DateTime InsertDate { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
