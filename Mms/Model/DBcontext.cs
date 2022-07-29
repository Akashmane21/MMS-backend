using Microsoft.EntityFrameworkCore;

namespace Mms.Model
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options)
           : base(options)
        {
        }
        public virtual DbSet<Films> Allfilms { get; set; }
        public virtual DbSet<Auths> Allauths { get; set; }


    }
}
