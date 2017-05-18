using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppHello.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AppHello.Views
{
	public partial class InicioView : ContentPage
	{
		public InicioView()
		{
			InitializeComponent();
			BindingContext = new InicioViewModel();
		}
	}
}