﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdsProjectManagementSystem.Models
{
	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : 
			
			base(options)
		{

		}

		public DbSet<Project> Projects { get; set; }
		public DbSet<Member> Members { get; set; }
	}
}
