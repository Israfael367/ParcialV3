using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    public class Pedido
    {
        // Atributos
        public int Id { get; set; }
        public int NegocioId { get; set; }
        public DateTime Fecha { get; set; }
        public ProductoCantidad[]? Productos { get; set; }  // operador ? hace el atributo nulleable
        public decimal Total { get; set; }

        // Constructor
        public Pedido(int id, int negocioId, DateTime fecha)
        {
            Id = id;
            NegocioId = negocioId;
            Fecha = fecha;
            Productos = new ProductoCantidad[0]; // Inicialización del arreglo con longitud 0
        }

        // Métodos
        public void RegistrarPedido()
        {
            // Lógica para registrar un pedido
        }

        public void ModificarPedido()
        {
            // Lógica para modificar un pedido
        }

        public void EliminarPedido()
        {
            // Lógica para eliminar un pedido
        }

        public void ListarPedidos()
        {
            // Lógica para listar todos los pedidos
        }
    }
}