﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APICaixaEletronico.DAO.Interface;
using APICaixaEletronico.DTO;
using APICaixaEletronico.DTO.Context;
using APICaixaEletronico.DTO.DTO;

namespace APICaixaEletronico.DAO.DAO
{
    public class CaixaEletronicoDAO : ICaixaEletronicoDAO
    {
        private CommonDbContext _commonDbContext;

        public CaixaEletronicoDAO(CommonDbContext commonDbContext)
        {
            this._commonDbContext = commonDbContext;
        }

        public int[] ConsultarNotasDisponiveis()
        {
            var caixaEletronico = _commonDbContext.Caixas.FirstOrDefault();

            int[] notasDisponíveis = new int[4] { caixaEletronico.NotasCem, caixaEletronico.NotasCinquenta, caixaEletronico.NotasVinte, caixaEletronico.NotasDez };

            return notasDisponíveis;
        }

        public int[] CalcularNotasNecessarias(int[] notasNecessarias)
        {
            int[] notasDisponives = this.ConsultarNotasDisponiveis();

            int[] notas = new int[4];

            for (int i = 0; i <= 3; i++)
            {
                if (notasDisponives[i] < notasNecessarias[i])
                {
                    int adicionarNota = 0;

                    notas[i] = notasDisponives[i];

                    if (i == 0) //R$100
                    {
                        adicionarNota = notasNecessarias[i] - notasDisponives[i];

                        notasNecessarias[1] += (2 * adicionarNota);
                    }
                    else if (i == 1) //R$50
                    {
                        adicionarNota = notasNecessarias[i] - notasDisponives[i];

                        notasNecessarias[2] += (2 * adicionarNota);
                        notasNecessarias[3] += (1 * adicionarNota);
                    }
                    else if (i == 2) //R$20
                    {
                        adicionarNota = notasNecessarias[i] - notasDisponives[i];

                        notasNecessarias[3] += (2 * adicionarNota);
                    }
                    else
                    {
                        throw new Exception("Valor para saque maior que o número de notas disponível em caixa.");
                    }
                }
                else
                {
                    notas[i] += notasNecessarias[i];
                }
            }
            return notas;
        }

        public int[] RetornarNotasNecessarias(decimal ValorSacar)
        {
            int[] notasAceitas = new int[] { 100, 50, 20, 10 };

            int[] notasUtilizadas = new int[4];

            for (int i = 0; i <= 4; i++)
            {
                decimal result = 0;

                if (ValorSacar == 0)
                {
                    notasUtilizadas = this.CalcularNotasNecessarias(notasUtilizadas);

                    return notasUtilizadas;
                }
                else
                {
                    result = ValorSacar / notasAceitas[i];

                    if (result % 1 != 0)
                    {
                        result = Math.Floor(result);
                    }

                    ValorSacar -= result * notasAceitas[i];

                    notasUtilizadas[i] = Convert.ToInt32(result);
                }
            }
            return notasUtilizadas;
        }

        public bool ValidarSaque(decimal valorSacar, ContaContext contaUsuario, CaixaEletronicoContext caixaEletronico)
        {
            if (contaUsuario.SaldoConta < valorSacar)
            {
                return false;
            }
            else if (valorSacar % 10 != 0)
            {
                return false;
            }
            else if (caixaEletronico.Valor_Disponivel < valorSacar)
            {
                throw new Exception("Valor para saque maior que o saldo disponível em caixa.");
            }
            return true;
        }

        public bool ValidarInformacoes(ContaDTO conta, ContaDTO contaDestino)
        {
            var contaUsario = _commonDbContext.Contas.Where(x => x.Banco == conta.BancoContaCli && x.Agencia == conta.AgenciaContaCli && x.NumeroContaCli == conta.NumeroContaCli).FirstOrDefault();

            var contaDestinataria = _commonDbContext.Contas.Where(x => x.Banco == contaDestino.BancoContaCli && x.Agencia == contaDestino.AgenciaContaCli && x.NumeroContaCli == contaDestino.NumeroContaCli).FirstOrDefault();

            if (contaUsario == null || contaDestinataria == null)
            {
                return false;
            }
            return true;
        }

        public bool Login(long cpf, int senha)
        {
            var contaUsario = _commonDbContext.Contas.Where(x => x.CpfCliente == cpf && x.SenhaConta == senha).FirstOrDefault();

            if (contaUsario == null)
            {
                return false;
            }
            return true;
        }

        public ContaDTO ListarUsuario(long cpf, int senha)
        {
            ContaDTO conta = new ContaDTO();

            if (this.Login(cpf, senha))
            {
                var contaUsario = _commonDbContext.Contas.Where(x => x.CpfCliente == cpf && x.SenhaConta == senha).FirstOrDefault();

                conta.AgenciaContaCli = contaUsario.Agencia;
                conta.BancoContaCli = contaUsario.Banco;
                conta.CpfCli = contaUsario.CpfCliente;
                conta.NumeroContaCli = contaUsario.NumeroContaCli;
                conta.SaldoConta = contaUsario.SaldoConta;

                return conta;
            }
            return conta;
        }

       
    }
}
