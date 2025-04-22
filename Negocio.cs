using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyecto2.modelos;

namespace ConsoleApp1.Clases
{
    /*
    TDA Negocio

    -----------Descripción-----------

    El TDA (Tipo de Datos Abstracto) Negocio representa un negocio en un sistema de gestión. Este TDA permite crear, modificar, eliminar y listar negocios. Además, permite gestionar los pedidos asociados al negocio mediante una relación de composición con la clase PedidoPreventivo.

    -----------Atributos-----------

    - Id: Identificador único del negocio. (Tipo: int)
    - Nombre: Nombre del negocio. (Tipo: string?)
    - Ubicacion: Ubicación del negocio. (Tipo: string?)
    - Telefono: Número de teléfono del negocio. (Tipo: string?)
    - Email: Dirección de correo electrónico del negocio. (Tipo: string?)
    - contadorPedidos: Contador para llevar el seguimiento de los pedidos en el array. (Tipo: int)
    - Pedidos: Array que almacena los pedidos asociados al negocio. (Tipo: PedidoPreventivo[])

    -----------Constructores-----------

    - Negocio()
    Constructor por defecto que inicializa un negocio con valores predeterminados y asigna un ID autoincremental.

    - Negocio(int id, string nombre, string ubicacion, string telefono, string email, int capacidadPedidos)
    Constructor que inicializa un negocio con los valores proporcionados y asigna un ID autoincremental. El array de pedidos se inicializa con la capacidad especificada.

    -----------Métodos-----------

    - Los métodos para gestionar los negocios y pedidos se pueden agregar según sea necesario.
    */

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
        public PedidoPreventivo[] Pedidos { get; set; }  // Relación de COMPOSICIÓN: 
                                                         // Un Negocio tiene una colección de PedidoPreventivo
                                                         // si se elimina el Negocio (el todo) se eliminan tambien los Pedidos
                                                         // Nota: La composición es una relación fuerte donde la existencia 
                                                         // de las instancias de la clase componente (en este caso, PedidoPreventivo) depende 
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
            Pedidos = new PedidoPreventivo[100];  // Inicialización del array con la capacidad maxima del arreglo especificada
            contadorPedidos = 0;

            // Inicialización de cada posición del array
            for (int i = 0; i < Pedidos.Length; i++)
            {
                Pedidos[i] = new PedidoPreventivo();  // Inicializa cada posición con un nuevo PedidoPreventivo vacío
            }
        }
        public Negocio(int id, string nombre, string ubicacion, string telefono, string email, int capacidadPedidos)
        {
            Id = ++contadorId; // Asigna un nuevo id autoincremental
            Nombre = nombre;
            Ubicacion = ubicacion;
            Telefono = telefono;
            Email = email;
            Pedidos = new PedidoPreventivo[capacidadPedidos];  // Inicialización del array con la capacidad maxima del arreglo especificada
            contadorPedidos = 0;

            //Inicialización de cada posición del array
            for (int i = 0; i < Pedidos.Length; i++)
            {
                Pedidos[i] = new PedidoPreventivo();  // Inicializa cada posición con un nuevo PedidoPreventivo vacío
            }
        }
    }
}