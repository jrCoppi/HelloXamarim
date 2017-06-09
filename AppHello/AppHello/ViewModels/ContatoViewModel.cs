using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using AppHello.Models;
using AppHello.Helpers;
using AppHello.Views;
using AppHello.Interfaces;
using SQLite;
using System.Linq;

namespace AppHello.ViewModels
{
	class ContatoViewModel : BaseViewModel
	{
		// Declaração de um Command
		public ICommand CarregaDadosCommand => new Command(async () => await CarregaDados());
		public ICommand AddContatoCommand => new Command(async () => await AddContato());
		public ICommand TesteCommand => new Command(async () => await Teste());
		private SQLiteConnection _connection;

		public ContatoViewModel(){
			_connection = DependencyService.Get<ISQLite>().GetConnection();
		}

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

				//Gravar no sqllite
				foreach (var contato in Contatos)
				{
					BancoHelper.Instance.InsertOrUpdate(contato);
				}
				
			}
			catch (Exception e)
			{
				Contatos = _connection.Table<ContatoModel>().OrderBy(c => c.Email).ToList();
			}
			finally
			{
				IsBusy = false;
			}
		}

		private async Task Teste()
		{
			var texto = DependencyService.Get<ITeste>().CarregarTexto();
			System.Diagnostics.Debug.WriteLine(texto);
		}
	}
}
