using System;
using proyecto2.modelos;
using static proyecto2.modelos.PedidoPreventivo;
using ConsoleApp1.Clases;

namespace proyecto2.gestores
{
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
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=== AGREGAR PEDIDO ===");

                    Console.WriteLine("Seleccione un negocio :");
                    for (int i = 0; i < negocios.Length; i++)
                    {
                        Console.WriteLine($"\n {i + 1}.{negocios[i].Nombre} - {negocios[i].Ubicacion}, {negocios[i].Telefono}, {negocios[i].Email}\n");
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

                    if (opcionNegocio >= 1 && opcionNegocio <= negocios.Length)
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

        public LineaPedido[] RedimensionarArray(LineaPedido[] arrayOriginal, int nuevoTamaño)
        {
            LineaPedido[] nuevoArray = new LineaPedido[nuevoTamaño];
            Array.Copy(arrayOriginal, nuevoArray, Math.Min(arrayOriginal.Length, nuevoTamaño));
            return nuevoArray;
        }
        // Rest of the methods remain unchanged
    }
}