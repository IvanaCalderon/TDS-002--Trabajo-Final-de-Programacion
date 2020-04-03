using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Proyecto_final_de_programacion
{
    class Program
    {
        public static void Main(string[] args)
        {






            string loginAdmin = @"C:\demos\demo.txt";
            
            string[] lines = File.ReadAllLines(loginAdmin);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine(lines[0]);

            Console.ReadKey();









            static void menuInicio() //Menu que aparece al iniciar la aplicacion
            {
                Console.WriteLine("Bienvenido al sistema de alquiler de peliculas");
                Console.WriteLine("Ingrese el numero para el tipo de usuario que quiere acceder");
                Console.WriteLine("[1] - Administrador");
                Console.WriteLine("[2] - Empleado");
                Console.WriteLine("[3] - Cliente");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        loginAdministador();
                        break;
                    case 2:
                        loginEmpleado();
                        break;
                    case 3:
                        loginCiente();
                        break;
                    default:
                        menuInicio();
                        break;

                }

            }

            static void loginCiente() //Login de los clientes
            {
                Console.WriteLine("Ingresa  tu nombre de usuario");
                Console.ReadLine();
                Console.WriteLine("Ingresa tu contraseña");
                Console.ReadLine();


            }


            static void loginEmpleado() //Login de los epleados
            {
                Console.WriteLine("Ingresa  tu nombre de usuario");
                Console.ReadLine();
                Console.WriteLine("Ingresa tu contraseña");
                Console.ReadLine();


            }

            static void loginAdministador() //Login del Administrador
            {
                String loginAdmin = @"C:\Users\Lisa\source\repos\Proyecto_final_de_programacion";

                Console.WriteLine("Ingresa  tu nombre de usuario");
                Console.ReadLine();
                Console.WriteLine("Ingresa tu contraseña");
                Console.ReadLine();


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
            }


            static void menuCliente() // Menu del Cliente
            {
                Console.WriteLine("Elige la accion que quieres:");
                Console.WriteLine("[1] - Alquilar pelicula");
                Console.WriteLine("[2] - Lista de peliculas alquiladas");
                Console.WriteLine("[3] - Fecha de entrega de pelicula");

            }

            static void menuEmpleado() // Menu del empleado
            {
                Console.WriteLine("Elige la accion que quieres:");
                Console.WriteLine("[1] - Agregar cliente");
                Console.WriteLine("[2] - Editar cliente");
                Console.WriteLine("[3] - Alquilar pelicula a cliente");
                Console.WriteLine("[4] - Peliculas alquiladas");
            }


            static void agregarEmpleado() //jjj
            {
                Console.WriteLine("Escribe nuevo nombre de usuario: ");
                Console.ReadLine();
                Console.WriteLine("Asigna contraseña al usuario: ");
                Console.ReadLine();
                Console.WriteLine("Escribe primer nombre:");
                Console.ReadLine();
                Console.WriteLine("Escribe apellido: ");
                Console.ReadLine();
                Console.WriteLine("Escribe direccion: ");
                Console.ReadLine();
                Console.WriteLine("Escribe el cargo: ");

        }   }
           


            
          



        class Administrador
        {
            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public string Direccion { get; set; }

            public string Cargo { get; set; }

        }

        class Empleado
        {
            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public string Direccion { get; set; }

            public string Cargo { get; set; }

        }

        class Cliente
        {
            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public string Direccion { get; set; }

          

        }

        class nanana { }

        


    }
}
