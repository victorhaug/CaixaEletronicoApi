﻿using System;
using System.Collections.Generic;
using System.Text;

namespace APICaixaEletronico.DTO.DTO
{
    public class OperacaoDTO
    {
        public ContaDTO Conta { get; set; }

        public int[] NotasUtilizadas { get; set; }

        public decimal ValorSacado { get; set; }

        public bool Realizada { get; set; }
    }
}
