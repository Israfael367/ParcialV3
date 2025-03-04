using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    public class Negocio
    {
        // Atributos
        private static int contadorId = 0; // Variable estática para autoincremento

        public int Id { get; set; }
        public string? Nombre { get; set; }  // operador ? indica que el atributo es nulleable
        public string? Ubicacion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public int contadorPedidos;  // Contador para llevar el seguimiento de los pedidos en el array
        public Pedido[] Pedidos { get; set; }  // Relación de COMPOSICIÓN: 
                                               // Un Negocio tiene una colección de Pedido
                                               // si se elimina el Negocio (el todo) se eliminan tambien los Pedidos
                                               // Nota: La composición es una relación fuerte donde la existencia 
                                               // de las instancias de la clase componente (en este caso, Pedido) depende 
                                               // de la instancia de la clase contenedora (en este caso, Negocio). 
                                               // Si la instancia de la clase contenedora se elimina, también se eliminan 
                                               // las instancias de la clase componente.


        // Constructores

        public Negocio()
        {
            Id = ++contadorId; // Asigna un nuevo id autoincremental
            Nombre = "";
            Ubicacion = "";
            Telefono = "";
            Email = "";
            // revsiar la linea siguiente
            Pedidos = new Pedido[100];  // Inicialización del array con la capacidad maxima del arreglo especificada
            contadorPedidos = 0;

            // Inicialización de cada posición del array
            for (int i = 0; i < Pedidos.Length; i++)
            {
                Pedidos[i] = new Pedido(0, 0, DateTime.Now);  // Inicializa cada posición con un nuevo Pedido vacío
            }
        }
        public Negocio(int id, string nombre, string ubicacion, string telefono, string email, int capacidadPedidos)
        {
            Id = ++contadorId; // Asigna un nuevo id autoincremental
            Nombre = nombre;
            Ubicacion = ubicacion;
            Telefono = telefono;
            Email = email;
            Pedidos = new Pedido[capacidadPedidos];  // Inicialización del array con la capacidad maxima del arreglo especificada
            contadorPedidos = 0;

            //Inicialización de cada posición del array
            for (int i = 0; i < Pedidos.Length; i++)
            {
                Pedidos[i] = new Pedido(0, 0, DateTime.Now);  // Inicializa cada posición con un nuevo Pedido vacío
            }
        }


        // Métodos
        /*public void RegistrarNegocio()
        {
            
        }


        public void ModificarNegocio()
        {
            // Lógica para modificar los datos de un negocio
        }

        public void EliminarNegocio()
        {
            // Lógica para eliminar un negocio
        }

        public void ListarNegocios()
        {
            // Lógica para listar todos los negocios
        }
        */
    }

}