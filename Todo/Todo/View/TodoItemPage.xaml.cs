using System;
using Xamarin.Forms;

namespace Todo
{
	public partial class TodoItemPage : ContentPage
	{
		public TodoItemPage()
		{
			InitializeComponent();
		}

		async void OnSalvarClicked(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
            todoItem.DataInclusao = DateTime.Now.Date;
			await App.Database.SalvarItemAsync(todoItem);
			await Navigation.PopAsync();
		}

		async void OnDeletarClicked(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.Database.DeletarItemAsync(todoItem);
			await Navigation.PopAsync();
		}

		async void OnCancelarClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
		
	}
}
