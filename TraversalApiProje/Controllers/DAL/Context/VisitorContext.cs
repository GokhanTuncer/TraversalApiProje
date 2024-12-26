using Microsoft.EntityFrameworkCore;
using TraversalApiProje.Controllers.DAL.Entities;

namespace TraversalApiProje.Controllers.DAL.Context
{
    public class VisitorContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-EOIN7IK\\SQLEXPRESS;database=TraversalDBApi;Integrated Security = True;TrustServerCertificate=true;");
        }
        public DbSet<Visitor> Visitors { get; set; }

    }
}
