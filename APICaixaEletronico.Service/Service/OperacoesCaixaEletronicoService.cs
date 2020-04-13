using APICaixaEletronico.DAO.Interface;
using APICaixaEletronico.DTO;
using APICaixaEletronico.DTO.DTO;
using APICaixaEletronico.Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICaixaEletronico.Service.Service
{
    public class OperacoesCaixaEletronicoService : IOperacoesCaixaEletronicoService
    {
        private readonly IOperacoesCaixaEletronicoDAO _operacoesDao;

        public OperacoesCaixaEletronicoService(IOperacoesCaixaEletronicoDAO operacoesDao)
        {
            this._operacoesDao = operacoesDao;
        }

        public Retorno Saldo(long cpf)
        {
            try
            {
                var result = _operacoesDao.Saldo(cpf) ;
                    
                return new Retorno()
                {
                    Codigo = 200,
                    Data = JsonConvert.SerializeObject(result),
                    Mensagem = "Consulta efetuada com sucesso"
                };
            }

            catch (Exception ex)
            {
                return new Retorno()
                {
                    Codigo = 500,
                    Mensagem = "Erro ao realizar consultar do saldo: " + ex.Message
                };
            }
        }

        public Retorno Sacar(ContaDTO conta, decimal valorSacar)
        {
            try
            {
                var result = _operacoesDao.Sacar(conta, valorSacar);

                if (result.Realizada == false)
                {
                    return new Retorno()
                    {
                        Codigo = 500,
                        Mensagem = "Erro ao realizar operação, verifique o saldo e o valor digitado para saque."
                    };
                }

                return new Retorno()
                {
                    Codigo = 200,
                    Mensagem = "Saque realizado com sucesso.",
                    Data = JsonConvert.SerializeObject(result)
                };
            }
            catch (Exception ex)
            {
                return new Retorno()
                {
                    Codigo = 500,
                    Mensagem = "Erro ao realizar saque: " + ex.Message
                };
            }
        }

        public Retorno Depositar(ContaDTO conta, decimal valorDepositar)
        {
            try
            {
                var result = _operacoesDao.Depositar(conta, valorDepositar);

                if (result)
                {
                    return new Retorno()
                    {
                        Codigo = 200,
                        Mensagem = "Depósito realizado com sucesso.",
                        Data = JsonConvert.SerializeObject(result)
                    };
                }
                return new Retorno()
                {
                    Codigo = 500,
                    Mensagem = "O valor para depósito não pode ser zero e deve ser menor que o limite definido pelo banco de R$5.000,00."
                };
            }

            catch (Exception ex)
            {
                return new Retorno()
                {
                    Codigo = 500,
                    Mensagem = "Erro ao realizar depósito: " + ex.Message
                };
            }
        }
    }
}
