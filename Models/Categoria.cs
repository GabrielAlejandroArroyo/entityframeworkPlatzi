using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entityframeworkPlatzi.Models
{
    public class Categoria
    {
        public Guid CetegoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}