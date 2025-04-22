using System;
using ConsoleApp1.Clases;
using proyecto2.gestores;
using proyecto2.modelos;

namespace proyecto2.gestores
{

    /*
    TDA Factura

    -----------Descripción-----------

    El TDA (Tipo de Datos Abstracto) Factura representa la gestión de facturas en un sistema de facturación. Este TDA permite generar y visualizar facturas basadas en órdenes de entrega.

    -----------Atributos-----------

    - facturas: Array que almacena las facturas generadas. (Tipo: PedidoPreventivo[])
    - cantidadFacturas: Contador para llevar el seguimiento de las facturas almacenadas. (Tipo: int)

    -----------Métodos-----------

    - GenerarFactura(GestorPedidos gestorPedidos)
      Genera una nueva factura basada en una orden de entrega seleccionada del gestor de pedidos y la almacena en el array de facturas.

    - VerFacturas()
      Muestra la lista de facturas generadas con sus detalles correspondientes.
    */

    public class Factura
    {
        private PedidoPreventivo[] facturas = new PedidoPreventivo[100];
        private int cantidadFacturas = 0;

        public void GenerarFactura(GestorPedidos gestorPedidos)
        {
            if (gestorPedidos.cantidadOrdenesEntrega == 0)
            {
                Console.WriteLine("No hay órdenes de entrega disponibles.");
                Console.ReadKey();
                return;
            }

            gestorPedidos.VerOrdenesEntrega();
            Console.Write("Seleccione el número de orden de entrega para generar la factura: ");
            if (int.TryParse(Console.ReadLine(), out int numeroOrden) && numeroOrden >= 1 && numeroOrden <= gestorPedidos.cantidadOrdenesEntrega)
            {
                PedidoPreventivo ordenSeleccionada = gestorPedidos.ordenesEntrega[numeroOrden - 1];

                decimal totalPedido = 0;
                foreach (var linea in ordenSeleccionada.LineasPedido)
                {
                    totalPedido += linea.Producto.Precio * linea.Cantidad;
                }

                decimal iva = totalPedido * 0.16m;
                decimal totalConIva = totalPedido + iva;

                // Mostrar el detalle de la factura
                Console.WriteLine("\n--- FACTURA ---");
                foreach (var linea in ordenSeleccionada.LineasPedido)
                {
                    Console.WriteLine($"{linea.Producto.Nombre} x{linea.Cantidad}: {linea.Producto.Precio * linea.Cantidad:C}");
                }
                Console.WriteLine($"Subtotal: {totalPedido:C}");
                Console.WriteLine($"IVA (16%): {iva:C}");
                Console.WriteLine($"TOTAL A PAGAR: {totalConIva:C}\n");

                // Eliminar la orden de entrega del arreglo
                for (int i = numeroOrden - 1; i < gestorPedidos.cantidadOrdenesEntrega - 1; i++)
                {
                    gestorPedidos.ordenesEntrega[i] = gestorPedidos.ordenesEntrega[i + 1];
                }
                gestorPedidos.ordenesEntrega[gestorPedidos.cantidadOrdenesEntrega - 1] = null;
                gestorPedidos.cantidadOrdenesEntrega--;

                // Almacenar la orden en el arreglo de facturas
                facturas[cantidadFacturas] = ordenSeleccionada;
                cantidadFacturas++;

                Console.WriteLine("Factura generada y almacenada exitosamente. Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Número de orden inválido. Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void VerFacturas()
        {
            if (cantidadFacturas == 0)
            {
                Console.WriteLine("No hay facturas disponibles.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("=== LISTA DE FACTURAS ===");
            for (int i = 0; i < cantidadFacturas; i++)
            {
                Console.WriteLine($"Factura {i + 1}:");
                Console.WriteLine($" Negocio: {facturas[i].Negocio.Nombre}");
                Console.WriteLine($" Fecha: {facturas[i].FechaPedido}");
                Console.WriteLine(" Productos:");

                decimal totalPedido = 0;
                foreach (var linea in facturas[i].LineasPedido)
                {
                    Console.WriteLine($"  - {linea.Producto.Nombre}: {linea.Cantidad} unidades - ${linea.Producto.Precio * linea.Cantidad}");
                    totalPedido += linea.Producto.Precio * linea.Cantidad;
                }

                decimal iva = totalPedido * 0.16m;
                decimal totalConIva = totalPedido + iva;

                Console.WriteLine($"Subtotal: {totalPedido:C}");
                Console.WriteLine($"IVA (16%): {iva:C}");
                Console.WriteLine($"TOTAL A PAGAR: {totalConIva:C}\n");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}