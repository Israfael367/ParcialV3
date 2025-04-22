using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{

    /*
    TDA ProductoCantidad

    -----------Descripción-----------

    El TDA (Tipo de Datos Abstracto) ProductoCantidad representa la cantidad de un producto en un pedido. Este TDA permite asociar un producto con una cantidad específica, proporcionando funcionalidades para mostrar la información del producto con su cantidad y subtotal.

    -----------Atributos-----------

    - Producto: Producto asociado a la cantidad. (Tipo: Producto)
    - Cantidad: Cantidad del producto en el pedido. (Tipo: int)

    -----------Métodos-----------

    - ProductoCantidad(Producto producto, int cantidad)
      Constructor que inicializa un ProductoCantidad con los valores proporcionados.

    - MostrarInfo()
      Muestra la información del producto, incluyendo su cantidad y subtotal.
    */


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