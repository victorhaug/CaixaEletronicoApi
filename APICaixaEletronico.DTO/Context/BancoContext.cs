using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APICaixaEletronico.DTO.Context
{
    [Table("TBBANCO")]
    public class BancoContext
    {
        [Column("ID_BANCO")]
        public int Id_Banco { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }
    }
}
