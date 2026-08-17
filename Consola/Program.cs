using Dominio;
namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = Sistema.Instancia;
            string opcionMenu = "";
            while (opcionMenu != "0")
            {
                Console.Clear();
                MostrarMenu();//se muestra el menu
                opcionMenu = Console.ReadLine();
                switch (opcionMenu)//Segun la opcion ingresada recorre una opcion u otra
                {
                    case "0":
                        Console.WriteLine("Cerrando Menu ........");
                        break;
                    case "1":
                        Console.WriteLine("/**********************PERSONAS(CON ACTIVOS ASOCIADOS)********************/\n\n");
                        if (sistema.Personas.Count == 0)
                        {
                            throw new Exception("No hay personas en la base de datos");
                        }
                        foreach (Persona persona in sistema.Personas)
                        {
                            Console.WriteLine($"{persona}");//llama al ToString de Persona

                            bool tieneActivos = false;

                            foreach (Activo activo in sistema.Activos)
                            {
                                if (activo.Cuenta.Titular.Cedula == persona.Cedula)
                                {
                                    Console.WriteLine("     " + $"{activo}");//le añade los activos llamando al ToString de Activo
                                    tieneActivos = true;
                                }
                            }

                            if (!tieneActivos)
                            {
                                Console.WriteLine("     Sin activos asociados.");
                            }

                            Console.WriteLine();
                        }
                        Console.WriteLine("Presione enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();//limpia la consola para que no quede todo escrito y se vea mas ordenado
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Ingrese la cédula de la persona:");
                            string cedula = Console.ReadLine();//pide la cedula para obtener la persona y luego sus incidentes asociados

                            Persona personaEncontrada = null;

                            foreach (Persona persona in sistema.Personas)
                            {
                                if (persona.Cedula == cedula)
                                {
                                    personaEncontrada = persona;
                                }
                            }

                            if (personaEncontrada == null)
                            {
                                throw new Exception("No se encontró una persona con esa cédula.");
                            }

                            if (sistema.ObtenerIncidentesPorPersona(personaEncontrada).Count == 0)//si la persona no tiene incidentes asociados se muestra un mensaje de error
                            {
                                throw new Exception("No se encontraron incidentes para esa persona.");
                            }

                            foreach (Incidente incidente in sistema.ObtenerIncidentesPorPersona(personaEncontrada))//si tiene incidentes asociados se muestran por pantalla llamando al ToString de Incidente
                            {
                                Console.WriteLine($"{incidente}");
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message); // Se muestran mensajes de error de las validaciones realizadas en el constructor de la clase.
                        }
                        Console.WriteLine("Presione enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":

                        bool seIngreso = false;

                        while (!seIngreso)
                        {
                            try
                            {
                                Console.WriteLine("Ingrese la cédula:");
                                string cedula = Console.ReadLine();

                                Console.WriteLine("Ingrese el nombre:");
                                string nombre = Console.ReadLine();

                                Console.WriteLine("Ingrese el email:");
                                string email = Console.ReadLine();

                                Console.WriteLine("Ingrese el teléfono:");
                                string telefono = Console.ReadLine();

                                Console.WriteLine("Ingrese la contraseña:");
                                string contrasenia = Console.ReadLine();

                                Console.WriteLine("Ingrese el rol (1-Administrador / 2-Operador):");
                                int opcionRol = int.Parse(Console.ReadLine());

                                Rol rol;

                                if (opcionRol == 1)
                                {
                                    rol = Rol.ADMIN;
                                }
                                else
                                {
                                    rol = Rol.OPERADOR;
                                }

                                Persona personaNueva = new Persona(
                                    cedula,
                                    nombre,
                                    email,
                                    telefono,
                                    contrasenia,
                                    rol);

                                sistema.AgregarPersona(personaNueva);

                                Console.WriteLine("La persona se ha ingresado con éxito.");
                                seIngreso = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Presione Enter para continuar.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("/**********************ACTIVOS SIN BACKUP********************/\n\n");

                            if (sistema.ObtenerActivosSinBackup().Count == 0)
                            {
                                throw new Exception("No hay activos sin backup.");
                            }

                            foreach (Activo activo in sistema.ObtenerActivosSinBackup())
                            {
                                Console.WriteLine(activo); //se muestra por pantalla cada activo sin backup llamando al ToString de Activo.
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                        Console.WriteLine("Presione enter para continuar.");
                        Console.ReadLine();
                        break;
                    default: //si se ingresa una opcion que no esta en el menu se muestra un mensaje de error.
                        Console.WriteLine("Opción no disponible\nPresione enter para continuar.");
                        Console.ReadLine();
                        break;
                }
            }
            static void MostrarMenu()//metodo para mostrar el menu por pantalla.
            {
                Console.WriteLine("1 - Listar Personas");
                Console.WriteLine("2 - Listar Incidentes por persona involucrada");
                Console.WriteLine("3 - Dar de Alta Persona");
                Console.WriteLine("4 - Listar Activos que carecen de Backup");
                Console.WriteLine("0 - Salir");
            }

        }
    }
}