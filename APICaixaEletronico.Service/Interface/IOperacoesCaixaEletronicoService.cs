using APICaixaEletronico.DTO;
using APICaixaEletronico.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICaixaEletronico.Service.Interface
{
    public interface IOperacoesCaixaEletronicoService
    {
        Retorno Saldo(long cpf);

        Retorno Sacar(ContaDTO conta, decimal valorSacar);

        Retorno Depositar(ContaDTO conta, decimal valorDepositar);
    }
}
