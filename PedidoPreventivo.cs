using System;
using ConsoleApp1.Clases;

namespace proyecto2.modelos
{

    /*
    TDA PedidoPreventivo

    -----------Descripción-----------

    El TDA (Tipo de Datos Abstracto) PedidoPreventivo representa un pedido preventivo en un sistema de gestión de inventarios. Este TDA permite gestionar los pedidos preventivos, incluyendo la creación de pedidos predefinidos.

    -----------Atributos-----------

    - Negocio: Negocio asociado al pedido. (Tipo: Negocio)
    - LineasPedido: Array que contiene las líneas de pedido del pedido preventivo. (Tipo: LineaPedido[])
    - FechaPedido: Fecha en la que se realizó el pedido. (Tipo: int)

    -----------Métodos-----------

    - ObtenerPedidosPredefinidos()
      Retorna un array de pedidos predefinidos.

    -----------Clases Internas-----------

    - LineaPedido
      Clase interna que representa una línea de pedido dentro de un pedido preventivo.
      - Atributos:
        - Producto: Producto incluido en la línea de pedido. (Tipo: Producto)
        - Cantidad: Cantidad del producto en la línea de pedido. (Tipo: int)
    */

    public class PedidoPreventivo
    {
        public Negocio Negocio { get; set; }
        public LineaPedido[] LineasPedido { get; set; }
        public int FechaPedido { get; set; }

        public PedidoPreventivo[] ObtenerPedidosPredefinidos()
        {
            return new PedidoPreventivo[]
            {
                new PedidoPreventivo
                {
                    Negocio = GestionDeNegocios.ObtenerNegociosPredefinidos()[0],
                    LineasPedido = new LineaPedido[]
                    {
                        new LineaPedido { Producto = new EquipamientoDeportivo("Pelotas (fútbol, baloncesto, voleibol)", 100m, 50, "Balones"), Cantidad = 5 },
                        new LineaPedido { Producto = new RopaYCalzadoDeportivo("Zapatillas para running", 200m, 100, "M"), Cantidad = 10 }
                    },
                    FechaPedido = 20231027
                },
                new PedidoPreventivo
                {
                    Negocio = GestionDeNegocios.ObtenerNegociosPredefinidos()[1],
                    LineasPedido = new LineaPedido[]
                    {
                        new LineaPedido { Producto = new NutricionYSuplementos("Barras de proteínas", 10m, 400, "Proteínas"), Cantidad = 20 },
                        new LineaPedido { Producto = new NutricionYSuplementos("Bebidas energéticas y rehidratantes", 5m, 500, "Electrolitos"), Cantidad = 30 }
                    },
                    FechaPedido = 20231115
                }
            };
        }

        public class LineaPedido
        {
            public Producto Producto { get; set; }
            public int Cantidad { get; set; }
        }
    }
}