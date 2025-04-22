using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    /*
TDA GestionProductos

-----------Descripción-----------

El TDA (Tipo de Datos Abstracto) GestionProductos representa la gestión de productos en un sistema de inventario. Este TDA permite ver, ingresar, modificar y eliminar productos del stock, así como inicializar productos predefinidos.

-----------Métodos-----------

- Menu(Stock stockProductos)
  Muestra el menú de gestión de productos y maneja las opciones seleccionadas por el usuario.

- ObtenerProductosPredefinidos()
  Retorna un array de productos predefinidos para inicializar el stock si está vacío.

- OpIngresarProducto(Stock stockProductos)
  Permite ingresar un nuevo producto al stock solicitando la información necesaria al usuario.

- OpEliminarProducto(Stock stockProductos)
  Permite eliminar un producto del stock por su ID.

- OpModificarProducto(Stock stockProductos)
  Permite modificar un producto del stock solicitando la nueva información al usuario.
*/

    public static class GestionProductos
    {
        // Menu para la Gestion de PRODUCTOS
        public static void Menu(Stock stockProductos)
        {
            // Inicializar el arreglo de productos con los predefinidos si está vacío
            if (stockProductos.EstaVacio())
            {
                var productosPredefinidos = ObtenerProductosPredefinidos();
                stockProductos.IngresarProductosPredefinidos(productosPredefinidos);
            }

            bool submenuActivo = true;

            while (submenuActivo)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE PRODUCTOS ===");
                Console.WriteLine("1. Ver Productos (Inicializar Productos) ");
                Console.WriteLine("2. Ingresar Producto ");
                Console.WriteLine("3. Modificar Producto ");
                Console.WriteLine("4. Eliminar Producto ");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcionNumerica))
                {
                    switch (opcionNumerica)
                    {
                        case 1: // listar productos del Stock
                            Console.WriteLine("Lista de productos:");
                            stockProductos.mostrarStock();
                            Console.WriteLine("Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                        case 2: // ingresar productos al Stock
                            OpIngresarProducto(stockProductos);
                            break;
                        case 3: // modificar productos del Stock
                            OpModificarProducto(stockProductos);
                            break;
                        case 4: // eliminar productos del Stock
                            OpEliminarProducto(stockProductos);
                            break;
                        case 0: // retornar al Menu Principal de la app
                            submenuActivo = false;
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        // Método para obtener productos predefinidos
        public static Producto[] ObtenerProductosPredefinidos()
        {
            return new Producto[]
            {
                // Equipamiento Deportivo
                new EquipamientoDeportivo("Pelotas (fútbol, baloncesto, voleibol)", 100, 50, "Balones"),
                new EquipamientoDeportivo("Pesas y mancuernas", 150, 30, "Pesas"),
                new EquipamientoDeportivo("Bicicletas y accesorios", 300, 20, "Bicicletas"),

                // Ropa y Calzado Deportivo
                new RopaYCalzadoDeportivo("Zapatillas para running", 200, 100, "M"),
                new RopaYCalzadoDeportivo("Camisetas y shorts deportivos", 50, 200, "L"),
                new RopaYCalzadoDeportivo("Ropa térmica para entrenamiento", 80, 150, "XL"),

                // Accesorios para Entrenamiento
                new AccesoriosParaEntrenamiento("Bandas elásticas", 20, 300, "Goma"),
                new AccesoriosParaEntrenamiento("Guantes de gimnasio", 25, 100, "Cuero"),
                new AccesoriosParaEntrenamiento("Botellas de hidratación", 15, 200, "Plástico"),

                // Equipamiento para Deportes de Aventura
                new EquipamientoParaDeportesDeAventura("Cascos de escalada", 60, 50, "Escalada"),
                new EquipamientoParaDeportesDeAventura("Arneses y cuerdas", 70, 40, "Rappel"),
                new EquipamientoParaDeportesDeAventura("Tiendas de campaña y mochilas técnicas", 100, 30, "Camping"),

                // Nutrición y Suplementos
                new NutricionYSuplementos("Bebidas energéticas y rehidratantes", 5, 500, "Electrolitos"),
                new NutricionYSuplementos("Barras de proteínas", 10, 400, "Proteínas"),
                new NutricionYSuplementos("Vitaminas y suplementos deportivos", 15, 300, "Vitaminas"),

                // Tecnología y Dispositivos Deportivos
                new TecnologiaYDispositivosDeportivos("Relojes inteligentes", 200, 50, "GPS, Pulsómetro"),
                new TecnologiaYDispositivosDeportivos("Auriculares deportivos", 100, 100, "Resistentes al agua"),
                new TecnologiaYDispositivosDeportivos("Sensores de rendimiento", 150, 30, "Medición de rendimiento"),
                new TecnologiaYDispositivosDeportivos("Cámaras deportivas (tipo GoPro)", 300, 20, "Alta definición")
            };
        }

        // Método para ingresar productos al Stock
        private static void OpIngresarProducto(Stock stockProductos)
        {
            Console.Clear();
            Console.WriteLine("Ingresar nuevo producto:");

            // Recolectar información del nuevo producto
            string nombre;
            do
            {
                Console.Write("Nombre del producto: ");
                nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("Error: Ingrese un dato válido.");
                }
            } while (string.IsNullOrWhiteSpace(nombre));

            decimal precio;
            do
            {
                Console.Write("Precio del producto: ");
                if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                {
                    Console.WriteLine("Error: Ingrese un precio válido.");
                }
            } while (precio <= 0);

            int cantidadEnStock;
            do
            {
                Console.Write("Cantidad en stock: ");
                if (!int.TryParse(Console.ReadLine(), out cantidadEnStock) || cantidadEnStock < 0)
                {
                    Console.WriteLine("Error: Ingrese una cantidad en stock válida.");
                }
            } while (cantidadEnStock < 0);

            Console.WriteLine("Seleccione la categoría del producto:");
            Console.WriteLine("1. Equipamiento Deportivo");
            Console.WriteLine("2. Ropa y Calzado Deportivo");
            Console.WriteLine("3. Accesorios para Entrenamiento");
            Console.WriteLine("4. Equipamiento para Deportes de Aventura");
            Console.WriteLine("5. Nutrición y Suplementos");
            Console.WriteLine("6. Tecnología y Dispositivos Deportivos");

            int categoriaOpcion;
            do
            {
                Console.Write("Seleccione una opción: ");
                if (!int.TryParse(Console.ReadLine(), out categoriaOpcion) || categoriaOpcion < 1 || categoriaOpcion > 6)
                {
                    Console.WriteLine("Opción de categoría inválida. Intente de nuevo.");
                }
            } while (categoriaOpcion < 1 || categoriaOpcion > 6);

            Producto nuevoProducto = null;
            switch (categoriaOpcion)
            {
                case 1:
                    Console.Write("Tipo de equipamiento: ");
                    string tipo = Console.ReadLine();
                    nuevoProducto = new EquipamientoDeportivo(nombre, precio, cantidadEnStock, tipo);
                    break;
                case 2:
                    Console.Write("Talla: ");
                    string talla = Console.ReadLine();
                    nuevoProducto = new RopaYCalzadoDeportivo(nombre, precio, cantidadEnStock, talla);
                    break;
                case 3:
                    Console.Write("Material: ");
                    string material = Console.ReadLine();
                    nuevoProducto = new AccesoriosParaEntrenamiento(nombre, precio, cantidadEnStock, material);
                    break;
                case 4:
                    Console.Write("Uso: ");
                    string uso = Console.ReadLine();
                    nuevoProducto = new EquipamientoParaDeportesDeAventura(nombre, precio, cantidadEnStock, uso);
                    break;
                case 5:
                    Console.Write("Ingredientes: ");
                    string ingredientes = Console.ReadLine();
                    nuevoProducto = new NutricionYSuplementos(nombre, precio, cantidadEnStock, ingredientes);
                    break;
                case 6:
                    Console.Write("Especificaciones: ");
                    string especificaciones = Console.ReadLine();
                    nuevoProducto = new TecnologiaYDispositivosDeportivos(nombre, precio, cantidadEnStock, especificaciones);
                    break;
            }

            // Ingresar el nuevo producto al stock
            stockProductos.IngresarProducto(nuevoProducto);

            Console.WriteLine("Producto ingresado exitosamente.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Método para eliminar un producto por su ID en el Stock
        private static void OpEliminarProducto(Stock stockProductos)
        {
            if (!stockProductos.EstaVacio())
            {
                Console.WriteLine("Introduzca el id del producto a eliminar del Stock?");
                string texto = Console.ReadLine();
                int id_elim = int.Parse(texto);
                stockProductos.EliminarProducto(id_elim);
            }
            else
            {
                Console.WriteLine("Error: el Stock de Productos está vacío");
                Console.WriteLine("tecla para continuar...");
                Console.ReadKey();
            }
        }

        // Método para modificar productos del Stock
        private static void OpModificarProducto(Stock stockProductos)
        {
            Console.Clear();
            Console.WriteLine("Modificar un producto del Stock de productos:");

            if (!stockProductos.EstaVacio())
            {
                Console.WriteLine("Introduzca el id del producto a modificar en el Stock?");
                string texto = Console.ReadLine();
                int id_modif = int.Parse(texto);
                int index = stockProductos.BuscarProductoPorID(id_modif);
                if (index >= 0) // el producto existe en el Stock
                {
                    // Muestra datos actuales del producto a modificar
                    stockProductos.mostrarUnProductoDelStockPorIndex(index, true); // true: muestra encabezado de los atributos del Producto

                    // Recolectar información del producto para modificarlo
                    string nombre;
                    do
                    {
                        Console.Write("Nuevo Nombre del producto: ");
                        nombre = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nombre))
                        {
                            Console.WriteLine("Error: Ingrese un dato válido.");
                        }
                    } while (string.IsNullOrWhiteSpace(nombre));

                    decimal precio;
                    do
                    {
                        Console.Write("Nuevo Precio del producto: ");
                        if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                        {
                            Console.WriteLine("Error: Ingrese un precio válido.");
                        }
                    } while (precio <= 0);

                    int cantidadEnStock;
                    do
                    {
                        Console.Write("Nueva Cantidad en stock: ");
                        if (!int.TryParse(Console.ReadLine(), out cantidadEnStock) || cantidadEnStock < 0)
                        {
                            Console.WriteLine("Error: Ingrese una cantidad en stock válida.");
                        }
                    } while (cantidadEnStock < 0);

                    Console.WriteLine("Seleccione la nueva categoría del producto a modificar:");
                    Console.WriteLine("1. Equipamiento Deportivo");
                    Console.WriteLine("2. Ropa y Calzado Deportivo");
                    Console.WriteLine("3. Accesorios para Entrenamiento");
                    Console.WriteLine("4. Equipamiento para Deportes de Aventura");
                    Console.WriteLine("5. Nutrición y Suplementos");
                    Console.WriteLine("6. Tecnología y Dispositivos Deportivos");

                    int categoriaOpcion;
                    do
                    {
                        Console.Write("Seleccione una opción: ");
                        if (!int.TryParse(Console.ReadLine(), out categoriaOpcion) || categoriaOpcion < 1 || categoriaOpcion > 6)
                        {
                            Console.WriteLine("Opción de categoría inválida. Intente de nuevo.");
                        }
                    } while (categoriaOpcion < 1 || categoriaOpcion > 6);

                    Producto nuevoProducto = null;

                    switch (categoriaOpcion)
                    {
                        case 1:
                            Console.Write("Tipo de equipamiento: ");
                            string tipo = Console.ReadLine();
                            nuevoProducto = new EquipamientoDeportivo(nombre, precio, cantidadEnStock, tipo);
                            break;
                        case 2:
                            Console.Write("Talla: ");
                            string talla = Console.ReadLine();
                            nuevoProducto = new RopaYCalzadoDeportivo(nombre, precio, cantidadEnStock, talla);
                            break;
                        case 3:
                            Console.Write("Material: ");
                            string material = Console.ReadLine();
                            nuevoProducto = new AccesoriosParaEntrenamiento(nombre, precio, cantidadEnStock, material);
                            break;
                        case 4:
                            Console.Write("Uso: ");
                            string uso = Console.ReadLine();
                            nuevoProducto = new EquipamientoParaDeportesDeAventura(nombre, precio, cantidadEnStock, uso);
                            break;
                        case 5:
                            Console.Write("Ingredientes: ");
                            string ingredientes = Console.ReadLine();
                            nuevoProducto = new NutricionYSuplementos(nombre, precio, cantidadEnStock, ingredientes);
                            break;
                        case 6:
                            Console.Write("Especificaciones: ");
                            string especificaciones = Console.ReadLine();
                            nuevoProducto = new TecnologiaYDispositivosDeportivos(nombre, precio, cantidadEnStock, especificaciones);
                            break;
                    }
                    nuevoProducto.Id = id_modif; // id: unico atributo que no se modificará del Producto original
                    stockProductos.ModificarProductoIndex(index, nuevoProducto);
                    Console.WriteLine("Producto modificado exitosamente.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Error: el Producto id= {id_modif} no existe en el Stock");
                    Console.WriteLine("tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Error: el Stock de Productos está vacío");
                Console.WriteLine("tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}