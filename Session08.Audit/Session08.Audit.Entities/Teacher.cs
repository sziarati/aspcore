using System;

namespace Session08.Audit.Entities
{
    public class Teacher : IAuditable
	{
		public int TeacherId { get; set; }
		public string  Name { get; set; }
		public int InsertBy {get;set;}
		public int UPdateBy { get; set; }
		public DateTime InsertDate {get;set;}
		public DateTime UpdateDate { get; set; }
	}
}
