using AppHello.Helpers;
using AppHello.Models;
using AppHello.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
			(sender as ListView).SelectedItem = null;
			var contato = e.Item as ContatoModel;
			await NavigationHelper.Instance.GotoDetails(new NovoContatoView(contato));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//(BindingContext as ContatoViewModel).CarregaDadosCommand.Execute(null);
			_viewModel.CarregaDadosCommand.Execute(null);
		}
	}
}