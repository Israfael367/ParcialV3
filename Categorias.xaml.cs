using ClaseNetMaui.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace ClaseNetMaui.Views
{
    public partial class Categoria : ContentPage
    {
        public ObservableCollection<CategoriaViewModel> listaCategorias { get; set; }
        string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Categorias.json");

        public ICommand ToggleExpandCommand { get; }
        public ICommand EditarSubcategoriaCommand { get; }

        public Categoria()
        {
            InitializeComponent();
            listaCategorias = new ObservableCollection<CategoriaViewModel>();
            ToggleExpandCommand = new Command<CategoriaViewModel>(ToggleExpandCategoria);
            EditarSubcategoriaCommand = new Command<ClaseNetMaui.Models.Categoria>(EditarSubcategoria);
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarCategoriasDesdeArchivoAsync();
        }

        private async Task CargarCategoriasDesdeArchivoAsync()
        {
            if (File.Exists(rutaArchivo))
            {
                string json = await File.ReadAllTextAsync(rutaArchivo);
                var categorias = JsonSerializer.Deserialize<List<ClaseNetMaui.Models.Categoria>>(json) ?? new List<ClaseNetMaui.Models.Categoria>();
                listaCategorias.Clear();
                foreach (var cat in categorias)
                    listaCategorias.Add(new CategoriaViewModel(cat));
            }
        }

        private async Task GuardarCategoriasEnArchivoAsync()
        {
            // Guardar los modelos reales, no los ViewModels
            var modelos = listaCategorias.Select(vm => vm.Categoria).ToList();
            string json = JsonSerializer.Serialize(modelos);
            await File.WriteAllTextAsync(rutaArchivo, json);
        }

        // Botón para agregar categoría principal
        private async void BtnAddCategoria_Clicked(object sender, EventArgs e)
        {
            string nombre = await DisplayPromptAsync("Nueva Categoría", "Nombre de la categoría:");
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                var nuevaCat = new ClaseNetMaui.Models.Categoria(nombre);
                listaCategorias.Add(new CategoriaViewModel(nuevaCat));
                await GuardarCategoriasEnArchivoAsync();
            }
        }

        // Botón para agregar subcategoría (CommandParameter es el viewmodel de la cat principal)
        private async void BtnAddSubcategoria_Clicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is CategoriaViewModel catVM)
            {
                string subNombre = await DisplayPromptAsync("Nueva Subcategoría", "Nombre de la subcategoría:");
                if (!string.IsNullOrWhiteSpace(subNombre))
                {
                    var subcat = new ClaseNetMaui.Models.Categoria(subNombre);
                    catVM.Categoria.Subcategorias.Add(subcat);
                    catVM.RefreshSubcategorias();
                    await GuardarCategoriasEnArchivoAsync();
                }
            }
        }

        // Expande/colapsa la categoría (accordion)
        private void ToggleExpandCategoria(CategoriaViewModel cat)
        {
            cat.IsExpanded = !cat.IsExpanded;
        }

        // Edita subcategoría al tocar
        private async void EditarSubcategoria(ClaseNetMaui.Models.Categoria subcat)
        {
            string nuevoNombre = await DisplayPromptAsync("Editar Subcategoría", "Nuevo nombre:", initialValue: subcat.Nombre);
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                subcat.Nombre = nuevoNombre;
                await GuardarCategoriasEnArchivoAsync();
                // Forzar refresco de toda la vista
                foreach (var cat in listaCategorias)
                    cat.RefreshSubcategorias();
            }
        }
    }

    // ViewModel para manejar expand/collapse y refresco de subcategorías
    public class CategoriaViewModel : BindableObject
    {
        public ClaseNetMaui.Models.Categoria Categoria { get; }
        public ObservableCollection<ClaseNetMaui.Models.Categoria> Subcategorias { get; set; }
        private bool isExpanded;
        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                isExpanded = value;
                OnPropertyChanged();
            }
        }
        public string Nombre => Categoria.Nombre;

        public CategoriaViewModel(ClaseNetMaui.Models.Categoria cat)
        {
            Categoria = cat;
            Subcategorias = new ObservableCollection<ClaseNetMaui.Models.Categoria>(cat.Subcategorias);
        }

        // Llama esto tras agregar/modificar subcategoría
        public void RefreshSubcategorias()
        {
            Subcategorias.Clear();
            foreach (var sub in Categoria.Subcategorias)
                Subcategorias.Add(sub);
            OnPropertyChanged(nameof(Subcategorias));
        }
    }
}