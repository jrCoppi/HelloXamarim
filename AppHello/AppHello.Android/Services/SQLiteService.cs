using System;
using System.IO;
using AppHello.Interfaces;
using SQLite;
using Xamarin.Forms;
using AppHello.Droid.Services;

[assembly: Dependency(typeof(SQLiteService))]
namespace AppHello.Droid.Services
{
	public class SQLiteService : ISQLite
	{
		public SQLiteConnection GetConnection()
		{
			String databasename = "treinamento.db";

			string diretorio = Environment.GetFolderPath(
				Environment.SpecialFolder.Personal
			);

			string arquivoBanco = Path.Combine(diretorio, databasename);

			return new SQLiteConnection(arquivoBanco);
		}
	}
}