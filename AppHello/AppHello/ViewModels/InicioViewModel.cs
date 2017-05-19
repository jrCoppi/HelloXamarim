using AppHello.Helpers;
using AppHello.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppHello.ViewModels
{
	public class InicioViewModel : BaseViewModel
	{
		//Comando para ser chamado do binding
		public ICommand PaginaCommand => new Command(async () => await Pagina());
		public ICommand LimparCommand => new Command(async () => await Limpar());
		

		private async Task Pagina()
		{
			await NavigationHelper.Instance.GotoDetails(new SegundoView());
			return;
		}

		private async Task Limpar()
		{
			this.IsBusy = true;

			await Task.Delay(3000);
			this.Nome = "";
			this.IsBusy = false;
		}

		private String _nome;
		public String Nome
		{
			get { return _nome; }
			set
			{
				_nome = value;
				OnPropertyChanged();
			}
		}

		private String _hello;
		public String Hello
		{
			get { return _hello; }
			set
			{
				_hello = value;
				OnPropertyChanged();
			}
		}

		public InicioViewModel()
		{
			Hello = "Olá, seja bem vindo!";
		}

	}
}
