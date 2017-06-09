using System;
using Newtonsoft.Json;
using SQLite;

namespace AppHello.Models
{
	[Table("tb_contato")]
	public class ContatoModel
	{
		[JsonProperty("id")]
		[Column("id"), PrimaryKey]
		public string Id { get; set; }

		[JsonProperty("nome")]
		[Column("ds_nome")]
		public string Nome { get; set; }

		[JsonProperty("email")]
		[Column("ds_email")]
		public string Email { get; set; }

		[JsonProperty("data_nascimento")]
		[Column("dt_nascimento")]
		public DateTime DataNascimento { get; set; }

		[JsonProperty("ativo")]
		[Column("sn_ativo")]
		public bool Ativo { get; set; }

		[JsonProperty("dia_vencimento_cartao")]
		[Column("nr_dia_vencimento")]
		public int DiaVencimentoCartao { get; set; }


	}
}
