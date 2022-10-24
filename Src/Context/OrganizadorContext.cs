using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Src.Models;

namespace tech_test_payment_api.Src.Context
{
    public class OrganizadorContext : DbContext
    {
         public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
            
        }

        public DbSet<Vendas> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Vendas>(entity => 
            {
                entity.HasKey(e => new { e.Id});
            });
        }
    }
}