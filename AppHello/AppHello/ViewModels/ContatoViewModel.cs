using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;

namespace AppHello.ViewModels
{
	class ContatoViewModel : BaseViewModel
	{
		public ICommand CarregaDadosCommand => new Command(async () => await CarregaDados());

		private async Task CarregaDados()
		{
			var request = new HttpRequestMessage(HttpMethod.Get, "https://cursounimestre.azurewebsites.net/Tables/contato");
			request.Headers.Add("ZUMO-API-VERSION", "2.0.0");

			var httpClient = new HttpClient();
			var response = await httpClient.SendAsync(request);
			var json = response.Content.ReadAsStringAsync();
			var teste = "";
		}

		public ContatoViewModel()
		{

		}
	}
}
