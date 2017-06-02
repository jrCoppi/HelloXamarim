using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
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
			IsBusy = true;
			var request = new HttpRequestMessage(HttpMethod.Get, "https://cursounimestre.azurewebsites.net/Tables/contato");
			request.Headers.Add("ZUMO-API-VERSION", "2.0.0");

			var httpClient = new HttpClient();
			var response = await httpClient.SendAsync(request);
			var json = await response.Content.ReadAsStringAsync();
			Contatos = JsonConvert.DeserializeObject<List<ContatoModel>>(json);
			IsBusy = false;
		}
	}
}
