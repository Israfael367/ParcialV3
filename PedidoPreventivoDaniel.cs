using System;
using proyecto2.modelos;
using proyecto2.datos;

namespace proyecto2.modelos
{
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
                    Negocio = Negocio.ObtenerNegociosPredefinidos()[0],
                    LineasPedido = new LineaPedido[]
                    {
                        new LineaPedido { Producto = new EquipamientoDeportivo("Pelotas (fútbol, baloncesto, voleibol)", "Pelotas para diversos deportes ", 1, 100), Cantidad = 5 },
                        new LineaPedido { Producto = new RopaYCalzadoDeportivo("Zapatillas para running", "Zapatillas para correr", 4, 200), Cantidad = 10 }
                    },
                    FechaPedido = 20231027
                },
                new PedidoPreventivo
                {
                    Negocio = Negocio.ObtenerNegociosPredefinidos()[1],
                    LineasPedido = new LineaPedido[]
                    {
                        new LineaPedido { Producto = new NutricionYSuplementos("Barras de proteínas", "Barras con alto contenido de proteína", 5, 250), Cantidad = 20 },
                        new LineaPedido { Producto = new NutricionYSuplementos("Bebidas energéticas y rehidratantes", "Bebidas para reponer electrolitos", 5, 300), Cantidad = 30 }
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