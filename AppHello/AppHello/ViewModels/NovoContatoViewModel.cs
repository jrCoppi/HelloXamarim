using AppHello.Helpers;
using AppHello.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppHello.ViewModels
{
	class NovoContatoViewModel : BaseViewModel
	{
		public ICommand SalvarContatoCommand => new Command(async () => await SalvarContato());

		public NovoContatoViewModel (ContatoModel novoContato)
		{
			_contato = novoContato;
		}

		private ContatoModel _contato;
		public ContatoModel Contato
		{
			get { return _contato; }
			set
			{
				_contato = value;
				OnPropertyChanged();
			}
		}

		private async Task SalvarContato()
		{
			this.IsBusy = true;
			string url = "https://cursounimestre.azurewebsites.net/Tables/contato";
			var httpClient = new HttpClient();
			HttpMethod metodo = HttpMethod.Post;

			if (Contato.Id != null)
			{
				metodo = HttpMethod.Put;
				//url = "https://cursounimestre.azurewebsites.net/Tables/contato/" + Contato.Id; 
			}


			var request = new HttpRequestMessage(metodo, url);
			request.Headers.Add("ZUMO-API-VERSION", "2.0.0");
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


			try
			{
				request.Content = new StringContent(
					JsonConvert.SerializeObject(Contato),
					Encoding.UTF8,
					"application/json"
				);


				HttpResponseMessage response = await httpClient.SendAsync(request);

				if (response.IsSuccessStatusCode == false)
					throw new Exception(response.ReasonPhrase);
			} catch (Exception e){
				throw new Exception(e.Message);
			}
			

			//string result = await response.Content.ReadAsStringAsync();
			//ContatoModel contato = JsonConvert.DeserializeObject<ContatoModel>(result);

			this.IsBusy = false;
			await NavigationHelper.Instance.GoBack();
		}
	}
}
