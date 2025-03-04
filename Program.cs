using System;
using ConsoleApp1.Clases;

//namespace DistribuidoraExpressConsola
namespace ConsoleApp1
{
    internal class Program
    {
        static Stock StockProductos = new Stock(); // creamos e inicializamos el objeto Stock con el costructor
        static Negocio[] Negocios = new Negocio[100]; // creamos el Arreglo de negocios
        static int contadorNegocios = 0; // Contador de negocios en el arreglo



        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                // Menú principal
                Console.Clear();
                Console.WriteLine("=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Gestión de Productos ");
                Console.WriteLine("2. Gestión de Negocios ");
                Console.WriteLine("3. Gestion de Pedidos y Órdenes de Entrega ");
                Console.WriteLine("4. Facturación y Gestión de Datos");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcionNumerica))
                {
                    switch (opcionNumerica)
                    {
                        case 1:
                            GestionProductos.Menu(StockProductos);
                            break;
                        case 2:
                            GestionDeNegocios.Menu(Negocios, ref contadorNegocios);
                            break;
                        case 3:
                            PedidosYOrdenesDeEntrega();
                            break;
                        case 4:
                            FacturacionYGestionDeDatos();
                            break;
                        case 0: // el "0" por convención se usa en sistemas de menú para salir o volver al menu ppal.
                            continuar = false;
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
        static void PedidosYOrdenesDeEntrega()
        {
            bool submenuActivo = true;

            while (submenuActivo)
            {
                Console.Clear();
                Console.WriteLine("=== PEDIDOS Y ÓRDENES DE ENTREGA ===");
                Console.WriteLine("1. Ver Pedidos");
                Console.WriteLine("2. Agregar Pedido");
                Console.WriteLine("3. Modificar Pedido");
                Console.WriteLine("4. Eliminar Pedido");
                Console.WriteLine("5. Ver ordenes de Entrega");
                Console.WriteLine("6. Modificar Orden de Entrega");
                Console.WriteLine("7. Ver Stock");
                Console.WriteLine("8. Actualizar Stock");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Función para ver pedidos...");
                        // Aquí iría la lógica para ver pedidos
                        break;
                    case "2":
                        Console.WriteLine("Función para agregar pedido...");
                        // Aquí iría la lógica para agregar un pedido
                        break;
                    case "3":
                        Console.WriteLine("Función para modificar pedido...");
                        // Aquí iría la lógica para modificar un pedido
                        break;
                    case "4":
                        Console.WriteLine("Función para eliminar pedido...");
                        // Aquí iría la lógica para eliminar un pedido
                        break;
                    case "5":
                        Console.WriteLine("Función para ver las ordenes de entrega...");
                        // Aquí iría la lógica para registrar una orden de entrega
                        break;
                    case "6":
                        Console.WriteLine("Función para modificar orden de entrega...");
                        // Aquí iría la lógica para modificar una orden de entrega
                        break;
                    case "7":
                        Console.WriteLine("Función para ver el stock...");
                        // Aquí iría la lógica para ver el stock
                        break;
                    case "8":
                        Console.WriteLine("Función para actualizar el stock...");
                        // Aquí iría la lógica para actualizar el stock
                        break;
                    case "0":
                        submenuActivo = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void FacturacionYGestionDeDatos()
        {
            bool submenuActivo = true;

            while (submenuActivo)
            {
                Console.Clear();
                Console.WriteLine("=== FACTURACIÓN Y GESTIÓN DE DATOS ===");
                Console.WriteLine("1. Generar Factura");
                Console.WriteLine("2. Consultar Factura");
                Console.WriteLine("3. Actualizar Datos de Cliente");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Función para generar factura...");
                        break;
                    case "2":
                        Console.WriteLine("Función para consultar factura...");
                        break;
                    case "3":
                        Console.WriteLine("Función para actualizar datos del cliente...");
                        break;
                    case "0": // el "0" por convención se usa en sistemas de menú para salir o volver al menu ppal.
                        submenuActivo = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
