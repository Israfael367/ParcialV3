using System;
using proyecto2.modelos;
using static proyecto2.modelos.PedidoPreventivo;
using ConsoleApp1.Clases;

namespace proyecto2.gestores
{

    /*
    TDA GestorPedidos

    -----------Descripción-----------

    El TDA (Tipo de Datos Abstracto) GestorPedidos representa la gestión de pedidos en un sistema de inventario. Este TDA permite ver, agregar, modificar y eliminar pedidos, así como gestionar las órdenes de entrega.

    -----------Atributos-----------

    - pedidos: Array que almacena los pedidos realizados. (Tipo: PedidoPreventivo[])
    - cantidadPedidos: Contador para llevar el seguimiento de los pedidos almacenados. (Tipo: int)
    - ordenesEntrega: Array que almacena las órdenes de entrega generadas. (Tipo: PedidoPreventivo[])
    - cantidadOrdenesEntrega: Contador para llevar el seguimiento de las órdenes de entrega almacenadas. (Tipo: int)

    -----------Métodos-----------

    - VerPedidos()
      Muestra la lista de pedidos realizados con sus detalles correspondientes.

    - AgregarPedido(Negocio[] negocios, Producto[] productos)
      Permite agregar un nuevo pedido seleccionando un negocio y productos de diferentes categorías.

    - EliminarPedido()
      Permite eliminar un pedido seleccionado de la lista de pedidos.

    - ModificarPedido()
      Permite modificar un pedido existente, cambiando la cantidad de productos, eliminando productos o agregando nuevos productos.

    - VerOrdenesEntrega()
      Muestra la lista de órdenes de entrega generadas con sus detalles correspondientes.

    - RedimensionarArray(LineaPedido[] arrayOriginal, int nuevoTamaño)
      Redimensiona un array de líneas de pedido a un nuevo tamaño.

    - CambiarCantidadProducto(int indicePedido)
      Permite cambiar la cantidad de un producto en un pedido seleccionado.

    - EliminarProducto(int indicePedido)
      Permite eliminar un producto de un pedido seleccionado.

    - AgregarProductoAPedido(int indicePedido)
      Permite agregar un nuevo producto a un pedido seleccionado.

    - AceptarPedido(int indicePedido)
      Acepta un pedido y lo mueve a la lista de órdenes de entrega.
    */

    public class GestorPedidos
    {
        public PedidoPreventivo[] pedidos = new PedidoPreventivo[100];
        public int cantidadPedidos = 0;
        public PedidoPreventivo[] ordenesEntrega = new PedidoPreventivo[100];
        public int cantidadOrdenesEntrega = 0;

        public void VerPedidos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE PEDIDOS ===");
            for (int i = 0; i < cantidadPedidos; i++)
            {
                Console.WriteLine($"Pedido {i + 1} - En espera:");
                Console.WriteLine($" Negocio: {pedidos[i].Negocio.Nombre}");
                Console.WriteLine($" Ubicación: {pedidos[i].Negocio.Ubicacion}");
                Console.WriteLine($" Teléfono: {pedidos[i].Negocio.Telefono}");
                Console.WriteLine($" Email: {pedidos[i].Negocio.Email}");
                Console.WriteLine($" Fecha: {pedidos[i].FechaPedido}");
                Console.WriteLine(" Productos:");

                decimal totalPedido = 0;

                for (int j = 0; j < pedidos[i].LineasPedido.Length; j++)
                {
                    Console.WriteLine($"  - {pedidos[i].LineasPedido[j].Producto.Nombre}: {pedidos[i].LineasPedido[j].Cantidad} unidades - ${pedidos[i].LineasPedido[j].Producto.Precio * pedidos[i].LineasPedido[j].Cantidad}");
                    totalPedido += pedidos[i].LineasPedido[j].Producto.Precio * pedidos[i].LineasPedido[j].Cantidad;
                }

                Console.WriteLine($"\n  Total del pedido: ${totalPedido}");
                Console.WriteLine("------------------------");
            }
            Console.ReadKey();
        }
        public void AgregarPedido(Negocio[] negocios, Producto[] productos)
        {
            if (negocios == null || productos == null)
            {
                Console.WriteLine("Error: Los negocios o productos no están inicializados.");
                Console.ReadKey();
                return;
            }

            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=== AGREGAR PEDIDO ===");

                    Console.WriteLine("Seleccione un negocio :");
                    for (int i = 0; i < negocios.Length; i++)
                    {
                        if (negocios[i] != null)
                        {
                            Console.WriteLine($"\n {i + 1}.{negocios[i].Nombre} - {negocios[i].Ubicacion}, {negocios[i].Telefono}, {negocios[i].Email}\n");
                        }
                    }
                    Console.WriteLine("\n 0. Volver al menú principal\n");
                    Console.Write("Opción: ");

                    if (!int.TryParse(Console.ReadLine(), out int opcionNegocio))
                    {
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        continue;
                    }

                    Negocio negocio;

                    if (opcionNegocio >= 1 && opcionNegocio <= negocios.Length && negocios[opcionNegocio - 1] != null)
                    {
                        negocio = negocios[opcionNegocio - 1];

                        LineaPedido[] lineasPedido = new LineaPedido[10];
                        int cantidadProductosAgregados = 0;

                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine($"=== SELECCIONE LA CATEGORÍA DE PRODUCTO PARA {negocio.Nombre} ===");
                            Console.WriteLine("1. Equipamiento Deportivo");
                            Console.WriteLine("2. Ropa y Calzado Deportivo");
                            Console.WriteLine("3. Accesorios para Entrenamiento");
                            Console.WriteLine("4. Equipamiento para Deportes de Aventura");
                            Console.WriteLine("5. Nutrición y Suplementos");
                            Console.WriteLine("6. Tecnología y Dispositivos Deportivos");
                            Console.WriteLine("0. Finalizar pedido");
                            Console.Write("Opción: ");

                            if (!int.TryParse(Console.ReadLine(), out int opcionCategoria))
                            {
                                Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                                continue;
                            }

                            if (opcionCategoria == 0)
                            {
                                break;
                            }

                            if (opcionCategoria < 1 || opcionCategoria > 6)
                            {
                                Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                                continue;
                            }

                            Producto[] productosCategoria = Array.FindAll(productos, p =>
                            {
                                switch (opcionCategoria)
                                {
                                    case 1: return p is EquipamientoDeportivo;
                                    case 2: return p is RopaYCalzadoDeportivo;
                                    case 3: return p is AccesoriosParaEntrenamiento;
                                    case 4: return p is EquipamientoParaDeportesDeAventura;
                                    case 5: return p is NutricionYSuplementos;
                                    case 6: return p is TecnologiaYDispositivosDeportivos;
                                    default: return false;
                                }
                            });

                            Console.Clear();
                            Console.WriteLine("=== SELECCIONE EL PRODUCTO ===");
                            for (int i = 0; i < productosCategoria.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}. {productosCategoria[i].Nombre} - {productosCategoria[i].Categoria} - ${productosCategoria[i].Precio}");
                            }
                            Console.WriteLine("0. Volver");
                            Console.Write("Opción: ");

                            if (!int.TryParse(Console.ReadLine(), out int opcionProducto))
                            {
                                Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                                continue;
                            }

                            if (opcionProducto == 0)
                            {
                                continue;
                            }

                            if (opcionProducto >= 1 && opcionProducto <= productosCategoria.Length)
                            {
                                Producto productoSeleccionado = productosCategoria[opcionProducto - 1];

                                Console.Write("Cantidad: ");
                                if (!int.TryParse(Console.ReadLine(), out int cantidad))
                                {
                                    Console.WriteLine("Cantidad inválida. Presione cualquier tecla para continuar...");
                                    Console.ReadKey();
                                    continue;
                                }

                                if (productoSeleccionado.CantidadEnStock >= cantidad)
                                {
                                    if (cantidadProductosAgregados == lineasPedido.Length)
                                    {
                                        lineasPedido = RedimensionarArray(lineasPedido, lineasPedido.Length * 2);
                                    }

                                    lineasPedido[cantidadProductosAgregados] = new LineaPedido { Producto = productoSeleccionado, Cantidad = cantidad };
                                    cantidadProductosAgregados++;
                                    Console.WriteLine("Producto agregado. Presione cualquier tecla para continuar...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine($"No hay suficiente stock del producto. Cantidad disponible: {productoSeleccionado.CantidadEnStock}. Presione cualquier tecla para continuar...");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                            }
                        }

                        if (cantidadProductosAgregados == 0)
                        {
                            Console.WriteLine("No se puede crear un pedido sin productos. Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            continue;
                        }
                        Console.Write("Fecha del pedido (AAAAMMDD): ");
                        string fechaPedidoStr = Console.ReadLine(); // Leer la fecha como cadena

                        if (fechaPedidoStr.Length != 8 || !int.TryParse(fechaPedidoStr, out int fechaPedido))
                        {
                            Console.WriteLine("Fecha inválida. Debe ingresar 8 dígitos numéricos (AAAAMMDD). Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            continue;
                        }

                        LineaPedido[] lineasPedidoFinal = new LineaPedido[cantidadProductosAgregados];
                        Array.Copy(lineasPedido, lineasPedidoFinal, cantidadProductosAgregados);

                        pedidos[cantidadPedidos] = new PedidoPreventivo
                        {
                            Negocio = negocio,
                            LineasPedido = lineasPedidoFinal,
                            FechaPedido = fechaPedido
                        };

                        cantidadPedidos++;
                        Console.WriteLine("Pedido agregado correctamente. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    }
                    else if (opcionNegocio == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("El número de negocio ingresado no es válido. Presione cualquier tecla para reintentar...");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar pedido: {ex.Message}");
                Console.ReadKey();
            }
        }
        public void EliminarPedido()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR PEDIDO ===");
            if (cantidadPedidos == 0)
            {
                Console.WriteLine("No hay pedidos para eliminar.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < cantidadPedidos; i++)
            {
                Console.WriteLine($"{i + 1}. {pedidos[i].Negocio.Nombre} - Fecha: {pedidos[i].FechaPedido}");
            }
            Console.WriteLine("0. Volver"); // Opción para volver
            Console.Write("Seleccione el número de pedido a eliminar: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                if (opcion == 0) // Si se selecciona "0. Volver"
                {
                    return; // Regresar al menú principal
                }

                if (opcion >= 1 && opcion <= cantidadPedidos)
                {
                    // Desplazar los pedidos restantes una posición hacia atrás
                    for (int i = opcion - 1; i < cantidadPedidos - 1; i++)
                    {
                        pedidos[i] = pedidos[i + 1];
                    }

                    // Marcar el último pedido como nulo
                    pedidos[cantidadPedidos - 1] = null;
                    cantidadPedidos--;

                    Console.WriteLine("Pedido eliminado correctamente.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                Console.ReadKey();
            }
        }

        public void ModificarPedido()
        {
            if (cantidadPedidos == 0)
            {
                Console.WriteLine("No hay pedidos para modificar.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("=== MODIFICAR PEDIDO ===");
            Console.WriteLine("Seleccione el número de pedido que desea modificar:");

            for (int i = 0; i < cantidadPedidos; i++)
            {
                Console.WriteLine($"{i + 1}. Pedido para {pedidos[i].Negocio.Nombre}, Fecha: {pedidos[i].FechaPedido}");
            }

            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcionPedido))
            {
                if (opcionPedido == 0)
                {
                    return;
                }

                if (opcionPedido >= 1 && opcionPedido <= cantidadPedidos)
                {
                    int indicePedido = opcionPedido - 1;

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"=== MODIFICAR PEDIDO {opcionPedido} ===");
                        Console.WriteLine($"Negocio: {pedidos[indicePedido].Negocio.Nombre}, Fecha: {pedidos[indicePedido].FechaPedido}");
                        Console.WriteLine("Productos:");

                        for (int j = 0; j < pedidos[indicePedido].LineasPedido.Length; j++)
                        {
                            if (pedidos[indicePedido].LineasPedido[j] != null)
                            {
                                Console.WriteLine($"{j + 1}. {pedidos[indicePedido].LineasPedido[j].Producto.Nombre} - Cantidad: {pedidos[indicePedido].LineasPedido[j].Cantidad}");
                            }
                        }

                        Console.WriteLine("\nOpciones:");
                        Console.WriteLine("1. Cambiar cantidad de producto");
                        Console.WriteLine("2. Eliminar producto");
                        Console.WriteLine("3 Agregar producto ");
                        Console.WriteLine("4. Aceptar pedido");
                        Console.WriteLine("0. Volver al menú principal");
                        Console.Write("Opción: ");

                        if (!int.TryParse(Console.ReadLine(), out int opcion))
                        {
                            Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            continue;
                        }

                        switch (opcion)
                        {
                            case 1:
                                CambiarCantidadProducto(indicePedido);
                                break;
                            case 2:
                                EliminarProducto(indicePedido);
                                break;
                            case 3:
                                AgregarProductoAPedido(indicePedido);
                                break;
                            case 4:
                                AceptarPedido(indicePedido);
                                return;
                            case 0:
                                return;
                            default:
                                Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                Console.ReadKey();
            }
        }

        public void VerOrdenesEntrega()
        {
            Console.Clear();
            Console.WriteLine("=== ÓRDENES DE ENTREGA ===");
            for (int i = 0; i < cantidadOrdenesEntrega; i++)
            {
                Console.WriteLine($"Orden de entrega {i + 1}:");
                Console.WriteLine($" Negocio: {ordenesEntrega[i].Negocio.Nombre}");
                Console.WriteLine($" Fecha: {ordenesEntrega[i].FechaPedido}");
                Console.WriteLine(" Productos:");

                decimal totalPedido = 0;

                for (int j = 0; j < ordenesEntrega[i].LineasPedido.Length; j++)
                {
                    if (ordenesEntrega[i].LineasPedido[j] != null)
                    {
                        Console.WriteLine($"  - {ordenesEntrega[i].LineasPedido[j].Producto.Nombre}: {ordenesEntrega[i].LineasPedido[j].Cantidad} unidades - ${ordenesEntrega[i].LineasPedido[j].Producto.Precio * ordenesEntrega[i].LineasPedido[j].Cantidad}");
                        totalPedido += ordenesEntrega[i].LineasPedido[j].Producto.Precio * ordenesEntrega[i].LineasPedido[j].Cantidad;
                    }
                }

                Console.WriteLine($"\n  Total del pedido: ${totalPedido}");
                Console.WriteLine("------------------------");

            }
            Console.ReadKey();
        }

        public LineaPedido[] RedimensionarArray(LineaPedido[] arrayOriginal, int nuevoTamaño)
        {
            LineaPedido[] nuevoArray = new LineaPedido[nuevoTamaño];
            Array.Copy(arrayOriginal, nuevoArray, Math.Min(arrayOriginal.Length, nuevoTamaño));
            return nuevoArray;
        }

        public void CambiarCantidadProducto(int indicePedido)
        {
            Console.Write("Seleccione el número de producto que desea modificar: ");
            if (int.TryParse(Console.ReadLine(), out int opcionProducto) && opcionProducto >= 1 && opcionProducto <= pedidos[indicePedido].LineasPedido.Length)
            {
                Console.Write("Nueva cantidad: ");
                if (int.TryParse(Console.ReadLine(), out int nuevaCantidad))
                {
                    // Verificar si hay suficiente stock
                    if (pedidos[indicePedido].LineasPedido[opcionProducto - 1].Producto.CantidadEnStock >= nuevaCantidad)
                    {
                        pedidos[indicePedido].LineasPedido[opcionProducto - 1].Cantidad = nuevaCantidad;
                        Console.WriteLine("Cantidad modificada correctamente.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"No hay suficiente stock. Cantidad disponible: {pedidos[indicePedido].LineasPedido[opcionProducto - 1].Producto.CantidadEnStock}.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Cantidad inválida.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                Console.ReadKey();
            }
        }

        public void EliminarProducto(int indicePedido)
        {
            Console.Write("Seleccione el número de producto que desea eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int opcionProducto) && opcionProducto >= 1 && opcionProducto <= pedidos[indicePedido].LineasPedido.Length)
            {
                // Desplazar los productos restantes una posición hacia atrás
                for (int i = opcionProducto - 1; i < pedidos[indicePedido].LineasPedido.Length - 1; i++)
                {
                    pedidos[indicePedido].LineasPedido[i] = pedidos[indicePedido].LineasPedido[i + 1];
                }

                // Marcar el último producto como nulo
                pedidos[indicePedido].LineasPedido[pedidos[indicePedido].LineasPedido.Length - 1] = null;

                Console.WriteLine("Producto eliminado correctamente.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                Console.ReadKey();
            }
        }

        public void AgregarProductoAPedido(int indicePedido)
        {
            if (pedidos[indicePedido].LineasPedido.Length == 0)
            {
                Console.WriteLine("No hay productos disponibles para agregar.");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== AGREGAR PRODUCTO A PEDIDO {indicePedido + 1} ===");
                Console.WriteLine($"Negocio: {pedidos[indicePedido].Negocio.Nombre}, Fecha: {pedidos[indicePedido].FechaPedido}");

                // Mostrar productos disponibles
                Console.WriteLine("\nProductos disponibles:");
                for (int i = 0; i < pedidos[indicePedido].LineasPedido.Length; i++)
                {
                    if (pedidos[indicePedido].LineasPedido[i] != null)
                    {
                        Console.WriteLine($"{i + 1}. {pedidos[indicePedido].LineasPedido[i].Producto.Nombre} - Cantidad en stock: {pedidos[indicePedido].LineasPedido[i].Producto.CantidadEnStock}");
                    }
                }
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione un producto: ");

                if (!int.TryParse(Console.ReadLine(), out int opcionProducto) || opcionProducto < 0 || opcionProducto > pedidos[indicePedido].LineasPedido.Length)
                {
                    Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                if (opcionProducto == 0)
                {
                    break;
                }

                var productoSeleccionado = pedidos[indicePedido].LineasPedido[opcionProducto - 1].Producto;

                Console.Write("Cantidad: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Cantidad inválida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                if (productoSeleccionado.CantidadEnStock >= cantidad)
                {
                    // Agregar producto al pedido
                    pedidos[indicePedido].LineasPedido = RedimensionarArray(pedidos[indicePedido].LineasPedido, pedidos[indicePedido].LineasPedido.Length + 1);
                    pedidos[indicePedido].LineasPedido[pedidos[indicePedido].LineasPedido.Length - 1] = new LineaPedido { Producto = productoSeleccionado, Cantidad = cantidad };
                    productoSeleccionado.CantidadEnStock -= cantidad;
                    Console.WriteLine("Producto agregado correctamente. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"No hay suficiente stock del producto. Cantidad disponible: {productoSeleccionado.CantidadEnStock}. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        public void AceptarPedido(int indicePedido)
        {
            Console.WriteLine("Pedido aceptado y enviado a órdenes de entrega.");

            // Mover el pedido a órdenes de entrega
            ordenesEntrega[cantidadOrdenesEntrega] = pedidos[indicePedido];
            cantidadOrdenesEntrega++;

            // Eliminar el pedido de la lista de pedidos pendientes
            for (int i = indicePedido; i < cantidadPedidos - 1; i++)
            {
                pedidos[i] = pedidos[i + 1];
            }
            pedidos[cantidadPedidos - 1] = null;
            cantidadPedidos--;

            Console.ReadKey();
        }
    }
}