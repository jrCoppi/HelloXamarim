using AppHello.Helpers;
using AppHello.Models;
using System;
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
			bool continuar = await Application.Current.MainPage.DisplayAlert("Apagar Contato", "Deseja apagar o contato?", "Sim", "Não");

			if (continuar == false)
				return;

			try
			{
				IsBusy = true;
				await APIHelper.Instance.Delete(Contato.Id);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			finally
			{
				IsBusy = false;
				await NavigationHelper.Instance.GoBack();
			}
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
