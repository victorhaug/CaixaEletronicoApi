using System;
using System.Collections.Generic;
using System.Text;
using APICaixaEletronico.DTO;
using APICaixaEletronico.DTO.Context;
using APICaixaEletronico.DTO.DTO;

namespace APICaixaEletronico.DAO.Interface
{
    public interface ICaixaEletronicoDAO
    {
        int[] ConsultarNotasDisponiveis();

        int[] CalcularNotasNecessarias(int[] notasNecessarias);

        int[] RetornarNotasNecessarias(decimal ValorSacar);

        bool ValidarSaque(decimal valorSacar, ContaContext contaUsuario, CaixaEletronicoContext caixaEletronico);

        bool ValidarDeposito(ContaContext conta, decimal valorDepositar, string[] notasDepositadas);

        bool ValidarInformacoes(ContaDTO conta, ContaDTO contaDestino);

        bool Login(long cpf, int senha);

        ContaDTO ListarUsuario(long cpf, int senha);
    }
}
