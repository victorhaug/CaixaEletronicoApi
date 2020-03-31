using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APICaixaEletronico.DTO.Context
{
    [Table("TBTIPOCONTA")]
    public class TipoContaContext
    {
        [Column("COD_TIPCONTA")]
        public int Codigo_TipoConta { get; set; }

        [Column("DESC_TIPCONTA")]
        public string Descricao_TipoConta { get; set; }
    }
}
