using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppHello.Helpers
{
	class APIHelper
	{
		private static APIHelper _instance;
		public static APIHelper Instance => _instance ?? (_instance = new APIHelper());

		private string _url;
		public string Url
		{
			get { return _url; }
			set
			{
				_url = value;
			}
		}

		private APIHelper() {
			Url = "https://cursounimestre.azurewebsites.net/Tables/contato/";
		}

		public async Task Post(Object objetoEnviado)
		{
			await Send(HttpMethod.Post, objetoEnviado);
		}

		public async Task Patch(Object objetoEnviado)
		{
			await Send(new HttpMethod("PATCH"), objetoEnviado);
		}

		private async Task Send(HttpMethod metodo, Object objetoEnviado) {
			try
			{
				var httpClient = new HttpClient();
				var request = new HttpRequestMessage(metodo, Url);
				request.Headers.Add("ZUMO-API-VERSION", "2.0.0");
				request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				request.Content = new StringContent(
									JsonConvert.SerializeObject(objetoEnviado),
									Encoding.UTF8,
									"application/json"
								);

				HttpResponseMessage response = await httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();
			}
			catch (Exception e)
			{
				throw new Exception(e);
			}
		}


	}
}
