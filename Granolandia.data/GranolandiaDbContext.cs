using Granolandia.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Granolandia.data
{
	public class GranolandiaDbContext : DbContext
	{
		public DbSet<Granola> Granolas { get; set; }
	}
}
