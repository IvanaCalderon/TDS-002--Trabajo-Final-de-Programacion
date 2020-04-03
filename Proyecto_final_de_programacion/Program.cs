using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Proyecto_final_de_programacion.Modelos;

namespace Proyecto_final_de_programacion
{
    class Program
    {
        static Usuario UsuarioActual { get; set; }
        static List<Usuario> Usuarios { get; set; }
        static List<Empleado> Empleados { get; set; }
        static List<Pelicula> Peliculas { get; set; }

        public static void Main(string[] args)
        {
            cargarBaseDeDatas();
            menuInicio();
            mostrarMenu();
        }

        static void cargarBaseDeDatas()
        {
            //TODO Cargar desde base de datos
            Empleados = new List<Empleado>
            {
                new Empleado {
                    Nombre = "Juan",
                    Apellido = "Perez",
                    Direccion = "Calle Paravel 120",
                    TipoDeUsuario = TiposDeUsuario.Empleado,
                    Correo = "juanperez@paravel.com",
                    Password = "123123",
                    Cargo = "Gerente"
                },
                new Empleado {
                    Nombre = "Ivana",
                    Apellido = "Calderon",
                    Direccion = "Calle Paravel 123",
                    TipoDeUsuario = TiposDeUsuario.Administrador,
                    Correo = "ivana@calderon.com",
                    Password = "123123",
                    Cargo = "Vendedeor"
                },
            };

            Usuarios = new List<Usuario>
            {
                Empleados[0],
                Empleados[1],
                new Usuario {
                    Nombre = "JHonny",
                    Apellido = "Smith",
                    Direccion = "Calle Paravel 345",
                    TipoDeUsuario = TiposDeUsuario.Cliente,
                    Correo = "ivana@calderon.com",
                    Password = "123123"
                },
            };

            Peliculas = new List<Pelicula>
            {
                new Pelicula
                {
                    Nombre = "Titanic",
                    Precio = 85,
                    DiasAlquiler = 7,
                    FechaDeRetorno = null,
                }
            };
        }
        static void menuInicio() //Menu que aparece al iniciar la aplicacion
        {
            bool esLoginValido = false;
            do
            {
                Console.WriteLine("Bienvenido al sistema de alquiler de peliculas");
                Console.WriteLine("Ingresa tu nombre de usuario");
                var correo = Console.ReadLine();
                Console.WriteLine("Ingresa tu contraseña");
                var password = Console.ReadLine();

                UsuarioActual = Usuarios.FirstOrDefault(usuario => usuario.Correo.ToLower() == correo.ToLower() && usuario.Password == password);
                if (UsuarioActual == null)
                {
                    Console.WriteLine("El usuario o contraseña que intentaste no son correctos");
                }
                else
                {
                    Console.WriteLine($"Bienvenid@, {UsuarioActual}");
                    esLoginValido = true;
                }
            } while (!esLoginValido);
        }

        static void mostrarMenu()
        {
            switch (UsuarioActual.TipoDeUsuario)
            {
                case TiposDeUsuario.Administrador:
                    menuAdministrador();
                    break;
                case TiposDeUsuario.Empleado:
                    menuEmpleado();
                    break;
                case TiposDeUsuario.Cliente:
                    menuCliente();
                    break;
            }
        }

        static void menuAdministrador() //Menu del administrador
        {
            Console.WriteLine("Elige la accion que quieres:");
            Console.WriteLine("[1] - Agregar empleado");
            Console.WriteLine("[2] - Editar empleado");
            Console.WriteLine("[3] - Borrar empleado");
            Console.WriteLine("[4] - Agregar pelicula");
            Console.WriteLine("[5] - Editar pelicula");
            Console.WriteLine("[6] - Borrar pelicula");
            Console.WriteLine("[7] - Ganancias de las peliculas");

            switch (int.Parse(Console.ReadLine()))
            {
                //case 1:
                //    agregarEmpleado();
                //    break;
                //case 2:
                //    editarEmpleado();
                //    break;
                //case 3:
                //    borrarEmpleado();
                //    break;
                //case 4:
                //    agregarPelicula();
                //    break;
                //case 5:
                //    editarPelicula();
                //    break;
                //case 6:
                //    borrarPelicula();
                //    break;
                //case 7:
                //    gananciaPeliculas();
                //    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    menuAdministrador();
                    break;
            }
        }

        static void menuCliente() // Menu del Cliente
        {
            Console.WriteLine("Elige la accion que quieres:");
            Console.WriteLine("[1] - Alquilar pelicula");
            Console.WriteLine("[2] - Lista de peliculas alquiladas");
            Console.WriteLine("[3] - Fecha de entrega de pelicula");

            switch(int.Parse(Console.ReadLine()))
            {
                /*case 1:
                    alquilarPelicula();
                    break;
                case 2:
                    peliculasAlquiladas();
                    break;
                case 3:
                    fechaEntrega();
                    break;*/
                default:
                    Console.WriteLine("Opcion no valida");
                    menuCliente();
                    break;
            }
        }

        static void menuEmpleado() // Menu del empleado
        {
            Console.WriteLine("Elige la accion que quieres:");
            Console.WriteLine("[1] - Agregar cliente");
            Console.WriteLine("[2] - Editar cliente");
            Console.WriteLine("[3] - Alquilar pelicula a cliente");
            Console.WriteLine("[4] - Peliculas alquiladas");

            switch (int.Parse(Console.ReadLine()))
            {/* 
                case 1:
                    agregarCliente();

                    break;
                case 2:
                    editarCliente();

                    break;
                case 3:
                    alquilarPelicula();

                    break;
                case 4:
                    peliculasAlquiladas();

                    break;
                    */
                default:
                    Console.WriteLine("Opcion no valida");
                    menuEmpleado();

                    break;
            }
        }


        static void agregarEmpleado() //El menu que le sale al administrador a la hora de añadir un nuevo empleado
        {
            List<Empleado> Empleados = new List<Empleado>();
            Empleado newEmpleado = new Empleado();


            Console.WriteLine("Escribe nuevo nombre de usuario: ");
            Console.ReadLine();
            Console.WriteLine("Asigna contraseña al usuario: ");
            Console.ReadLine();
            Console.WriteLine("Escribe primer nombre:");
            newEmpleado.Nombre = Console.ReadLine();
            Console.WriteLine("Escribe apellido: ");
            newEmpleado.Apellido = Console.ReadLine();
            Console.WriteLine("Escribe direccion: ");
            newEmpleado.Direccion = Console.ReadLine();
            Console.WriteLine("Escribe el cargo: ");
            newEmpleado.Cargo = Console.ReadLine();
        }   
    }
}