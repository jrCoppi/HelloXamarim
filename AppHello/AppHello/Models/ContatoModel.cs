using System;
using Newtonsoft.Json;

namespace AppHello.Models
{
	public class ContatoModel
	{
		[JsonProperty("nome")]
		public string Nome { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("data_nascimento")]
		public DateTime DataNascimento { get; set; }

		[JsonProperty("ativo")]
		public bool Ativo { get; set; }

		[JsonProperty("dia_vencimento_cartao")]
		public int DiaVencimentoCartao { get; set; }
	}
}
