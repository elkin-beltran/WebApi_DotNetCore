using Microsoft.EntityFrameworkCore;
using WebApi_DotNetCore.Models;

namespace WebApi_DotNetCore.DAL
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change the data source "CO-IT02464" for your own sql server
            optionsBuilder.UseSqlServer("Data Source=CO-IT02464;Initial Catalog=EFCore;Integrated Security=True");
        }

        public DbSet<Vote> Votes { get; set; }

    }
}
