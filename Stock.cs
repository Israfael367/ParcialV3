using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyecto2.modelos;


namespace ConsoleApp1.Clases
{

    public class Stock
    {
        // Atributos privados
        private int numProductos;
        private Producto?[] productos;

        const decimal IVA = 0.16m;

        // Constructor público
        public Stock()
        {
            numProductos = 0;
            productos = new Producto[100]; // Capacidad máxima de 100 productos
        }

        // Muestra la información de todos los productos en el stock, incluyendo los atributos específicos de sus subclases.
        public void mostrarUnProductoDelStockPorIndex(int i, bool mostrarEncabezado = false)
        {
            if (mostrarEncabezado)
            {        // mostrar Encabezado de la tabla
                Console.WriteLine("ID | Nombre | Precio | Cantidad en Stock | Categoría | Atributo Adicional");
                // Línea separadora
                Console.WriteLine(new string('-', 70));
            }

            if (productos[i] != null && productos[i].Id != 0) // Verifica que el producto esté inicializado y tenga un ID válido
            {
                string atributoAdicional = "";

                if (productos[i] is EquipamientoDeportivo ed)
                {
                    atributoAdicional = $"Tipo de Equipamiento Deportivo: {ed.Tipo}";
                }
                else if (productos[i] is RopaYCalzadoDeportivo rcd)
                {
                    atributoAdicional = $"Talla: {rcd.Talla}";
                }
                else if (productos[i] is AccesoriosParaEntrenamiento ae)
                {
                    atributoAdicional = $"Material: {ae.Material}";
                }
                else if (productos[i] is EquipamientoParaDeportesDeAventura eda)
                {
                    atributoAdicional = $"Uso: {eda.Uso}";
                }
                else if (productos[i] is NutricionYSuplementos ns)
                {
                    atributoAdicional = $"Ingredientes: {ns.Ingredientes}";
                }
                else if (productos[i] is TecnologiaYDispositivosDeportivos td)
                {
                    atributoAdicional = $"Especificaciones: {td.Especificaciones}";
                }

                // Mostrar la información del producto en formato de tabla
                Console.WriteLine($"{productos[i].Id} | {productos[i].Nombre} | {productos[i].Precio} | {productos[i].CantidadEnStock} | {productos[i].Categoria} | {atributoAdicional}");
            }

        }

        // muestra el Stock completo de Productos
        public void mostrarStock()
        {
            if (numProductos > 0)// hay productos que mostrar
            {
                // Encabezado de la tabla
                Console.WriteLine("ID | Nombre | Precio | Cantidad en Stock | Categoría | Atributo Adicional");
                // Línea separadora
                Console.WriteLine(new string('-', 70));

                for (int i = 0; i < numProductos; i++)
                {
                    mostrarUnProductoDelStockPorIndex(i);
                }
            }
            else
            {
                Console.WriteLine("No hay productos, el Stock está vacio!!.");
            }
            //Console.WriteLine("Presione cualquier tecla para continuar...");
            //Console.ReadKey();
        }

        // Método para ingresar un producto
        public void IngresarProducto(Producto p)
        {
            if (numProductos < productos.Length)
            {
                productos[numProductos] = p;
                numProductos++;
            }
            else
            {
                Console.WriteLine($"No se puede agregar un nuevo producto porque el arreglo alcanzó su capacidad máxima de {productos.Length}.");
            }
        }

        // Método que dado el id del producto el obj producto con los datos actualizados 
        // procede a almacenarlo en la ubicacion correspondiente
        public void ModificarProductoIndex(int index, Producto nuevoP)
        {
            productos[index] = new Producto(); // Reinicializar la  posición index
            productos[index] = nuevoP;
        }

        // Método para eliminar un producto por su ID
        public void EliminarProducto(int id)
        {
            if (numProductos > 0)
            {
                int index = BuscarProductoPorID(id);
                if (index >= 0)
                {
                    // Desplazar los productos para llenar el espacio del producto eliminado
                    for (int i = index; i < numProductos - 1; i++)
                    {
                        productos[i] = productos[i + 1];
                    }
                    productos[numProductos - 1] = new Producto(); // Reinicializar la última posición
                    numProductos--;
                    Console.WriteLine($"El producto con ID = {id} fue eliminado del Stock.");
                }
                else
                {
                    Console.WriteLine($"El producto con ID = {id} no existe en el Stock.");
                }
            }
            else
            {
                Console.WriteLine("No hay productos para eliminar.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Método para buscar un producto por su ID
        public int BuscarProductoPorID(int idProducto)
        {
            for (int i = 0; i < numProductos; i++)
            {
                if (productos[i].Id == idProducto)
                {
                    return i; // Retorna la posición del producto en el arreglo
                }
            }
            return -1; // Retorna -1 si no se encuentra el producto
        }

        public Producto ObtenerProductoPorID(int idProducto)
        {
            for (int i = 0; i < numProductos; i++)
            {
                if (productos[i].Id == idProducto)
                {
                    return productos[i]; // Retorna la posición del producto en el arreglo
                }
            }
            return null; // Retorna null si no se encuentra el producto
        }

        public bool EstaVacio()
        {  // Está vacio el Stock?
            if (numProductos == 0) // el Stock está vacío
            {
                return true;
            }
            return false; // no está vacio

        }

        public bool Estalleno()
        { // Está lleno el arreglo productos[] que almacena el Stock?
            if (numProductos == 100) // el Stock está lleno
            {
                return true;
            }
            return false; // no esta lleno

        }

        // Método para generar factura en base a un pedido
        public void GenerarFactura(PedidoPreventivo pedido)
        {
            if (pedido.LineasPedido == null || pedido.LineasPedido.Length == 0)
            {
                Console.WriteLine("El pedido no contiene productos.");
                return;
            }

            ProductoCantidad[] venta = new ProductoCantidad[pedido.LineasPedido.Length];
            int itemsVendidos = 0;
            decimal subtotal = 0;
            int totalItems = 0;

            foreach (var linea in pedido.LineasPedido)
            {
                Producto producto = ObtenerProductoPorID(linea.Producto.Id);
                if (producto != null)
                {
                    if (producto.CantidadEnStock >= linea.Cantidad)
                    {
                        producto.CantidadEnStock -= linea.Cantidad;
                        venta[itemsVendidos] = new ProductoCantidad(producto, linea.Cantidad);
                        itemsVendidos++;
                        subtotal += producto.Precio * linea.Cantidad;
                        totalItems += linea.Cantidad;
                    }
                    else
                    {
                        Console.WriteLine($"Stock insuficiente para el producto: {producto.Nombre}");
                    }
                }
                else
                {
                    Console.WriteLine($"Producto no encontrado: {linea.Producto.Nombre}");
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
    }
}