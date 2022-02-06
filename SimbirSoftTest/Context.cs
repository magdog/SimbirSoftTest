using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using System;
using Serilog;

namespace SimbirSoftTest
{
    public class Context : DbContext
    {
        public Context() 
        {
            try
            {
                Database.Migrate();
            }
            catch(Exception e)
            {
                Log.Error(e , "Ошибка в проведении миграции");
            }
        }
        public DbSet<Stats> Stats { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=gar_test;User ID=bars;Password=1234;");
        }
    }
}
