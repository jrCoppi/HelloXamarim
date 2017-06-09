using AppHello.Interfaces;
using AppHello.iOS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(TesteService))]
namespace AppHello.iOS.Services
{
	public class TesteService : ITeste
	{
		public string CarregarTexto()
		{
			return "this is apple";
		}
	}
}
