namespace ayepezS5.Views;
using ayepezS5.Models;
public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

	private void btnAgregar_Clicked(object sender, EventArgs e)
	{
		App._personRepo.AddNewPerson(txtName.Text);
		lblStatusMessage.Text = App._personRepo.StatusMessage;
		txtName.Text = string.Empty;
	}

	private void btnMostrar_Clicked(object sender, EventArgs e)
	{
		List<Persona> people = App._personRepo.GetAllPerson();
		cvPersonas.ItemsSource = people;
	}

	private async void btnEliminar_Clicked(object sender, EventArgs e)
	{
		Persona persona = (Persona)((Button)sender).BindingContext;
		bool confirmado = await DisplayAlertAsync("ELIMINAR", "¿Eliminar a " + persona.Name + "?", "Eliminar", "Cancelar");
		if (!confirmado)
			return;
		App._personRepo.DeletePerson(persona.Id);
		lblStatusMessage.Text = App._personRepo.StatusMessage;
		cvPersonas.ItemsSource = App._personRepo.GetAllPerson();
	}

	private async void btnActualizar_Clicked(object sender, EventArgs e)
	{
		Persona persona = (Persona)((Button)sender).BindingContext;
		string nombre = await DisplayPromptAsync("ACTUALIZAR", "Nuevo nombre del registro " + persona.Id, "Guardar", "Cancelar", maxLength: 25, initialValue: persona.Name);
		if (nombre is null)
			return;
		App._personRepo.UpdatePerson(persona.Id, nombre);
		lblStatusMessage.Text = App._personRepo.StatusMessage;
		cvPersonas.ItemsSource = App._personRepo.GetAllPerson();
	}
}
