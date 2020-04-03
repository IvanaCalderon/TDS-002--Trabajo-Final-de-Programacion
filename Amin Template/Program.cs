using System;
using System.IO;

namespace Amin_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            class Program
        {
            static void Main(string[] args)
            {
                LogIn();
            }

            public static void LogIn()
            {
                Cliente cliente = new Cliente();


                Console.WriteLine("1-Crear ticket");
                Console.WriteLine("2-Ver historial ");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Escriba su Cedula o pasaporte");
                        cliente.setCedulaOrPass(Console.ReadLine());
                        Console.WriteLine("Escriba su Nombre");
                        cliente.setNombre(Console.ReadLine());
                        Console.WriteLine("Escriba su apellido");
                        cliente.setApellido(Console.ReadLine());

                        Consulta(cliente);
                        Console.ReadKey();
                        break;
                    case 2:
                        VerHistorial();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        Thread.Sleep(4000);
                        LogIn();

                        break;

                }

            }

            static void Consulta(Cliente cliente)
            {
                Console.WriteLine("1-Cambiazo");
                Console.WriteLine("2-Reclamaciones");
                Console.WriteLine("3-Adquirir servicios");
                Console.WriteLine("4-Servicio al cliente");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Ticket("Cambiazo", cliente);
                        break;
                    case 2:
                        Ticket("Reclamacion", cliente);
                        break;
                    case 3:
                        Ticket("Adquirir Servicios", cliente);
                        break;
                    case 4:
                        Ticket("Servicio al cliente", cliente);
                        break;

                    default:
                        Console.WriteLine("Opcion invalida");
                        Thread.Sleep(4000);
                        LogIn();

                        break;
                }


            }
            static void Ticket(string Consulta, Cliente cliente)
            {
                //Cliente cliente = new Cliente();

                Random random = new Random();

                Console.WriteLine("Numero de caja: " + random.Next(1, 20) + "                 " + DateTime.Now + "\n\n\n " + "Ticket: " + GetRandomAlfanumericTokenString(5) + "\n" + "nombre: " + cliente.getnombre() + " apellido: " + cliente.getApellido());




                string ruta = @"C:\Users\Amin Mesa Rosario\Desktop\tickets.txt";


                if (File.Exists(ruta))
                {
                    StreamWriter WriteReportFile = File.AppendText(@"C:\Users\Amin Mesa Rosario\Desktop\tickets.txt");
                    WriteReportFile.WriteLine("Numero de caja: " + random.Next(0, 20) + "                 " + DateTime.Now + "\n\n\n " + "Ticket: " + GetRandomAlfanumericTokenString(5) + "\n" + "nombre: " + cliente.getnombre() + " apellido: " + cliente.getApellido());
                    WriteReportFile.Close();
                }
                else
                {
                    using (FileStream fs = File.Create(ruta)) ;

                    StreamWriter WriteReportFile = File.AppendText(@"C:\Users\Amin Mesa Rosario\Desktop\tickets.txt");
                    WriteReportFile.WriteLine("Numero de caja: " + random.Next(0, 20) + "                 " + DateTime.Now + "\n\n\n " + "Ticket: " + GetRandomAlfanumericTokenString(5) + "\n" + "nombre: " + cliente.getnombre() + " apellido: " + cliente.getApellido());
                    WriteReportFile.Close();
                }

                Console.WriteLine("Ticket creado correctamente volviendo al menu ");
                Thread.Sleep(4000);
                Console.Clear();
                LogIn();
            }

            static void VerHistorial()
            {
                string ruta = @"C:\Users\Amin Mesa Rosario\Desktop\tickets.txt";
                if (!File.Exists(ruta))
                {
                    Console.WriteLine("El archivo fue creado pero no contiene logs");
                    using (FileStream fs = File.Create(ruta)) ;


                    Thread.Sleep(4000);
                    //Console.Clear();
                    LogIn();
                }

                else
                {
                    int counter = 0;
                    string line;
                    StreamReader file = new StreamReader(@"C:\Users\Amin Mesa Rosario\Desktop\tickets.txt");


                    while ((line = file.ReadLine()) != null)
                    {

                        Console.WriteLine(line);
                        Console.WriteLine(Environment.NewLine);
                        counter++;
                    }

                    string check = line = file.ReadLine();

                    if (check == null & counter == 0)
                    {
                        Console.WriteLine("El archivo no tiene  mas registros");
                    }




                    file.Close();

                    Thread.Sleep(4000);
                    Console.Clear();
                    LogIn();
                }


            }


            public static string GetRandomAlfanumericTokenString(int length)
            {

                Random rnd = new Random();
                string charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
                StringBuilder rs = new StringBuilder();

                while (length > 0)
                {
                    rs.Append(charPool[(int)(rnd.NextDouble() * charPool.Length)]);
                    length--;
                }


                return rs.ToString();


            }

        }
        class Cliente
        {
            public string cedulaOrPass { get; set; }

            public string nombre { get; set; }

            public string apellido { get; set; }


            //----------------------
            public string getCedulaorPass()
            {
                return this.cedulaOrPass;
            }

            public void setCedulaOrPass(string cedulaOrPass)
            {
                this.cedulaOrPass = cedulaOrPass;
            }
            //------------------------
            public string getnombre()
            {
                return this.nombre;
            }

            public void setNombre(string nombre)
            {
                this.nombre = nombre;
            }
            //------------------------
            public string getApellido()
            {
                return this.apellido;
            }

            public void setApellido(string apellido)
            {
                this.apellido = apellido;
            }



        }
    }
}
