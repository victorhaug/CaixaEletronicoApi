using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APICaixaEletronico.DTO
{
    [Table("TBCAIXAELETRONICO")]
    public class CaixaEletronicoContext
    {
        [Column("ID_CAIXA")]
        public int Id_Terminal { get; set; }

        [Column("QTD_DISPONIVEL")]
        public decimal Valor_Disponivel { get; set; }

        [Column("NOTAS_CEM")]
        public int NotasCem { get; set; }

        [Column("NOTAS_CINQUENTA")]
        public int NotasCinquenta { get; set; }

        [Column("NOTAS_VINTE")]
        public int NotasVinte { get; set; }

        [Column("NOTAS_DEZ")]
        public int NotasDez { get; set; }
    }
}
