using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entityframeworkPlatzi.Models;

namespace entityframeworkPlatzi.DatosIniciales
{
    public class InitialData
    {

        public List<Categoria> categoriaInit = new List<Categoria>();
        public List<Tarea> tareaInit = new List<Tarea>();

        public InitialData()
        {
            InicializaCategoria();
            InicializaTarea();
        }

        public void InicializaCategoria()
        {

            categoriaInit.Add(new Categoria()
            {
                CategoriaId = Guid.Parse("097d60ad-b300-4cbf-8283-7f7df5c61001"),
                Nombre = "Actividades Pendientes",
                Descripcion = "",
                Peso = 20
            });

            categoriaInit.Add(new Categoria()
            {
                CategoriaId = Guid.Parse("097d60ad-b300-4cbf-8283-7f7df5c61002"),
                Nombre = "Actividades personales",
                Descripcion = "",
                Peso = 50
            });
        }

        public void InicializaTarea()
        {
            tareaInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("097d60ad-b300-4cbf-8283-7f7df5c61003"),
                CategoriaId = Guid.Parse("097d60ad-b300-4cbf-8283-7f7df5c61001"),
                PrioridadTarea = Prioridad.Media,
                Titulo = "Pago de servicios publicos",
                FechaCreacion = DateTime.Now
            });

            tareaInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("097d60ad-b300-4cbf-8283-7f7df5c61004"),
                CategoriaId = Guid.Parse("097d60ad-b300-4cbf-8283-7f7df5c61002"),
                PrioridadTarea = Prioridad.baja,
                Titulo = "Terminar de ver pelicula en Netflix",
                FechaCreacion = DateTime.Now
            });

        }



    }

}