using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    public class GestionDeNegocios
    {

        // Menu para la Gestion de NEGOCIOS
        public static void Menu(Negocio[] negocios, ref int contadorNegocios)
        {
            bool submenuActivo = true;

            while (submenuActivo)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE NEGOCIOS ===");
                Console.WriteLine("1. Ver Negocios");
                Console.WriteLine("2. Agregar Negocio");
                Console.WriteLine("3. Modificar Negocio");
                Console.WriteLine("4. Eliminar Negocio");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcionNumerica))
                {
                    switch (opcionNumerica)
                    {
                        case 1: // Ver Negocios
                            if (!ArregloNegociosEstaVacio(contadorNegocios))
                            {
                                MostrarNegocios(negocios, contadorNegocios);
                                Console.WriteLine("Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Error: No hay Negocios disponibles!");
                                Console.WriteLine("tecla para continuar...");
                                Console.ReadKey();
                            }
                            break;
                        case 2: // Agregar Negocio
                            OpAgregarNegocio(negocios, ref contadorNegocios);
                            break;
                        case 3: // Modificar Negocio
                            OpModificarNegocio(negocios, contadorNegocios);
                            break;
                        case 4: // Eliminar Negocio
                            OpEliminarNegocio(negocios, ref contadorNegocios);
                            break;
                        case 0: // Volver al Menú Principal
                            submenuActivo = false;
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }


        // -----------------------------------------------------------------
        //          VER un negocio del arreglo  de negocios
        // -----------------------------------------------------------------
        private static void MostrarUnNegocio(Negocio negocio, bool MostrarEncabezadoTabla = false)
        {
            if (negocio != null && negocio.Id != 0) // Verifica que el Negocio esté inicializado y tenga un ID válido
            {
                if (MostrarEncabezadoTabla)
                {
                    Console.WriteLine("ID | Nombre | Ubicación | Teléfono | Email | Número de Pedidos");
                    // Línea separadora
                    Console.WriteLine(new string('-', 70));
                }
                Console.WriteLine($"{negocio.Id} | {negocio.Nombre} | {negocio.Ubicacion} | {negocio.Telefono} | {negocio.Email} | {negocio.contadorPedidos}");

            }
        }

        // -----------------------------------------------------------------
        //          VER lista de negocios del arreglo  de negocios
        // -----------------------------------------------------------------
        private static void MostrarNegocios(Negocio[] negocios, int contadorNegocios)
        {
            if (!ArregloNegociosEstaVacio(contadorNegocios))
            {
                Console.Clear();
                Console.WriteLine("=== LISTA DE NEGOCIOS ===");
                // Encabezado de la tabla
                Console.WriteLine("ID | Nombre | Ubicación | Teléfono | Email | Número de Pedidos");
                // Línea separadora
                Console.WriteLine(new string('-', 70));

                for (int i = 0; i < contadorNegocios; i++)
                {
                    MostrarUnNegocio(negocios[i]);
                }

            }
            else
            {
                Console.WriteLine("Error: No hay Negocios disponibles!");
                Console.WriteLine("tecla para continuar...");
                Console.ReadKey();
            }
        }


        // -----------------------------------------------------------------
        //          AGREGAR un nuevo negocio al arreglo  de negocios
        // -----------------------------------------------------------------
        private static void OpAgregarNegocio(Negocio[] negocios, ref int contadorNegocios)
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR NUEVO NEGOCIO ===");

            Negocio nuevoNegocio = new Negocio(); // crea objeto de clase Negocio

            // Recolectar información del nuevo negocio
            do
            {
                Console.Write("Ingrese el nombre del negocio:");
                nuevoNegocio.Nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nuevoNegocio.Nombre))
                {
                    Console.WriteLine("Error: Ingrese un dato válido.");
                }
            } while (string.IsNullOrWhiteSpace(nuevoNegocio.Nombre));

            do
            {
                Console.Write("Ingrese la direccion del negocio: ");
                nuevoNegocio.Ubicacion = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nuevoNegocio.Ubicacion))
                {
                    Console.WriteLine("Error: Ingrese un dato válido.");
                }
            } while (string.IsNullOrWhiteSpace(nuevoNegocio.Ubicacion));

            do
            {
                Console.Write("Ingrese el teléfono del negocio: ");
                nuevoNegocio.Telefono = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nuevoNegocio.Telefono))
                {
                    Console.WriteLine("Error: Ingrese un dato válido.");
                }
            } while (string.IsNullOrWhiteSpace(nuevoNegocio.Telefono));


            do
            {
                Console.Write("Ingrese el email del negocio: ");
                nuevoNegocio.Email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nuevoNegocio.Email))
                {
                    Console.WriteLine("Error: Ingrese un dato válido.");
                }
            } while (string.IsNullOrWhiteSpace(nuevoNegocio.Email));


            if (contadorNegocios < negocios.Length)
            {
                negocios[contadorNegocios] = nuevoNegocio;
                contadorNegocios++;
            }
            else
            {
                Console.WriteLine($"No se puede agregar un nuevo Negocio porque el arreglo alcanzó su capacidad máxima de {negocios.Length}.");
            }

            Console.WriteLine("Negocio agregado exitosamente. Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // -----------------------------------------------------------------
        //          MODIFICAR un negocio al arreglo  de negocios
        // -----------------------------------------------------------------
        private static void OpModificarNegocio(Negocio[] negocios, int contadorNegocios)
        {
            if (!ArregloNegociosEstaVacio(contadorNegocios))
            {
                Console.Clear();
                Console.WriteLine("=== MODIFICAR NEGOCIO ===");

                // mostrar negocios
                MostrarNegocios(negocios, contadorNegocios);

                Console.Write("Ingrese el ID del negocio a modificar: ");
                if (int.TryParse(Console.ReadLine(), out int IdNegocioModificar))
                {
                    int index = BuscarNegocioPorID(IdNegocioModificar, negocios, contadorNegocios);
                    if (index >= 0) // modificar, el producto SI existe en el Stock
                    {
                        if (negocios[index] != null)
                        {

                            Console.Write("Ingrese el nuevo nombre del negocio (dejar en blanco para no modificar): ");
                            string nombre = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nombre)) negocios[index].Nombre = nombre;

                            Console.Write("Ingrese la nueva direccion del negocio (dejar en blanco para no modificar): ");
                            string ubicacion = Console.ReadLine();
                            if (!string.IsNullOrEmpty(ubicacion)) negocios[index].Ubicacion = ubicacion;

                            Console.Write("Ingrese el nuevo teléfono del negocio (dejar en blanco para no modificar): ");
                            string telefono = Console.ReadLine();
                            if (!string.IsNullOrEmpty(telefono)) negocios[index].Telefono = telefono;

                            Console.Write("Ingrese el nuevo email del negocio (dejar en blanco para no modificar): ");
                            string email = Console.ReadLine();
                            if (!string.IsNullOrEmpty(email)) negocios[index].Email = email;

                            Console.WriteLine("Producto modificado  exitosamente.");
                            Console.WriteLine("Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Negocio con ID = {IdNegocioModificar} no existe!!.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Error: No hay Negocios disponibles!");
                Console.WriteLine("tecla para continuar...");
                Console.ReadKey();
            }
        } // fin modificar negocio


        // -----------------------------------------------------------------
        //          ELIMINAR un negocio del arreglo  de negocios
        // -----------------------------------------------------------------
        private static void OpEliminarNegocio(Negocio[] negocios, ref int contadorNegocios)
        {
            if (!ArregloNegociosEstaVacio(contadorNegocios))
            {
                Console.Clear();
                Console.WriteLine("=== ELIMINAR NEGOCIO ===");

                // mostrar negocios
                MostrarNegocios(negocios, contadorNegocios);

                // ingresar id del negocio
                Console.Write("Ingrese el ID del negocio a eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int idEliminar))
                {
                    int index = BuscarNegocioPorID(idEliminar, negocios, contadorNegocios);
                    if (index >= 0)
                    {
                        // Desplazar los Negocios para llenar el espacio del Negocio eliminado
                        for (int i = index; i < contadorNegocios - 1; i++)
                        {
                            negocios[i] = negocios[i + 1];
                        }
                        negocios[contadorNegocios - 1] = new Negocio(); // Reinicializar la última posición
                        contadorNegocios--;

                        Console.WriteLine("Producto eliminado  exitosamente!.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"El Negocio con ID = {idEliminar} no existe!.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido. ");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Error: No hay Negocios disponibles!");
                Console.WriteLine("tecla para continuar...");
                Console.ReadKey();
            }
        }


        // Método para buscar un negocio por su ID
        private static int BuscarNegocioPorID(int idNegocio, Negocio[] negocios, int contadorNegocios)
        {
            for (int i = 0; i < contadorNegocios; i++)
            {
                if (negocios[i].Id == idNegocio)
                {
                    return i; // Retorna la posición del Negocio en el arreglo
                }
            }
            return -1; // Retorna -1 si no se encuentra el Negocio
        }

        private static Negocio ObtenerNegocioPorID(int idNegocio, Negocio[] negocios, int contadorNegocios)
        {
            for (int i = 0; i < contadorNegocios; i++)
            {
                if (negocios[i].Id == idNegocio)
                {
                    return negocios[i]; // Retorna la posición del Negocio en el arreglo
                }
            }
            return null; // Retorna null si no se encuentra el Negocio
        }

        private static bool ArregloNegociosEstaVacio(int contadorNegocios)
        {  // Está vacio el Negocio?
            if (contadorNegocios == 0) // el Negocio está vacío
            {
                return true;
            }
            return false; // no está vacio

        }

        public static Negocio[] ObtenerNegociosPredefinidos()
        {
            return new Negocio[]
            {
        new Negocio(1, "Tienda Electrónica Global", "Calle Principal 123", "555-1234", "ana@tiendaelectronica.com", 100),
        new Negocio(2, "Supermercado La Esquina", "Avenida Central 456", "555-5678", "carlos@supermercadolaesquina.com", 100),
        new Negocio(3, "Ferretería El Tornillo Feliz", "Calle Secundaria 789", "555-9012", "laura@eltornillofeliz.com", 100)
            };
        }

        private static bool ArregloNegociosEstalleno(int contadorNegocios)
        { // Está lleno el arreglo Negocios[] que almacena el Negocio?
            if (contadorNegocios == 100) // el Negocio está lleno
            {
                return true;
            }
            return false; // no esta lleno
        }
    }
}