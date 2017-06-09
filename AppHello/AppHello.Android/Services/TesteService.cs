using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppHello.Interfaces;
using Xamarin.Forms;
using AppHello.Droid.Services;

[assembly: Dependency(typeof(TesteService))]
namespace AppHello.Droid.Services
{
	public class TesteService : ITeste
	{
		public string CarregarTexto()
		{
			return "this is Google masterrace!";
		}
	}
}