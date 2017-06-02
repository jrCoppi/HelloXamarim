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
		public ICommand ApagarDadosCommand => new Command(async () => await ApagarContato());

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

		//deleta os contatos da API
		private async Task ApagarContato()
		{
			if (string.IsNullOrEmpty(Contato.Id))
			{
				return;
			}

			bool continuar = await Application.Current.MainPage.DisplayAlert("Apagar Contato", "Deseja apagar o contato?","Sim","Não");

			if(continuar == false)
			{
				return;
			}

			IsBusy = true;

			string url = $"https://cursounimestre.azurewebsites.net/Tables/contato/{Contato.Id}";

			var request = new HttpRequestMessage(HttpMethod.Delete, url);
			request.Headers.Add("ZUMO-API-VERSION", "2.0.0");

			var httpClient = new HttpClient();
			var response = await httpClient.SendAsync(request);
			var json = await response.Content.ReadAsStringAsync();
			IsBusy = false;

			await NavigationHelper.Instance.GoBack();
		}

		//Edita ou Insere um contato
		//Método async pois tem operações await nele, por conta disso ele é um TREAD
		private async Task SalvarContato()
		{
			try
			{
				this.IsBusy = true;

				if (Contato.Id != null)
				{
					await APIHelper.Instance.Patch(Contato);
					return;
				}

				await APIHelper.Instance.Post(Contato);
			} catch (Exception e){
				throw new Exception(e.Message);
			}
			finally
			{
				this.IsBusy = false;
				await NavigationHelper.Instance.GoBack();
			}

		}
	}
}
