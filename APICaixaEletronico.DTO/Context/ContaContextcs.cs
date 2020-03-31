using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APICaixaEletronico.DTO.Context
{
    [Table("TBCONTASCLIENTES")]
    public class ContaContext
    {
        [Column("IDCONTA")]
        public int IdConta { get; set; }

        [Column("COD_TIPCONTA")]
        public int TipoConta { get; set; }

        [Column("SENHACONTA")]
        public int SenhaConta { get; set; }

        // criar tabela banco chave estrageira
        [Column("ID_BANCO")]
        public int Banco { get; set; }

        // criar tabela agencia chave estrangeira
        [Column("ID_AGENCIA")]
        public int Agencia { get; set; }

        [Column("NUMEROCONT")]
        public int NumeroContaCli { get; set; }

        [Column("SALDOCONT")]
        public decimal SaldoConta { get; set; }

        [Column("CPFCLIENTE")]
        public long CpfCliente { get; set; }
    }
}
