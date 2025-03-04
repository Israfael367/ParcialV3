using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    //CUANDO SE SOLICITA UN PEDIDO DE PRODUCTOS DEBE INDICARSE LA CANTIDAD DE CADA PRODUCTO
    // ES LA RAZON DE LA NECESIDAD DE CREAR ESTA CLASE ProductoCantidad
    public class ProductoCantidad
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public ProductoCantidad(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Producto: {Producto.Nombre}, Cantidad: {Cantidad}, Precio Unitario: {Producto.Precio}, Subtotal: {Producto.Precio * Cantidad}");
        }
    }
}