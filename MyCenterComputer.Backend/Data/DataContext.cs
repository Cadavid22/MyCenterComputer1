
using Microsoft.EntityFrameworkCore;

using MyCenterComputer.shared.Entities;

namespace CenterComputer.Backend.Data
{
    public class DataContext : DbContext
    {
        internal readonly object MyCenterComputer;
        internal readonly object MyComputer;

        public DataContext(DbContextOptions<DataContext> op) : base(op)
        {

        }

        public DbSet<MyCenterComputers> CenterComputers { get; set; }

    }
}
