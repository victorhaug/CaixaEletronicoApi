﻿using System;
using System.Collections.Generic;
using System.Text;
using APICaixaEletronico.DTO;
using APICaixaEletronico.DAO.Interface;
using APICaixaEletronico.Service.Interface;
using Newtonsoft.Json;

namespace APICaixaEletronico.Service.Service
{
    public class CaixaEletronicoService : ICaixaEletronicoService
    {
        private readonly ICaixaEletronicoDAO _caixaEletronicoDao;

        public CaixaEletronicoService(ICaixaEletronicoDAO caixaEletronicoDao)
        {
            this._caixaEletronicoDao = caixaEletronicoDao;
        }

        public Retorno Login(long cpf, int senha)
        {
            try
            {
                var result = _caixaEletronicoDao.Login(cpf, senha);

                if (result)
                {
                    return new Retorno()
                    {
                        Codigo = 200,
                        Data = JsonConvert.SerializeObject(result),
                        Mensagem = "Login efetuado com sucesso."
                    };
                }
                else
                {
                    return new Retorno()
                    {
                        Codigo = 500,
                        Mensagem = "Erro ao realizar login, verifique as informações."
                    };
                }
            }

            catch (Exception ex)
            {
                return new Retorno()
                {
                    Codigo = 500,
                    Mensagem = "Erro ao realizar login, verifique as informações: " + ex.Message
                };
            }
        }

        public Retorno ListarUsuario(long cpf, int senha)
        {
            try
            {
                var result = _caixaEletronicoDao.ListarUsuario(cpf, senha);

                if (result.CpfCli == cpf && result.CpfCli != 0)
                {
                    return new Retorno()
                    {
                        Codigo = 200,
                        Data = JsonConvert.SerializeObject(result),
                        Mensagem = "Consulta efetuada com sucesso"
                    };
                }

                return new Retorno()
                {
                    Codigo = 500,
                    Mensagem = "Erro ao realizar consulta, verifique as informações."
                };
            }

            catch (Exception ex)
            {
                return new Retorno()
                {
                    Codigo = 500,
                    Mensagem = "Erro ao realizar consulta, verifique as informações: " + ex.Message
                };
            }
        }
    }
}
