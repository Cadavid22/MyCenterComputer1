
using Microsoft.EntityFrameworkCore;

namespace CenterComputer.Backend.Data
{
    public class DataContext : DbContext
    {
        internal readonly object MyCenterComputer;
        internal readonly object MyComputer;

        public DataContext(DbContextOptions<DataContext> op) : base(op)
        {

        }

        public DbSet<MyCenterComputer> MyCenterComputers { get; set; }

    }
}
