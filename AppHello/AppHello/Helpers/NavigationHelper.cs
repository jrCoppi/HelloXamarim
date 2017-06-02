using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppHello.ViewModels;
using Xamarin.Forms;

namespace AppHello.Helpers
{
	class NavigationHelper
	{
		private static NavigationHelper _instance;
		public static NavigationHelper Instance => _instance ?? (_instance = new NavigationHelper());

		private NavigationHelper() { }

		//Busca a main page
		private NavigationPage GetMainPage()
		{
			return Application.Current.MainPage as NavigationPage;
		}

		//Abre uma pagina sobre a atual
		public async Task GotoDetails(Page page)
		{
			await GetMainPage().PushAsync(page);
		}

		//Votla uma pagina
		public async Task GoBack()
		{
			await GetMainPage().PopAsync();
		}
	}
}
