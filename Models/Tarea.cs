using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entityframeworkPlatzi.Models
{
    public class Tarea
    {
        public Guid TareaId { get; set; }
        public Guid CategoriaId { get; set; }

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public enum Prioridad
    {
        baja,
        Media,
        Alta
    }
}