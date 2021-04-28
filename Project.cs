using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdsProjectManagementSystem.Models
{
	public class Project
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string Description { get; set; }
		public int Profit { get; set; }
		public float Rate { get; set; }
		public float TotalPerformance { get; set; }
		public DateTime PaymentDate { get; set; }
		public List<Member> Members { get; set; }
	}
}
