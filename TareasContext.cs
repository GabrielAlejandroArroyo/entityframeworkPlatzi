using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entityframeworkPlatzi.DatosIniciales;
using entityframeworkPlatzi.Models;
using Microsoft.EntityFrameworkCore;

namespace entityframeworkPlatzi
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // calse que contiene la carga inicial del sistema
            InitialData initialData = new InitialData();

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);

                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

                categoria.Property(p => p.Descripcion).IsRequired(false);

                categoria.Property(p => p.Peso);

                categoria.HasData(initialData.categoriaInit);


            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.CategoriaId);

                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);

                tarea.Property(p => p.Descripcion).IsRequired(false);

                tarea.Property(p => p.PrioridadTarea);

                tarea.Property(p => p.FechaCreacion);

                tarea.Ignore(p => p.Resumen);

                tarea.HasData(initialData.tareaInit);

            });


        }
    }
}
