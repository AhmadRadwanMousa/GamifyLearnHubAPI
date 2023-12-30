using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.DTO
{
	public class InstructorReport
	{
		// User Info
		public decimal Userid { get; set; }
		public string Firsname { get; set; }
		public string Lastname { get; set; }
		public decimal? Totalpoints { get; set; }

		// Section Info 
		public string Sectionname { get; set; }
		public string Sectionsize { get; set; }

		// User Section Info
		public DateTime Enrollmentdate { get; set; }
		public decimal Studentmark { get; set; }

		// Attendence 
		public DateTime Attenddate { get; set; }

		// Attendence Datils
		public bool Isattended { get; set; }

		//Points Activity 
		public decimal Points { get; set; }
	}
}
