using System;
using System.Collections.Generic;
using System.Text;

namespace APICaixaEletronico.DTO.DTO
{
    public class ContaDTO
    {
        public int NumeroContaCli { get; set; }

        public decimal SaldoConta { get; set; }

        public long CpfCli { get; set; }
    }
}
