using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APICaixaEletronico.DTO.Context
{
    [Table("TBAGENCIACONTA")]
    public class AgenciaContext
    {
        [Column("ID_AGENCIA")]
        public int Id_Agencia { get; set; }

        [Column("NOME")]
        public string Nome_Agencia { get; set; }
    }
}
