using Consistrack.Models;
using Microsoft.EntityFrameworkCore;
namespace Consistrack.Data
{
      public class ConsistrackContext : DbContext
    {
public ConsistrackContext(DbContextOptions<ConsistrackContext> opt) : base(opt)
{

    
}
public DbSet<SimMaster> SimMasters{ get; set; }
    }
}