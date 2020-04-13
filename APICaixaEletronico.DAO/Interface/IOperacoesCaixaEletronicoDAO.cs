using APICaixaEletronico.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICaixaEletronico.DAO.Interface
{
    public interface IOperacoesCaixaEletronicoDAO
    {
        decimal Saldo(long cpf);

        OperacaoDTO Sacar(ContaDTO conta, decimal valorSacar);

        bool Depositar(ContaDTO conta, decimal valorDepositar);

    }
}
