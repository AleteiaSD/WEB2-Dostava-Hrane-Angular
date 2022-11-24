using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Slika> Slikas { get; set; }
        public DbSet<Proizvod> Proizvods { get; set; }
        public DbSet<Poruzbina> Poruzbinas { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proizvod>().Property(p => p.Sastojaks).HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<Sastojak>>(v));

            modelBuilder.Entity<Poruzbina>().Property(p => p.Proizvods).HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<ProizvodPorudzbina>>(v));
        }
    }
}
