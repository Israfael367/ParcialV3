using ClaseNetMaui.Models;
using System.Collections.Generic;

namespace ClaseNetMaui.Views;

public partial class AddProductPage : ContentPage, IQueryAttributable
{
    Producto? product = null;
    Inventario inventario = new Inventario();

    List<Categoria> categoriasDisponibles = new();
    List<Categoria> subcategoriasDisponibles = new();

    public AddProductPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await inventario.CargarProductosDesdeArchivoAsync(); // Cargar productos si es necesario
        await inventario.CargarCategoriasDesdeArchivoAsync(); // Asegúrate de tener este método implementado

        // 1. Cargar categorías principales
        categoriasDisponibles = inventario.categorias;
        PCategoria.ItemsSource = categoriasDisponibles.Select(c => c.Nombre).ToList();

        // 2. Si es edición, selecciona la categoría y subcategoría correspondiente
        if (product != null)
        {
            LTitle.Text = "Modificar Producto";
            EName.Text = product.Nombre;
            EdNote.Text = product.Descripcion;

            if (product.Categoria != null)
            {
                var idx = categoriasDisponibles.FindIndex(x => x.Nombre == product.Categoria.Nombre);
                if (idx >= 0)
                {
                    PCategoria.SelectedIndex = idx;

                    // Cargar subcategorías de la categoría seleccionada
                    var categoria = categoriasDisponibles[idx];
                    subcategoriasDisponibles = categoria.Subcategorias;
                    PSubcategoria.ItemsSource = subcategoriasDisponibles.Select(s => s.Nombre).ToList();

                    // Seleccionar subcategoría si existe
                    if (product.Categoria != null && !string.IsNullOrEmpty(product.Categoria.Nombre))
                    {
                        int idxSub = subcategoriasDisponibles.FindIndex(s => s.Nombre == product.Categoria.Nombre);
                        if (idxSub >= 0)
                            PSubcategoria.SelectedIndex = idxSub;
                    }
                }
            }
        }
        else
        {
            LTitle.Text = "Agregar Producto";
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        product = null;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("product") && query["product"] is Producto _product)
        {
            product = _product;
        }
    }

    private void PCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Al cambiar la categoría, actualiza las subcategorías en el Picker
        if (PCategoria.SelectedIndex >= 0)
        {
            var categoria = categoriasDisponibles[PCategoria.SelectedIndex];
            subcategoriasDisponibles = categoria.Subcategorias ?? new List<Categoria>();
            PSubcategoria.ItemsSource = subcategoriasDisponibles.Select(s => s.Nombre).ToList();
            PSubcategoria.SelectedIndex = -1;
        }
        else
        {
            PSubcategoria.ItemsSource = null;
        }
    }

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
        int cantidad = 0;
        float precio = 0.0f;

        if (string.IsNullOrEmpty(EName.Text) || string.IsNullOrEmpty(EdNote.Text) || PCategoria.SelectedIndex < 0)
        {
            string msg = string.IsNullOrEmpty(EName.Text) ? $"- Nombre del Producto. {Environment.NewLine}" : "";
            msg += string.IsNullOrEmpty(EdNote.Text) ? $"- Nota del Producto. {Environment.NewLine}" : "";
            msg += (PCategoria.SelectedIndex < 0) ? $"- Categoría. {Environment.NewLine}" : "";
            await DisplayAlert("Advertencia", $"Falta llenar los campos: {Environment.NewLine} {msg}", "Ok");
        }
        else
        {
            bool respuesta = await DisplayAlert("Guardar Datos", "¿Estás seguro de guardar los datos?", "Sí", "No");
            if (respuesta)
            {
                var categoriaSeleccionada = categoriasDisponibles[PCategoria.SelectedIndex];
                Categoria? subcategoriaSeleccionada = null;

                if (PSubcategoria.SelectedIndex >= 0)
                {
                    subcategoriaSeleccionada = subcategoriasDisponibles[PSubcategoria.SelectedIndex];
                }

                // Si el usuario seleccionó subcategoría, será la asignada; si no, la principal
                Categoria categoriaProducto = subcategoriaSeleccionada ?? categoriaSeleccionada;

                var nuevoProducto = new Producto()
                {
                    Nombre = EName.Text,
                    Descripcion = EdNote.Text,
                    Cantidad = cantidad,
                    Precio = precio,
                    Categoria = categoriaProducto,
                    PropiedadesEspecificas = new SortedDictionary<string, string>()
                };

                if (product != null)
                {
                    var existente = inventario.productos.FirstOrDefault(p => p.Nombre == product.Nombre);
                    if (existente != null)
                    {
                        existente.Nombre = nuevoProducto.Nombre;
                        existente.Descripcion = nuevoProducto.Descripcion;
                        existente.Cantidad = nuevoProducto.Cantidad;
                        existente.Precio = nuevoProducto.Precio;
                        existente.Categoria = nuevoProducto.Categoria;
                        existente.PropiedadesEspecificas = nuevoProducto.PropiedadesEspecificas;
                    }
                }
                else
                {
                    inventario.productos.Add(nuevoProducto);
                }

                await inventario.GuardarProductosEnArchivoAsync();

                Dictionary<string, object> parametros = new();
                parametros["product"] = nuevoProducto;
                AppShell.Parameters = parametros;
                AppShell.Current.SendBackButtonPressed();
            }
        }
    }

    private async void BtnDelete_Clicked(object sender, EventArgs e)
    {
        if (product == null)
            return;

        bool respuesta = await DisplayAlert("Eliminar Productos", "¿Estás seguro de eliminar este producto?", "Si", "No");

        if (respuesta)
        {
            inventario.productos.RemoveAll(p => p.Nombre == product.Nombre);
            await inventario.GuardarProductosEnArchivoAsync();

            await DisplayAlert("Eliminar Producto", "Producto Eliminado", "Ok");
            Dictionary<string, object> parametros = new();
            parametros["product"] = product;
            AppShell.Parameters = parametros;
            AppShell.Current.SendBackButtonPressed();
        }
    }
}