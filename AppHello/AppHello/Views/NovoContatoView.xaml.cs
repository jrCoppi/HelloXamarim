using AppHello.Models;
using AppHello.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHello.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovoContatoView : ContentPage
	{
		public NovoContatoView(ContatoModel contato)
		{
			InitializeComponent();
			BindingContext = new NovoContatoViewModel(contato);
		}
	}
}