using System;
using ConsoleApp1.Clases;

////namespace DistribuidoraExpressConsola
//namespace ConsoleApp1
//{
//    internal class Program
//    {
//        static Stock StockProductos = new Stock(); // creamos e inicializamos el objeto Stock con el costructor
//        static Negocio[] Negocios = new Negocio[100]; // creamos el Arreglo de negocios
//        static int contadorNegocios = 0; // Contador de negocios en el arreglo



//        static void Main(string[] args)
//        {
//            bool continuar = true;

//            while (continuar)
//            {
//                // Menú principal
//                Console.Clear();
//                Console.WriteLine("=== MENÚ PRINCIPAL ===");
//                Console.WriteLine("1. Gestión de Productos ");
//                Console.WriteLine("2. Gestión de Negocios ");
//                Console.WriteLine("3. Gestion de Pedidos y Órdenes de Entrega ");
//                Console.WriteLine("4. Facturación y Gestión de Datos");
//                Console.WriteLine("0. Salir");
//                Console.Write("Seleccione una opción: ");

//                if (int.TryParse(Console.ReadLine(), out int opcionNumerica))
//                {
//                    switch (opcionNumerica)
//                    {
//                        case 1:
//                            GestionProductos.Menu(StockProductos);
//                            break;
//                        case 2:
//                            GestionDeNegocios.Menu(Negocios, ref contadorNegocios);
//                            break;
//                        case 3:
//                            PedidosYOrdenesDeEntrega();
//                            break;
//                        case 4:
//                            FacturacionYGestionDeDatos();
//                            break;
//                        case 0: // el "0" por convención se usa en sistemas de menú para salir o volver al menu ppal.
//                            continuar = false;
//                            break;
//                        default:
//                            Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
//                            Console.ReadKey();
//                            break;
//                    }

//                }
//                else
//                {
//                    Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
//                    Console.ReadKey();
//                }

//            }
//        }
//        static void PedidosYOrdenesDeEntrega()
//        {
//            bool submenuActivo = true;

//            while (submenuActivo)
//            {
//                Console.Clear();
//                Console.WriteLine("=== PEDIDOS Y ÓRDENES DE ENTREGA ===");
//                Console.WriteLine("1. Ver Pedidos");
//                Console.WriteLine("2. Agregar Pedido");
//                Console.WriteLine("3. Modificar Pedido");
//                Console.WriteLine("4. Eliminar Pedido");
//                Console.WriteLine("5. Ver ordenes de Entrega");
//                Console.WriteLine("6. Modificar Orden de Entrega");
//                Console.WriteLine("7. Ver Stock");
//                Console.WriteLine("8. Actualizar Stock");
//                Console.WriteLine("0. Volver al Menú Principal");
//                Console.Write("Seleccione una opción: ");

//                string opcion = Console.ReadLine();

//                switch (opcion)
//                {
//                    case "1":
//                        Console.WriteLine("Función para ver pedidos...");
//                        // Aquí iría la lógica para ver pedidos
//                        break;
//                    case "2":
//                        Console.WriteLine("Función para agregar pedido...");
//                        // Aquí iría la lógica para agregar un pedido
//                        break;
//                    case "3":
//                        Console.WriteLine("Función para modificar pedido...");
//                        // Aquí iría la lógica para modificar un pedido
//                        break;
//                    case "4":
//                        Console.WriteLine("Función para eliminar pedido...");
//                        // Aquí iría la lógica para eliminar un pedido
//                        break;
//                    case "5":
//                        Console.WriteLine("Función para ver las ordenes de entrega...");
//                        // Aquí iría la lógica para registrar una orden de entrega
//                        break;
//                    case "6":
//                        Console.WriteLine("Función para modificar orden de entrega...");
//                        // Aquí iría la lógica para modificar una orden de entrega
//                        break;
//                    case "7":
//                        Console.WriteLine("Función para ver el stock...");
//                        // Aquí iría la lógica para ver el stock
//                        break;
//                    case "8":
//                        Console.WriteLine("Función para actualizar el stock...");
//                        // Aquí iría la lógica para actualizar el stock
//                        break;
//                    case "0":
//                        submenuActivo = false;
//                        break;
//                    default:
//                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
//                        Console.ReadKey();
//                        break;
//                }
//            }
//        }
//        static void FacturacionYGestionDeDatos()
//        {
//            bool submenuActivo = true;

//            while (submenuActivo)
//            {
//                Console.Clear();
//                Console.WriteLine("=== FACTURACIÓN Y GESTIÓN DE DATOS ===");
//                Console.WriteLine("1. Generar Factura");
//                Console.WriteLine("2. Consultar Factura");
//                Console.WriteLine("3. Actualizar Datos de Cliente");
//                Console.WriteLine("0. Volver al Menú Principal");
//                Console.Write("Seleccione una opción: ");

//                string opcion = Console.ReadLine();

//                switch (opcion)
//                {
//                    case "1":
//                        Console.WriteLine("Función para generar factura...");
//                        break;
//                    case "2":
//                        Console.WriteLine("Función para consultar factura...");
//                        break;
//                    case "3":
//                        Console.WriteLine("Función para actualizar datos del cliente...");
//                        break;
//                    case "0": // el "0" por convención se usa en sistemas de menú para salir o volver al menu ppal.
//                        submenuActivo = false;
//                        break;
//                    default:
//                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
//                        Console.ReadKey();
//                        break;
//                }
//            }
//        }
//    }
//}
using System.Globalization;
using ConsoleApp1.Clases;
using System.Linq;

class Program
{
    const int MAX_PRODUCTOS = 100;
    const int MAX_ITEMS_VENTA = 50;
    const decimal IVA = 0.16m; // 16% de IVA

    static Producto[] productos = new Producto[MAX_PRODUCTOS];
    static int cantidadProductos = 0;

    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        bool salir = false;

        do
        {
            Console.WriteLine("\nSistema de Ventas");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Realizar Venta");
            Console.WriteLine("3. Mostrar Productos");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione opción: ");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;
                    case 2:
                        RealizarVenta();
                        break;
                    case 3:
                        MostrarProductos();
                        break;
                    case 4:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ingrese un número válido");
            }

        } while (!salir);
    }

    static void AgregarProducto()
    {
        if (cantidadProductos >= MAX_PRODUCTOS)
        {
            Console.WriteLine("No se pueden agregar más productos");
            return;
        }

        Console.Clear();
        Console.WriteLine("=== AGREGAR NUEVO PRODUCTO ===");

        Producto nuevoProducto = new Producto();

        Console.Write("Nombre: ");
        nuevoProducto.Nombre = Console.ReadLine();

        Console.Write("Precio: ");
        nuevoProducto.Precio = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Cantidad en stock: ");
        nuevoProducto.CantidadEnStock = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Seleccione la categoría del producto:");
        Console.WriteLine("1. Equipamiento Deportivo");
        Console.WriteLine("2. Ropa y Calzado Deportivo");
        Console.WriteLine("3. Accesorios para Entrenamiento");
        Console.WriteLine("4. Equipamiento para Deportes de Aventura");
        Console.WriteLine("5. Nutrición y Suplementos");
        Console.WriteLine("6. Tecnología y Dispositivos Deportivos");

        int categoriaOpcion;
        if (int.TryParse(Console.ReadLine(), out categoriaOpcion))
        {
            switch (categoriaOpcion)
            {
                case 1:
                    Console.Write("Tipo de equipamiento: ");
                    string tipo = Console.ReadLine();
                    nuevoProducto = new EquipamientoDeportivo(nuevoProducto.Nombre, nuevoProducto.Precio, nuevoProducto.CantidadEnStock, tipo);
                    break;
                case 2:
                    Console.Write("Talla: ");
                    string talla = Console.ReadLine();
                    nuevoProducto = new RopaYCalzadoDeportivo(nuevoProducto.Nombre, nuevoProducto.Precio, nuevoProducto.CantidadEnStock, talla);
                    break;
                case 3:
                    Console.Write("Material: ");
                    string material = Console.ReadLine();
                    nuevoProducto = new AccesoriosParaEntrenamiento(nuevoProducto.Nombre, nuevoProducto.Precio, nuevoProducto.CantidadEnStock, material);
                    break;
                case 4:
                    Console.Write("Uso: ");
                    string uso = Console.ReadLine();
                    nuevoProducto = new EquipamientoParaDeportesDeAventura(nuevoProducto.Nombre, nuevoProducto.Precio, nuevoProducto.CantidadEnStock, uso);
                    break;
                case 5:
                    Console.Write("Ingredientes: ");
                    string ingredientes = Console.ReadLine();
                    nuevoProducto = new NutricionYSuplementos(nuevoProducto.Nombre, nuevoProducto.Precio, nuevoProducto.CantidadEnStock, ingredientes);
                    break;
                case 6:
                    Console.Write("Especificaciones: ");
                    string especificaciones = Console.ReadLine();
                    nuevoProducto = new TecnologiaYDispositivosDeportivos(nuevoProducto.Nombre, nuevoProducto.Precio, nuevoProducto.CantidadEnStock, especificaciones);
                    break;
                default:
                    Console.WriteLine("Categoría no válida");
                    return;
            }
        }
        else
        {
            Console.WriteLine("Ingrese un número válido para la categoría");
            return;
        }

        productos[cantidadProductos] = nuevoProducto;
        cantidadProductos++;

        Console.WriteLine("Producto agregado!");
    }

    static void RealizarVenta()
    {
        if (cantidadProductos == 0)
        {
            Console.WriteLine("No hay productos registrados");
            return;
        }

        ProductoCantidad[] venta = new ProductoCantidad[MAX_ITEMS_VENTA];
        int itemsVendidos = 0;
        decimal subtotal = 0;
        int totalItems = 0;
        bool continuarVenta = true;

        while (continuarVenta && itemsVendidos < MAX_ITEMS_VENTA)
        {
            MostrarProductos();

            Console.Write("\nIngrese ID del producto (0 para terminar): ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id == 0)
            {
                continuarVenta = false;
                break;
            }

            Producto producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                Console.Write("Cantidad: ");
                int cantidad = Convert.ToInt32(Console.ReadLine());

                if (producto.CantidadEnStock >= cantidad)
                {
                    producto.CantidadEnStock -= cantidad;
                    venta[itemsVendidos] = new ProductoCantidad(producto, cantidad);
                    itemsVendidos++;
                    subtotal += producto.Precio * cantidad;
                    totalItems += cantidad;
                }
                else
                {
                    Console.WriteLine("Stock insuficiente!");
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado!");
            }
        }

        int gruposDescuento = totalItems / 10;
        decimal porcentajeDescuento = gruposDescuento * 0.05m;
        decimal descuento = subtotal * porcentajeDescuento;

        decimal subtotalConDescuento = subtotal - descuento;
        decimal valorIva = subtotalConDescuento * IVA;
        decimal total = subtotalConDescuento + valorIva;

        Console.WriteLine("\n--- FACTURA ---");
        for (int i = 0; i < itemsVendidos; i++)
        {
            Console.WriteLine($"{venta[i].Producto.Nombre} x{venta[i].Cantidad}: {venta[i].Producto.Precio * venta[i].Cantidad:C}");
        }

        Console.WriteLine("\nDETALLE DE PAGO:");
        Console.WriteLine($"Productos comprados: {totalItems}");
        Console.WriteLine($"Subtotal: {subtotal:C}");
        Console.WriteLine($"Descuento ({porcentajeDescuento:P0}): -{descuento:C}");
        Console.WriteLine($"Subtotal con descuento: {subtotalConDescuento:C}");
        Console.WriteLine($"IVA (16%): {valorIva:C}");
        Console.WriteLine($"TOTAL A PAGAR: {total:C}\n");
    }

    static void MostrarProductos()
    {
        Console.WriteLine("\nLista de Productos:");
        Console.WriteLine("ID\tNombre\tPrecio\tStock");
        for (int i = 0; i < cantidadProductos; i++)
        {
            Console.WriteLine($"{productos[i].Id}\t{productos[i].Nombre}\t{productos[i].Precio:C}\t{productos[i].CantidadEnStock}");
        }
    }
}