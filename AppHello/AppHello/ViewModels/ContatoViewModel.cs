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

namespace AppHello.ViewModels
{
	class ContatoViewModel : BaseViewModel
	{
		public ICommand CarregaDadosCommand => new Command(async () => await CarregaDados());

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

		private async Task CarregaDados()
		{
			var request = new HttpRequestMessage(HttpMethod.Get, "https://cursounimestre.azurewebsites.net/Tables/contato");
			request.Headers.Add("ZUMO-API-VERSION", "2.0.0");

			var httpClient = new HttpClient();
			var response = await httpClient.SendAsync(request);
			var json = await response.Content.ReadAsStringAsync();
			Contatos = JsonConvert.DeserializeObject<List<ContatoModel>>(json);
		}

		public ContatoViewModel()
		{

		}
	}
}
