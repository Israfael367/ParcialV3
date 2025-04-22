using System;

    namespace ConsoleApp1.Clases
    {
        /*
        TDA Producto

        -----------Descripción-----------

        El TDA (Tipo de Datos Abstracto) Producto representa un producto en un sistema de inventario. Este TDA permite crear, modificar y mostrar información de los productos. Además, define clases hijas para representar diferentes tipos de productos.

        -----------Atributos-----------

        - Id: Identificador único del producto. (Tipo: int)
        - Nombre: Nombre del producto. (Tipo: string)
        - Precio: Precio del producto. (Tipo: decimal)
        - CantidadEnStock: Cantidad disponible en stock del producto. (Tipo: int)
        - Categoria: Categoría del producto. (Tipo: string)

        -----------Métodos-----------

        - Producto(string nombre, decimal precio, int cantidadEnStock, string categoria)
          Constructor que inicializa un producto con los valores proporcionados y asigna un ID autoincremental.

        - Producto()
          Constructor por defecto que inicializa un producto con valores predeterminados y asigna un ID autoincremental.

        - MostrarInfo()
          Método virtual que muestra la información del producto.

        -----------Clases Hijas-----------

        - EquipamientoDeportivo
          Clase hija que representa equipamiento deportivo.

        - RopaYCalzadoDeportivo
          Clase hija que representa ropa y calzado deportivo.

        - AccesoriosParaEntrenamiento
          Clase hija que representa accesorios para entrenamiento.

        - EquipamientoParaDeportesDeAventura
          Clase hija que representa equipamiento para deportes de aventura.

        - NutricionYSuplementos
          Clase hija que representa nutrición y suplementos.

        - TecnologiaYDispositivosDeportivos
          Clase hija que representa tecnología y dispositivos deportivos.
        */

        public class Producto
        {
            private static int contadorId = 0; // Variable estática para autoincremento
                                               // Atributos
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int CantidadEnStock { get; set; }
            public string Categoria { get; set; }

            // Constructores
            public Producto(string nombre, decimal precio, int cantidadEnStock, string categoria)
            {
                Id = ++contadorId; // Asigna un nuevo id autoincremental
                Nombre = nombre;
                Precio = precio;
                CantidadEnStock = cantidadEnStock;
                Categoria = categoria;
            }

            public Producto()
            {
                Id = ++contadorId; // Asigna un nuevo id autoincremental
                Nombre = "";
                Precio = 0;
                CantidadEnStock = 0;
                Categoria = "";
            }

            // Métodos
            public virtual void MostrarInfo()
            {
                Console.WriteLine($"Id: {Id}, Producto: {Nombre}, Precio: {Precio}, Stock Disponible: {CantidadEnStock}, Categoría: {Categoria}");
            }
        }

        // Clases hijas
        public class EquipamientoDeportivo : Producto
        {
            public string Tipo { get; set; }

            public EquipamientoDeportivo(string nombre, decimal precio, int stockDisponible, string tipo)
                : base(nombre, precio, stockDisponible, "Equipamiento Deportivo")
            {
                Tipo = tipo;
            }

            public override void MostrarInfo()
            {
                base.MostrarInfo();
                Console.WriteLine($"Tipo de Equipamiento Deportivo: {Tipo}");
            }
        }

        public class RopaYCalzadoDeportivo : Producto
        {
            public string Talla { get; set; }

            public RopaYCalzadoDeportivo(string nombre, decimal precio, int stockDisponible, string talla)
                : base(nombre, precio, stockDisponible, "Ropa y Calzado Deportivo")
            {
                Talla = talla;
            }

            public override void MostrarInfo()
            {
                base.MostrarInfo();
                Console.WriteLine($"Talla: {Talla}");
            }
        }

        public class AccesoriosParaEntrenamiento : Producto
        {
            public string Material { get; set; }

            public AccesoriosParaEntrenamiento(string nombre, decimal precio, int stockDisponible, string material)
                : base(nombre, precio, stockDisponible, "Accesorios para Entrenamiento")
            {
                Material = material;
            }

            public override void MostrarInfo()
            {
                base.MostrarInfo();
                Console.WriteLine($"Material: {Material}");
            }
        }

        public class EquipamientoParaDeportesDeAventura : Producto
        {
            public string Uso { get; set; }

            public EquipamientoParaDeportesDeAventura(string nombre, decimal precio, int stockDisponible, string uso)
                : base(nombre, precio, stockDisponible, "Equipamiento para Deportes de Aventura")
            {
                Uso = uso;
            }

            public override void MostrarInfo()
            {
                base.MostrarInfo();
                Console.WriteLine($"Uso: {Uso}");
            }
        }

        public class NutricionYSuplementos : Producto
        {
            public string Ingredientes { get; set; }

            public NutricionYSuplementos(string nombre, decimal precio, int stockDisponible, string ingredientes)
                : base(nombre, precio, stockDisponible, "Nutrición y Suplementos")
            {
                Ingredientes = ingredientes;
            }

            public override void MostrarInfo()
            {
                base.MostrarInfo();
                Console.WriteLine($"Ingredientes: {Ingredientes}");
            }
        }

        public class TecnologiaYDispositivosDeportivos : Producto
        {
            public string Especificaciones { get; set; }

            public TecnologiaYDispositivosDeportivos(string nombre, decimal precio, int stockDisponible, string especificaciones)
                : base(nombre, precio, stockDisponible, "Tecnología y Dispositivos Deportivos")
            {
                Especificaciones = especificaciones;
            }
            public override void MostrarInfo()
            {
                base.MostrarInfo();
                Console.WriteLine($"Especificaciones: {Especificaciones}");
            }
        }
    }