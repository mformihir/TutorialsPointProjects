using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace EFCodeFirstDemo.Models
{
	public class Course
	{
		public int CourseID { get; set; }
		public string Title { get; set; }

		[Index]
		public int Credits { get; set; }

		[InverseProperty("CurrCourse")]
		public virtual ICollection<Enrollment> CurrEnrollments { get; set; }

		[InverseProperty("PrevCourse")]
		public virtual ICollection<Enrollment> PrevEnrollments { get; set; }
	}
}