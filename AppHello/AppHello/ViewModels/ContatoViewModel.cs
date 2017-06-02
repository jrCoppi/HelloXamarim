using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using AppHello.Models;
using AppHello.Helpers;
using AppHello.Views;

namespace AppHello.ViewModels
{
	class ContatoViewModel : BaseViewModel
	{
		// Declaração de um Command
		public ICommand CarregaDadosCommand => new Command(async () => await CarregaDados());
		public ICommand AddContatoCommand => new Command(async () => await AddContato());

		public ContatoViewModel(){}

		//Declaração padrão de variaveis
		private List<ContatoModel> _contatos;
		public List<ContatoModel> Contatos
		{
			get { return _contatos; }
			set
			{
				_contatos = value;
				OnPropertyChanged("Contatos");
			}
		}

		//Direciona para a pagina de novo contato
		private async Task AddContato()
		{
			await NavigationHelper.Instance.GotoDetails(new NovoContatoView(new ContatoModel()));
		}

		//carrega os dados da API
		private async Task CarregaDados()
		{
			try
			{
				IsBusy = true;
				await APIHelper.Instance.Get();
				Contatos = JsonConvert.DeserializeObject<List<ContatoModel>>(APIHelper.Instance.Resposta);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
