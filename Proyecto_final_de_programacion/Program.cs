using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
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


        static void cargarBaseDeDatos()
        {
            string docPath = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(docPath, "Usuarios.txt")))
                {
                    Usuarios = JsonConvert.DeserializeObject<List<Usuario>>(sr.ReadToEnd());
                }
                using (StreamReader sr = new StreamReader(Path.Combine(docPath, "Empleados.txt")))
                {
                    Empleados = JsonConvert.DeserializeObject<List<Empleado>>(sr.ReadToEnd());
                }

                using (StreamReader sr = new StreamReader(Path.Combine(docPath, "Peliculas.txt")))
                {
                    Peliculas = JsonConvert.DeserializeObject<List<Pelicula>>(sr.ReadToEnd());
                }
            }
            catch
            {
                Console.WriteLine("Archivos de base de datos no encontrados o informacion corrompida, vamos a crear una base de datos nueva");
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
                new Empleado {          //Unica cuanta de administrador creada por default
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
                    Correo = "jhony@smith.com",
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

                guardar();
            }
        }
        #endregion

        public static void Main(string[] args)
        {
            cargarBaseDeDatos();
            menuInicio();
            mostrarMenu();
        }
        static void menuInicio() //Menu que aparece al iniciar la aplicacion
        {
            bool esLoginValido = false;
            do
            {
                Console.WriteLine("Bienvenido al sistema de alquiler de peliculas");
                Console.WriteLine("\nIngresa tu nombre de usuario\n");
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

        static void mostrarMenu() //Este metodo filtra el login segun el tipo de usuario que sea
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

        #region Menus
        static void menuAdministrador() //Menu del administrador
        {
            var opcion = 0;
            do
            {
                Console.WriteLine("\nElige la accion que quieres:\n");
                Console.WriteLine("[1] - Agregar empleado");
                Console.WriteLine("[2] - Editar empleado");
                Console.WriteLine("[3] - Borrar empleado");
                Console.WriteLine("[4] - Agregar pelicula");
                Console.WriteLine("[5] - Editar pelicula");
                Console.WriteLine("[6] - Borrar pelicula");
                Console.WriteLine("[7] - Ganancias de las peliculas");
                Console.WriteLine("[8] - Listar empleados");
                Console.WriteLine("[9] - Listar peliculas");
                Console.WriteLine("[10] - Borrar Cliente");
                Console.WriteLine("[0] - Salir");

                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        agregarEmpleado();
                        guardar();
                        break;
                    case 2:
                        listarEmpleados();
                        editarEmpleado();
                        guardar();
                        break;
                    case 3:
                        listarEmpleados();
                        borrarEmpleado();
                        guardar();
                        break;
                    case 4:
                        agregarPelicula();
                        guardar();
                        break;
                    case 5:
                        listarPeliculas();
                        editarPeliculas();
                        guardar();
                        break;
                    case 6:
                        listarPeliculas();
                        borrarPeliculas();
                        guardar();
                        break;
                     case 7:
                         gananciaPeliculas();
                         break; 
                    case 8:
                        listarEmpleados();
                        break;
                    case 9:
                        listarPeliculas();
                        break;
                    case 10:
                        listarClientes();
                        borrarCliente();
                        guardar();
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
                Console.WriteLine("\nElige la accion que quieres:\n");
                Console.WriteLine("[1] - Alquilar pelicula");
                Console.WriteLine("[2] - Lista de peliculas alquiladas");
                Console.WriteLine("[0] - Salir");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        listarPeliculas();
                        alquilarPelicula();
                            guardar();
                        break;
                    case 2:
                        peliculasAlquiladas();
                        break;

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
                Console.WriteLine("[0] - Salir");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        agregarCliente();
                        guardar();
                        break;
                    case 2:
                        listarClientes();
                        editarCliente();
                        guardar();
                        break;
                    case 3:
                        listarPeliculas();
                        alquilarPelicula();
                        guardar();

                        break;
                    case 4:
                        peliculasAlquiladas();
                        guardar();
                        break;

                    case 5:
                        listarClientes();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            }
            while (opcion != 0);
        }
        #endregion

        #region Peliculas
        static void agregarPelicula()
        {
            var newPelicula = new Pelicula();

            Console.WriteLine("Escribe nombre de la pelicula:");
            newPelicula.Nombre = Console.ReadLine();
            Console.WriteLine("Escribe precio de la pelicula: ");
            newPelicula.Precio = (float)Convert.ToDouble(Console.ReadLine());
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

        static void editarPeliculas()
        {
            Console.WriteLine("Escribe el nombre de la pelicula para editar: ");
            var nombre = Console.ReadLine();
            var pelicula = Peliculas.FirstOrDefault(x => x.Nombre.ToLower() == nombre.ToLower());
            if (pelicula == null)
            {
                Console.WriteLine("\nLa pelicula al modificar no existe\n");
                return;
            }

            Console.WriteLine($"Modificando la pelicula:\n {pelicula}");
            Console.WriteLine("Escribe nombre de la pelicula:");
            pelicula.Nombre = Console.ReadLine();
            Console.WriteLine("Escribe precio de la pelicula: ");
            pelicula.Precio = (float)Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Escribe los dias de alquiler: ");
            pelicula.DiasAlquiler = Convert.ToInt32(Console.ReadLine());
        }

        static void borrarPeliculas()
        {
            Console.WriteLine("Escribe el nombre de la pelicula para eliminar: ");
            var nombre = Console.ReadLine();
            var pelicula = Peliculas.FirstOrDefault(x => x.Nombre.ToLower() == nombre.ToLower());
            if (pelicula == null)
            {
                Console.WriteLine("El usuario que intentas eliminar no existe\n");
                return;
            }
            Peliculas.Remove(pelicula);
        }

        static void alquilarPelicula()
        {
            Console.WriteLine("Escribe el nombre de la pelicula para alquilar: ");
            var nombre = Console.ReadLine();
            var pelicula = Peliculas.FirstOrDefault(x => x.Nombre.ToLower() == nombre.ToLower());
            if (pelicula == null)
            {
                Console.WriteLine("\nLa pelicula al modificar no existe\n");
                return;
            }

            UsuarioActual.Peliculas.Add(pelicula);

        }

        static void peliculasAlquiladas()
        {
            Console.WriteLine("\nListado de peliculas alquiladas\n");
            foreach (var pelicula in UsuarioActual.Peliculas)
            {
                Console.WriteLine($"Pelicula:{pelicula.Nombre} Fecha de retorno:{pelicula.FechaDeRetorno} ");
            }

        }

        static void gananciaPeliculas()
        {
            Console.Write("Ganancias de las peliculas");
            var ganancia = 0.0f;
            foreach (var pelicula in Peliculas.Where(x => x.FechaDeRetorno != null))
            {
                ganancia += pelicula.Precio;
            }

            Console.WriteLine($"La ganancia es de ${ganancia}");
        }

        



        #endregion

        #region Clientes

        static void agregarCliente()
        {
            var newUsuario = new Usuario();
            newUsuario.TipoDeUsuario = TiposDeUsuario.Cliente;
            Console.WriteLine("Escribe primer nombre:");
            newUsuario.Nombre = Console.ReadLine();
            Console.WriteLine("Escribe apellido: ");
            newUsuario.Apellido = Console.ReadLine();
            Console.WriteLine("Escribe la direccion: ");
            newUsuario.Direccion = Console.ReadLine();
            Console.WriteLine("Escribe nuevo correo de usuario: ");
            newUsuario.Correo = Console.ReadLine();
            Console.WriteLine("Asigna contraseña al usuario: ");
            newUsuario.Password = Console.ReadLine();
            Usuarios.Add(newUsuario);

        }

        static void editarCliente()
        {
            Console.WriteLine("Escribe el correo del cliente: ");
            var correo = Console.ReadLine();
            var cliente = Empleados.FirstOrDefault(x => x.Correo.ToLower() == correo.ToLower());
            if (cliente == null)
            {
                Console.WriteLine("El cliente que intentas modificar no existe\n");
                return;
            }
            Console.WriteLine($"Modificando cliente:\n {cliente}");
            Console.WriteLine("Escribe primer nombre:");
            cliente.Nombre = Console.ReadLine();
            Console.WriteLine("Escribe apellido: ");
            cliente.Apellido = Console.ReadLine();
            Console.WriteLine("Escribe la direccion: ");
            cliente.Direccion = Console.ReadLine();
            Console.WriteLine("Escribe nuevo correo de cliente: ");
            cliente.Correo = Console.ReadLine();
            Console.WriteLine("Asigna contraseña al cliente: ");
            cliente.Password = Console.ReadLine();

        }

        static void listarClientes()
        {
            Console.WriteLine("\nListado de clientes\n");
            foreach (var usuario in Usuarios)
            {
                Console.WriteLine($"{usuario.Nombre} {usuario.Apellido} <{usuario.Correo}>");
            }
        }

        static void borrarCliente()
        {
            Console.WriteLine("Escribe el correo del cliente para eliminar: ");
            var correo = Console.ReadLine();
            var cliente = Usuarios.FirstOrDefault(x => x.Correo.ToLower() == correo.ToLower());
            if (cliente == null)
            {
                Console.WriteLine("El usuario que intentas eliminar no existe\n");
                return;
            }
            Usuarios.Remove(cliente);
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

        #region Guardar

        static void guardar()
        {
            // Este metodo permite guardar los cambios en la base de datos
            string docPath = AppDomain.CurrentDomain.BaseDirectory;

            var usuariosSerializados = JsonConvert.SerializeObject(Usuarios);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Usuarios.txt")))
            {
                outputFile.Write(usuariosSerializados);
            }

            var peliculasSerializados = JsonConvert.SerializeObject(Peliculas);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Peliculas.txt")))
            {
                outputFile.Write(peliculasSerializados);
            }

            var empleadosSerializados = JsonConvert.SerializeObject(Empleados);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Empleados.txt")))
            {
                outputFile.Write(empleadosSerializados);
            }
        }

        #endregion 
    }
}