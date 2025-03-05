using System;
using ConsoleApp1.Clases;
using proyecto2.gestores;
using proyecto2.modelos;

namespace ConsoleApp1
{
    internal class Program
    {
        static Stock StockProductos = new Stock(); // creamos e inicializamos el objeto Stock con el constructor
        static Negocio[] Negocios = new Negocio[100]; // creamos el Arreglo de negocios
        static int contadorNegocios = 0; // Contador de negocios en el arreglo
        static GestorPedidos gestorPedidos = new GestorPedidos();
        static Factura gestorFacturas = new Factura();

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
                Console.WriteLine("3. Gestión de Pedidos y Órdenes de Entrega ");
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
                        case 0: // el "0" por convención se usa en sistemas de menú para salir o volver al menú principal.
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
                Console.WriteLine("5. Ver Órdenes de Entrega");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        gestorPedidos.VerPedidos();
                        break;
                    case "2":
                        gestorPedidos.AgregarPedido(Negocios, productos: StockProductos.GetProductos());
                        break;
                    case "3":
                        gestorPedidos.ModificarPedido();
                        break;
                    case "4":
                        gestorPedidos.EliminarPedido();
                        break;
                    case "5":
                        gestorPedidos.VerOrdenesEntrega();
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
                Console.WriteLine("2. Ver Facturas");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        gestorFacturas.GenerarFactura(gestorPedidos);
                        break;
                    case "2":
                        gestorFacturas.VerFacturas();
                        break;
                    case "0": // el "0" por convención se usa en sistemas de menú para salir o volver al menú principal.
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