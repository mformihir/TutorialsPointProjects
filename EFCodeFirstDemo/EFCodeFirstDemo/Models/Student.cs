using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EFCodeFirstDemo.Models;

namespace EFCodeFirstDemo.Models
{
	public class Enrollment
	{
		public int EnrollmentID { get; set; }
		public int CourseID { get; set; }
		public int StudentID { get; set; }

		public virtual Course CurrCourse { get; set; }
		public virtual Course PrevCourse { get; set; }
		public virtual Student Student { get; set; }
	}

	public class Student
	{
		[Key]
		public int StdntID { get; set; }
		public string LastName { get; set; }
		public string FirstMidName { get; set; }
		public DateTime EnrollmentDate { get; set; }
		[NotMapped]
		public int FatherName { get; set; }

		public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}