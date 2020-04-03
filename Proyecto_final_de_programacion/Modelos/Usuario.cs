using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_final_de_programacion.Modelos
{
    public class Usuario
    {
        public string Correo { get; set; }

        public string Password { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Direccion { get; set; }

        public string TipoDeUsuario { get; set; }

        public List<Pelicula> Peliculas { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido}<{Correo}>";
        }
    }

    public class TiposDeUsuario
    {
        public const string Administrador = "Administrador";
        public const string Empleado = "Empleado";
        public const string Cliente = "Cliente";
    }
}
