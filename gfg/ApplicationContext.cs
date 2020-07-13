using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace TrinoWPF.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<UserInTeam> UsersInTeams { get; set; }
        public DbSet<FriendDetail> FriendDetails { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=db_astra;Trusted_Connection=True;");
        }
    }
}
