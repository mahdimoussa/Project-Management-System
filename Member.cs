using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdsProjectManagementSystem.Models
{
	public class Member
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int MemberId { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Role { get; set; }
		public int EmploymentYears { get; set; }
		public int Performance { get; set; }
		public float Profit { get; set; }
		public int WorkingHours { get; set; }
		public DateTime EmploymentDate { get; set; }


		[ForeignKey("Project")]
		public int? FK_ProjectId { get; set; }
		public Project Project { get; set; }
	}
}
