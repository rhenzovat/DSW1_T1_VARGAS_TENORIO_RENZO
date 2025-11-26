using Microsoft.EntityFrameworkCore;
using DSW1_T1_VARGAS_TENORIO_RENZO.Models;

namespace DSW1_T1_VARGAS_TENORIO_RENZO.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<NivelAcademico> NivelesAcademicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NivelAcademico>()
                .HasMany(n => n.Cursos)
                .WithOne(c => c.NivelAcademico)
                .HasForeignKey(c => c.NivelAcademicoId);
        }
    }
}

