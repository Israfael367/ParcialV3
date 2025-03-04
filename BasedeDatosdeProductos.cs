using System;
using proyecto2.modelos;
using proyecto2.datos;


namespace proyecto2.datos
{
    //Clase donde se almacena la informacion de productos ya definidos
    public class BaseDeDatosProductos
    {
        public Producto[] Productos { get; set; }

        public BaseDeDatosProductos()
        {
            Productos = new Producto[]
            {
            // Equipamiento Deportivo
            new EquipamientoDeportivo("Pelotas (fútbol, baloncesto, voleibol)", "Pelotas para diversos deportes ",1, 100),
            new EquipamientoDeportivo("Pesas y mancuernas", "Pesas y mancuernas para entrenamiento",2, 50),
            new EquipamientoDeportivo("Bicicletas y accesorios", "Bicicletas y accesorios para ciclismo",3, 100),

            // Ropa y Calzado Deportivo
            new RopaYCalzadoDeportivo("Zapatillas para running", "Zapatillas para correr",4, 200),
            new RopaYCalzadoDeportivo("Camisetas y shorts deportivos", "Camisetas y shorts para deportes",5, 150),
            new RopaYCalzadoDeportivo("Ropa térmica para entrenamiento", "Ropa térmica para entrenar en frío",6, 80),

            // Accesorios para Entrenamiento
            new AccesoriosParaEntrenamiento("Bandas elásticas", "Bandas de resistencia para entrenamiento",7, 120),
            new AccesoriosParaEntrenamiento("Guantes de gimnasio", "Guantes para levantamiento de pesas",8, 90),
            new AccesoriosParaEntrenamiento("Botellas de hidratación", "Botellas para agua y bebidas deportivas",9, 200),

            // Equipamiento para Deportes de Aventura
            new EquipamientoParaDeportesDeAventura("Cascos de escalada", "Cascos de seguridad para escalar", 5, 60),
            new EquipamientoParaDeportesDeAventura("Arneses y cuerdas", "Arneses y cuerdas para escalada y rappel", 5, 70),
            new EquipamientoParaDeportesDeAventura("Tiendas de campaña y mochilas técnicas", "Tiendas y mochilas para camping y trekking", 5, 50),

            // Nutrición y Suplementos
            new NutricionYSuplementos("Bebidas energéticas y rehidratantes", "Bebidas para reponer electrolitos", 5, 300),
            new NutricionYSuplementos("Barras de proteínas", "Barras con alto contenido de proteína", 5, 250),
            new NutricionYSuplementos("Vitaminas y suplementos deportivos", "Vitaminas y suplementos para deportistas", 5, 400),

            // Tecnología y Dispositivos Deportivos
            new TecnologiaYDispositivosDeportivos("Relojes inteligentes", "Relojes con GPS y funciones deportivas",5, 100),
            new TecnologiaYDispositivosDeportivos("Auriculares deportivos", "Auriculares resistentes al sudor para deporte", 5, 150),
            new TecnologiaYDispositivosDeportivos("Sensores de rendimiento", "Sensores para medir rendimiento deportivo", 5, 80),
            new TecnologiaYDispositivosDeportivos("Cámaras deportivas (tipo GoPro)", "Cámaras de acción para deportes extremos", 5, 60)
            };
        }
    }
}
