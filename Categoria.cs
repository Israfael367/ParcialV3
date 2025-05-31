using System.Collections.Generic;

namespace ClaseNetMaui.Models
{
    public class Categoria
    {
        public string Nombre { get; set; }
        public List<string> Propiedades { get; set; }
        public List<Categoria> Subcategorias { get; set; }

        public Categoria()
        {
            Nombre = string.Empty;
            Propiedades = new List<string>();
            Subcategorias = new List<Categoria>();
        }

        public Categoria(string nombre)
        {
            Nombre = nombre;
            Propiedades = new List<string>();
            Subcategorias = new List<Categoria>();
        }

        public void AgregarPropiedad(string propiedad)
        {
            Propiedades.Add(propiedad);
        }

        public void AgregarSubcategoria(Categoria subcategoria)
        {
            Subcategorias.Add(subcategoria);
        }
    }
}