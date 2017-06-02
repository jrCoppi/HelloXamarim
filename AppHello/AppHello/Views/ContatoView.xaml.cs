using AppHello.Helpers;
using AppHello.Models;
using AppHello.ViewModels;
using Xamarin.Forms;

namespace AppHello.Views
{
	public partial class ContatoView : ContentPage
	{
		private ContatoViewModel _viewModel;

		public ContatoView()
		{
			InitializeComponent();

			_viewModel = new ContatoViewModel();
			BindingContext = _viewModel;
		}

		private async void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			//Busca o item atual da list pra passar pro editar
			(sender as ListView).SelectedItem = null;
			var contato = e.Item as ContatoModel;
			await NavigationHelper.Instance.GotoDetails(new NovoContatoView(contato));
		}

		//sobreescreve a propriedade da tela "ao aparecer" para recarregar a lista
		protected override void OnAppearing()
		{
			base.OnAppearing();
			//(BindingContext as ContatoViewModel).CarregaDadosCommand.Execute(null);
			_viewModel.CarregaDadosCommand.Execute(null);
		}
	}
}