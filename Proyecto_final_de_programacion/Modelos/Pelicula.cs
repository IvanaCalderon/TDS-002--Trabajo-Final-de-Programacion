using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_final_de_programacion.Modelos
{
    public class Pelicula
    {
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int DiasAlquiler { get; set; }

        public DateTime? FechaDeRetorno { get; set; } 
    }
}
