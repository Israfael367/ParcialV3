using System.Collections.Generic;

namespace ClaseNetMaui.Models
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public Categoria Categoria { get; set; }
        public SortedDictionary<string, string> PropiedadesEspecificas { get; set; }

        public Producto()
        {
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
            this.Cantidad = 0;
            this.Precio = 0.0f;
            this.Categoria = new Categoria(); // Siempre inicializa con un objeto, nunca null ni string
            this.PropiedadesEspecificas = new SortedDictionary<string, string>();
        }
        public Producto(string nombre, string descripcion, int cantidad, float precio, Categoria categoria)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
            Categoria = categoria ?? new Categoria();
            PropiedadesEspecificas = new SortedDictionary<string, string>();
        }
        public string MostrarDetalles()
        {
            return $"Nombre: {Nombre}\nDescripción: {Descripcion}\nCantidad: {Cantidad}\nPrecio: {Precio}\nCategoría: {Categoria?.Nombre}";
        }
    }
}