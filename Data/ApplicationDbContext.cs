using HouseRent4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseRent4.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}
		public DbSet<Home> Home { get; set; }

		public DbSet<Specials> Specials { get; set; }

		public DbSet<About> About { get; set; }

		public DbSet<Prices> Prices { get; set; }

		public DbSet<Contact> Contact { get; set; }

		public DbSet<Gallery> Gallery { get; set; }
	}
}
