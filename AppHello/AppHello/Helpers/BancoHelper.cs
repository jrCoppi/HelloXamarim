using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using AppHello.Interfaces;

namespace AppHello.Helpers
{
	class BancoHelper
	{
		private static BancoHelper _instance;
		public static BancoHelper Instance => _instance ?? (_instance = new BancoHelper());

		private SQLiteConnection _connection;

		private BancoHelper()
		{
			_connection = DependencyService.Get<ISQLite>().GetConnection();
		}

		public void InsertOrUpdate(Object objeto)
		{
			_connection.InsertOrReplace(objeto);
		}

		public void Select(Object objeto)
		{
			//_connection.Table<objeto>().ToList();
		}
	}
}
