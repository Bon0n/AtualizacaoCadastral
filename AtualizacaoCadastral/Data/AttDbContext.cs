using AtualizacaoCadastral.Models;
using Microsoft.EntityFrameworkCore;

namespace AtualizacaoCadastral.Data
{
    public class AttDbContext : DbContext
    {
        public AttDbContext(DbContextOptions<AttDbContext> options) : base(options)
        {
            
        }

        public DbSet<ColaboradorModel> Colaboradores { get; set; }
    }
}
