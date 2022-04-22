using Crud_tuto2.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud_tuto2.Data
{
    public class TutoDBContext: DbContext
    {
        public TutoDBContext(DbContextOptions<TutoDBContext> options): base (options)
        {

        }
        public DbSet<Gadgets> Gadgets {get; set;}
    }
}