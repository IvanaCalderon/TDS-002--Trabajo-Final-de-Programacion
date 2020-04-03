using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Proyecto_final_de_programacion.Modelos;

namespace Proyecto_final_de_programacion
{
    class Program
    {
        #region Datos
        static Usuario UsuarioActual { get; set; }
        static List<Usuario> Usuarios { get; set; }
        static List<Empleado> Empleados { get; set; }
        static List<Pelicula> Peliculas { get; set; }


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
            };

            Usuarios = new List<Usuario>
            {
                Empleados[0],
                new Empleado {
                    Nombre = "Ivana",
                    Apellido = "Calderon",
                    Direccion = "Calle Paravel 123",
                    TipoDeUsuario = TiposDeUsuario.Administrador,
                    Correo = "ivana@calderon.com",
                    Password = "123123",
                    Cargo = "Vendedeor"
                },
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
        #endregion

        public static void Main(string[] args)
        {
            cargarBaseDeDatas();
            menuInicio();
            mostrarMenu();
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
            var opcion = 0;
            do
            {
                Console.WriteLine("Elige la accion que quieres:");
                Console.WriteLine("[1] - Agregar empleado");
                Console.WriteLine("[2] - Editar empleado");
                Console.WriteLine("[3] - Borrar empleado");
                Console.WriteLine("[4] - Agregar pelicula");
                Console.WriteLine("[5] - Editar pelicula");
                Console.WriteLine("[6] - Borrar pelicula");
                Console.WriteLine("[7] - Ganancias de las peliculas");
                Console.WriteLine("[8] - Listar empleados");
                Console.WriteLine("[9] - Listar peliculas");
                Console.WriteLine("[0] - Salir");

                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        agregarEmpleado();
                        break;
                    case 2:
                        listarEmpleados();
                        editarEmpleado();
                        break;
                    case 3:
                        listarEmpleados();
                        borrarEmpleado();
                        break;
                    case 4:
                        agregarPelicula();
                        break;
                    /*   case 5:
                           editarPelicula();
                           break; */
                    //case 6:
                    //    borrarPelicula();
                    //    break;
                    //case 7:
                    //    gananciaPeliculas();
                    //    break;
                    case 8:
                        listarEmpleados();
                        break;
                    case 9:
                        listarPeliculas();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            } while (opcion != 0);
        }

        static void menuCliente() // Menu del Cliente
        {
            var opcion = 0;
            do
            {
                Console.WriteLine("Elige la accion que quieres:");
                Console.WriteLine("[1] - Alquilar pelicula");
                Console.WriteLine("[2] - Lista de peliculas alquiladas");
                Console.WriteLine("[3] - Fecha de entrega de pelicula");

                switch (int.Parse(Console.ReadLine()))
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
                        
                        break;
                }
            }
            while (opcion != 0);
        }

        static void menuEmpleado() // Menu del empleado
        {
            var opcion = 0;
            do
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
                        
                        break;
                }
            }
            while (opcion != 0);
        }

        #region Peliculas
        static void agregarPelicula()
        {
            var newPelicula = new Pelicula();
            
            Console.WriteLine("Escribe nombre de la pelicula:");
            newPelicula.Nombre = Console.ReadLine();
            Console.WriteLine("Escribe precio de la pelicula: ");
            newPelicula.Precio = (float) Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Escribe los dias de alquiler: ");
            newPelicula.DiasAlquiler = Convert.ToInt32(Console.ReadLine());
          
            Peliculas.Add(newPelicula);
        }

        static void listarPeliculas()
        {
            Console.WriteLine("\nListado de peliculas\n");
            foreach (var pelicula in Peliculas)
            {
                Console.WriteLine($"{pelicula.Nombre}, ${pelicula.Precio}, {pelicula.DiasAlquiler} dias");
            }
        }

        #endregion

        






        #region Empleados
        static void agregarEmpleado() //El menu que le sale al administrador a la hora de añadir un nuevo empleado
        {
            var newEmpleado = new Empleado();
            newEmpleado.TipoDeUsuario = TiposDeUsuario.Empleado;
            Console.WriteLine("Escribe primer nombre:");
            newEmpleado.Nombre = Console.ReadLine();
            Console.WriteLine("Escribe apellido: ");
            newEmpleado.Apellido = Console.ReadLine();
            Console.WriteLine("Escribe la direccion: ");
            newEmpleado.Direccion = Console.ReadLine();
            Console.WriteLine("Escribe el cargo: ");
            newEmpleado.Cargo = Console.ReadLine();
            Console.WriteLine("Escribe nuevo correo de usuario: ");
            newEmpleado.Correo = Console.ReadLine();
            Console.WriteLine("Asigna contraseña al usuario: ");
            newEmpleado.Password = Console.ReadLine();
            Empleados.Add(newEmpleado);
        }

        static void editarEmpleado()
        { 
            Console.WriteLine("Escribe el correo del empleado para editar: ");
            var correo = Console.ReadLine();
            var empleado = Empleados.FirstOrDefault(x => x.Correo.ToLower() == correo.ToLower());
            if (empleado == null)
            {
                Console.WriteLine("El usuario que intentas modificar no existe\n");
                return;
            }
            Console.WriteLine($"Modificando usuario:\n {empleado}");
            Console.WriteLine("Escribe primer nombre:");
            empleado.Nombre = Console.ReadLine();
            Console.WriteLine("Escribe apellido: ");
            empleado.Apellido = Console.ReadLine();
            Console.WriteLine("Escribe la direccion: ");
            empleado.Direccion = Console.ReadLine();
            Console.WriteLine("Escribe el cargo: ");
            empleado.Cargo = Console.ReadLine();
            Console.WriteLine("Escribe nuevo correo de usuario: ");
            empleado.Correo = Console.ReadLine();
            Console.WriteLine("Asigna contraseña al usuario: ");
            empleado.Password = Console.ReadLine();
        }
        static void borrarEmpleado()
        {
            Console.WriteLine("Escribe el correo del empleado para eliminar: ");
            var correo = Console.ReadLine();
            var empleado = Empleados.FirstOrDefault(x => x.Correo.ToLower() == correo.ToLower());
            if (empleado == null)
            {
                Console.WriteLine("El usuario que intentas eliminar no existe\n");
                return;
            }
            Empleados.Remove(empleado);
        }

        static void listarEmpleados()
        {
            Console.WriteLine("\nListado de empleados\n");
            foreach(var empleado in Empleados)
            {
                Console.WriteLine($"{empleado.Nombre} {empleado.Apellido}<{empleado.Correo}>, {empleado.Cargo}");
            }
        }

        #endregion
    }
}