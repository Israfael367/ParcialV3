using ClaseNetMaui.Models;
using System.Collections.ObjectModel;

namespace ClaseNetMaui.Views;

public partial class MainPage : ContentPage, IQueryAttributable
{
    ObservableCollection<Producto> listaProductos = new ObservableCollection<Producto>();
    Producto? product = null;
    Inventario inventario = new Inventario();

    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Inventario.CopiarJsonInicialSiNoExisteAsync();
        await LoadListAsync();
    }

    public async Task LoadListAsync()
    {
        try
        {
            listaProductos.Clear();

            // ⚡ Cargar productos desde el archivo local (persistencia)
            await inventario.CargarProductosDesdeArchivoAsync();

            // ⚡ Agregar productos cargados
            foreach (var producto in inventario.productos)
            {
                listaProductos.Add(producto);
            }

            // ⚡ Agregar un elemento de categoría como primera entrada si la lista está vacía
            if (!listaProductos.Any())
            {
                listaProductos.Insert(0, new Producto()
                {
                    Nombre = "Categoría Principal",
                    Descripcion = "Descripción de la categoría",
                    Categoria = new ClaseNetMaui.Models.Categoria("General")
                });
            }

            LV.ItemsSource = listaProductos;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Exception", $"{ex.Message}", "Ok");
        }
    }

    private void ESearch_Completed(object sender, EventArgs e)
    {
        string str = ESearch.Text;
        if (!string.IsNullOrEmpty(str))
        {
            LV.ItemsSource = new ObservableCollection<Producto>(
                listaProductos.Where(x =>
                    x.Nombre.Contains(str, StringComparison.OrdinalIgnoreCase) ||
                    x.Descripcion.Contains(str, StringComparison.OrdinalIgnoreCase) ||
                    (x.Categoria?.Nombre?.Contains(str, StringComparison.OrdinalIgnoreCase) ?? false)
                ));
        }
        else
        {
            LV.ItemsSource = listaProductos;
        }
    }

    private void LV_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Dictionary<string, object> parametros = new Dictionary<string, object>();
        Producto product = (Producto)e.Item;
        parametros.Add("product", product);
        AppShell.Current.GoToAsync(nameof(AddProductPage), parametros);
    }

    private void BtnAdd_Clicked(object sender, EventArgs e)
    {
        AppShell.Current.GoToAsync(nameof(AddProductPage));
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("product") && query["product"] is Producto _product)
        {
            product = _product;
        }
    }
}