using APICaixaEletronico.DAO;
using APICaixaEletronico.DTO;
using APICaixaEletronico.DTO.Context;
using APICaixaEletronico.DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace APICaixaEletronico.Test
{
    [TestClass]
    public class UnitTest1
    {
        public DbContextOptions<CommonDbContext> CriarDataBaseTeste(string DataBaseTeste)
        {
            return new DbContextOptionsBuilder<CommonDbContext>().Options;
        }
        public ContaDTO Contas()
        {
            ContaDTO contas = new ContaDTO()
            {

                CpfCli = 39422492828,
                NumeroContaCli = 234,
                SaldoConta = 6000
            };

            return contas;
        }

        public ContaContext ListarContas()
        {
            ContaContext conta = new ContaContext()
            {
                Agencia = 234,
                Banco = 55,
                CpfCliente = 39422493838,
                IdConta = 001,
                NumeroContaCli = 23412213,
                SaldoConta = 3000,
                SenhaConta = 123,
                TipoConta = 01
            };
            return conta;
        }

        public ClienteContext ListarClientes()
        {
            ClienteContext conta = new ClienteContext()
            {
                CpfCli = 39422493838,
                Email = "vhag,aug@gmaillcom",
                Id_Cliente = 1,
                Nome_Cliente = "Victor",
                RgCli = 653634345,
                Telefone = 40028922
            };
            return conta;
        }

        public CaixaEletronicoContext ListarCaixas()
        {
            CaixaEletronicoContext caixa = new CaixaEletronicoContext()
            {
                Id_Terminal = 1,
                NotasCem = 100,
                NotasCinquenta = 100,
                NotasDez = 100,
                NotasVinte = 100,
                Valor_Disponivel = 18000
            };
            return caixa;
        }


       
    }
}
