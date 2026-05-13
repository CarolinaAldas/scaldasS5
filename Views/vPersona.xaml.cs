using scaldasS5.Models;
using scaldasS5.Repositories;

namespace scaldasS5.Views;

public partial class vPersona : ContentPage
{
    private PersonRepository _repo;

    public vPersona()
    {
        InitializeComponent();
        _repo = new PersonRepository(
            Path.Combine(FileSystem.AppDataDirectory, "persona.db3")
        );
    }

    // Agregar 
    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        _repo.AddNewPerson(txtName.Text);
        DisplayAlert("Info", _repo.Status, "OK");
        txtName.Text = string.Empty;
    }

    // Listar
    private void btnListar_Clicked(object sender, EventArgs e)
    {
        CargarLista();
    }

    private void CargarLista()
    {
        listaPersonas.ItemsSource = _repo.GetAllPerson();
    }

    // Eliminar
    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button?.CommandParameter as Persona;

        if (persona == null) return;

        bool confirmar = await DisplayAlert(
            "Eliminar",
            $"¿Eliminar a {persona.Name}?",
            "Sí", "No");

        if (confirmar)
        {
            _repo.DeletePerson(persona);
            DisplayAlert("Info", _repo.Status, "OK");
            CargarLista();
        }
    }
}