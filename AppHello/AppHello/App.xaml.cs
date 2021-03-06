﻿using AppHello.Interfaces;
using AppHello.Models;
using AppHello.ViewModels;
using AppHello.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppHello
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			criaBanco();

			MainPage = new NavigationPage(new ContatoView());
		}

		private void criaBanco()
		{
			var connection = DependencyService.Get<ISQLite>().GetConnection();
			connection.CreateTable<ContatoModel>();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
