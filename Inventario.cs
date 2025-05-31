using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ClaseNetMaui.Models;
using System.Linq;
using System;

public class Inventario
{
    public List<Producto> productos { get; private set; }
    public List<Categoria> categorias { get; private set; }

    public Inventario()
    {
        productos = new List<Producto>();
        categorias = new List<Categoria>();
    }

    // Ruta al archivo JSON en la carpeta de datos de la app
    public static string ObtenerRutaJson()
    {
        // Necesitas "using Microsoft.Maui.Storage;" en la parte superior
        return Path.Combine(FileSystem.AppDataDirectory, "Productos.json");
    }

    // Método para cargar productos desde el archivo JSON local
    public async Task CargarProductosDesdeArchivoAsync()
    {
        try
        {
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Productos.json");
            if (File.Exists(rutaArchivo))
            {
                string json = await File.ReadAllTextAsync(rutaArchivo);
                var lista = JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();

                // Parche: asegura que todos los productos tengan una categoría válida
                foreach (var p in lista)
                {
                    if (p.Categoria == null)
                    {
                        p.Categoria = new Categoria("Sin categoría");
                    }
                }
                productos = lista;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar productos: {ex.Message}");
            productos = new List<Producto>();
        }
    }

    public async Task CargarCategoriasDesdeArchivoAsync()
    {
        string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Categorias.json");
        if (File.Exists(rutaArchivo))
        {
            string json = await File.ReadAllTextAsync(rutaArchivo);
            categorias = JsonSerializer.Deserialize<List<Categoria>>(json) ?? new List<Categoria>();
        }
    }

    // Método para guardar productos en el archivo JSON local
    public async Task GuardarProductosEnArchivoAsync()
    {
        string rutaArchivo = ObtenerRutaJson();

        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            using FileStream fs = File.Create(rutaArchivo);
            await JsonSerializer.SerializeAsync(fs, productos, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar productos: {ex.Message}");
        }
    }

    // Ejemplo de método para agregar un producto y guardar
    public async Task AgregarProductoYGuardarAsync(Producto producto)
    {
        productos.Add(producto);
        await GuardarProductosEnArchivoAsync();

        // Actualizar categorías
        if (producto.Categoria != null && !categorias.Any(c => c.Nombre == producto.Categoria.Nombre))
        {
            categorias.Add(producto.Categoria);
        }
    }

    public static async Task CopiarJsonInicialSiNoExisteAsync()
    {
        var localPath = Path.Combine(FileSystem.AppDataDirectory, "Productos.json");
        if (!File.Exists(localPath))
        {
#if ANDROID
        using var stream = await FileSystem.OpenAppPackageFileAsync("Productos.json");
        using var outFile = File.Create(localPath);
        await stream.CopyToAsync(outFile);
#endif
            // Puedes agregar #elif para otras plataformas si tu app es multiplataforma
        }
    }

    // Ejemplo de método para eliminar un producto y guardar
    public async Task EliminarProductoYGuardarAsync(string nombre)
    {
        productos.RemoveAll(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        await GuardarProductosEnArchivoAsync();
    }
}