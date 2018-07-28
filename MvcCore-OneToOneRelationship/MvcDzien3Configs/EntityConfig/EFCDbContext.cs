using Microsoft.EntityFrameworkCore;
using MvcDzien3Configs.Models;

namespace MvcDzien3Configs.EntityConfig
{
    public class EfcDbContext : DbContext
    {
	    public DbSet<CustomerModel> Customers { get; set; }

	    public DbSet<ConsultationModel> Consultations { get; set; }

	    public EfcDbContext(DbContextOptions opt) : base(opt)
	    {

	    }
    }
}
