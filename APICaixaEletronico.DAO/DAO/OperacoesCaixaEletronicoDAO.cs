using APICaixaEletronico.DAO.Interface;
using APICaixaEletronico.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APICaixaEletronico.DAO.DAO
{
   public class OperacoesCaixaEletronicoDAO : IOperacoesCaixaEletronicoDAO
    {
        private CommonDbContext _commonDbContext;
        private ICaixaEletronicoDAO _caixaEletronicoDAO;

        public OperacoesCaixaEletronicoDAO(CommonDbContext commonDbContext, ICaixaEletronicoDAO caixaEletronicoDAO)
        {
            this._commonDbContext = commonDbContext;
            this._caixaEletronicoDAO = caixaEletronicoDAO;
        }

        public decimal Saldo(long cpf)
        {
            decimal saldo = _commonDbContext.Contas.Where(x => x.CpfCliente == cpf).Select(x => x.SaldoConta).FirstOrDefault();

            return saldo;
        }

        public OperacaoDTO Sacar( ContaDTO conta, decimal valorSacar)
        {
            var caixaEletronico = _commonDbContext.Caixas.FirstOrDefault();

            var contaUsuario = _commonDbContext.Contas.Where(x => x.NumeroContaCli == conta.NumeroContaCli).FirstOrDefault();

            OperacaoDTO operacao = new OperacaoDTO();

            if (_caixaEletronicoDAO.ValidarSaque(valorSacar, contaUsuario, caixaEletronico))
            {
                
                    contaUsuario.SaldoConta -= valorSacar;
                    conta.SaldoConta = contaUsuario.SaldoConta;

                    _commonDbContext.Update(contaUsuario);
                    _commonDbContext.Update(caixaEletronico);
                    _commonDbContext.SaveChanges();

                    operacao.Conta = conta;
                    operacao.Realizada = true;

                    var notasParaSaque = _caixaEletronicoDAO.RetornarNotasNecessarias(valorSacar);

                    caixaEletronico.NotasCem -= notasParaSaque[0];
                    caixaEletronico.NotasCinquenta -= notasParaSaque[1];
                    caixaEletronico.NotasVinte -= notasParaSaque[2];
                    caixaEletronico.NotasCem -= notasParaSaque[3];
                    caixaEletronico.Valor_Disponivel -= valorSacar;

                    contaUsuario.SaldoConta -= valorSacar;
                    conta.SaldoConta = contaUsuario.SaldoConta;

                    _commonDbContext.Update(contaUsuario);
                    _commonDbContext.Update(caixaEletronico);
                    _commonDbContext.SaveChanges();

                    operacao.NotasUtilizadas = new int[4] { notasParaSaque[0], notasParaSaque[1], notasParaSaque[2], notasParaSaque[3] };
                    operacao.ValorSacado = valorSacar;
                    operacao.Conta = conta;
                    operacao.Realizada = true;

                    return operacao;
                
            }
            return operacao;
        }

        public bool Depositar(ContaDTO conta, decimal valorDepositar)
        {
            var contaUsario = _commonDbContext.Contas.Where(x => x.NumeroContaCli == conta.NumeroContaCli && x.CpfCliente == conta.CpfCli).FirstOrDefault();

            var caixaEletronico = _commonDbContext.Caixas.FirstOrDefault();

            
            caixaEletronico.Valor_Disponivel += valorDepositar;

            contaUsario.SaldoConta += valorDepositar;

            _commonDbContext.Update(contaUsario);
            _commonDbContext.Update(caixaEletronico);

            _commonDbContext.SaveChanges();

            return true;
        }
    }
}
