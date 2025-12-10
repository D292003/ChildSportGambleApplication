using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ChildSportGambleApplication.Models;
using System.Text;
using System.Threading.Tasks;
using Windows.System;


namespace ChildSportGambleApplication.Data
{
    internal class AppDbContext : DbContext
    {

        public DbSet<UserInfo> User_Info { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("host=localhost;username=root;password=;database=Test222",
                MySqlServerVersion.Parse("8.4.3"));
        }

    }
}
