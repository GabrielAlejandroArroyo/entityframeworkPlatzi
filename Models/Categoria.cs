using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace entityframeworkPlatzi.Models
{
    public class Categoria
    {
        [Key]
        public Guid CetegoriaId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        //Trae todas las tareas asociadas a la categoria
        public virtual ICollection<Tarea> Tareas { get; set; }

    }
}