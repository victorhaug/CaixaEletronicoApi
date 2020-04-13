using APICaixaEletronico.Controllers;
using APICaixaEletronico.DTO;
using APICaixaEletronico.DTO.DTO;
using APICaixaEletronico.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICaixaEletronico.Test.Controller
{
    [TestClass]
    class OperacoesCaixaEletronicoTest
    {
        private OperacoesCaixaEletronicoController controller;
        private Mock<IOperacoesCaixaEletronicoService> mockService;
        private UnitTest1 testes;

        public OperacoesCaixaEletronicoTest()
        {
            mockService = new Mock<IOperacoesCaixaEletronicoService>();
            controller = new OperacoesCaixaEletronicoController(mockService.Object);
            testes = new UnitTest1();
        }

        [TestMethod]
        public void Saldo()
        {
            decimal saldo = 800;

            mockService.Setup(x => x.Saldo(It.IsAny<long>()))
                .Returns(new Retorno()
                {
                    Codigo = 200,
                    Data = JsonConvert.SerializeObject(saldo),
                    Mensagem = "SUCESSO"
                });

            IActionResult result = controller.Saldo(testes.Contas().CpfCli);
            var okResult = result as OkObjectResult;

            Retorno contentResult = (Retorno)okResult.Value;

            Assert.AreEqual(contentResult.Codigo, 200);
            Assert.AreEqual(contentResult.Mensagem, "SUCESSO");
            Assert.IsNotNull(contentResult.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExceptionSaldo()
        {
            mockService.Setup(x => x.Saldo( It.IsAny<long>()))
                .Throws(new Exception("Internal server error"));

            IActionResult result = controller.Saldo(testes.Contas().CpfCli);
            var okResult = result as OkObjectResult;

            Retorno contentResult = (Retorno)okResult.Value;
        }

        [TestMethod]
        public void Sacar()
        {
            ContaDTO conta = new ContaDTO();
            OperacaoDTO operacao = new OperacaoDTO();
            decimal valorSacar = 50;

            mockService.Setup(x => x.Sacar(It.IsAny<ContaDTO>(), It.IsAny<decimal>()))
                .Returns(new Retorno()
                {
                    Codigo = 200,
                    Data = JsonConvert.SerializeObject(operacao),
                    Mensagem = "SAQUE REALIZADO COM SUCESSO."
                });

            IActionResult result = controller.Sacar(conta, valorSacar);
            var okResult = result as OkObjectResult;

            Retorno contentResult = (Retorno)okResult.Value;

            Assert.AreEqual(contentResult.Codigo, 200);
            Assert.AreEqual(contentResult.Mensagem, "SAQUE REALIZADO COM SUCESSO.");
            Assert.IsNotNull(contentResult.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExceptionSacar()
        {
            ContaDTO conta = new ContaDTO();
            decimal valorSacar = 30;

            mockService.Setup(x => x.Sacar(It.IsAny<ContaDTO>(), It.IsAny<decimal>()))
                .Throws(new Exception("Internal server error"));

            IActionResult result = controller.Sacar(conta, valorSacar);
            var okResult = result as OkObjectResult;

            Retorno contentResult = (Retorno)okResult.Value;
        }

        [TestMethod]
        public void Depositar()
        {
            ContaDTO conta = new ContaDTO();
            decimal valorDepositar = 20;
            

            mockService.Setup(x => x.Depositar(It.IsAny<ContaDTO>(), It.IsAny<decimal>()))
                .Returns(new Retorno()
                {
                    Codigo = 200,
                    Data = JsonConvert.SerializeObject(true),
                    Mensagem = "DEPOSITO REALIZADO COM SUCESSO"
                });

            IActionResult result = controller.Depositar(conta, valorDepositar);
            var okResult = result as OkObjectResult;

            Retorno contentResult = (Retorno)okResult.Value;

            Assert.AreEqual(contentResult.Codigo, 200);
            Assert.AreEqual(contentResult.Mensagem, "DEPOSITO REALIZADO COM SUCESSO");
            Assert.IsNotNull(contentResult.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExceptionDepositar()
        {
            ContaDTO conta = new ContaDTO();
            decimal valorDepositar = 200;
            

            mockService.Setup(x => x.Depositar(It.IsAny<ContaDTO>(), It.IsAny<decimal>()))
                .Throws(new Exception("Internal server error"));

            IActionResult result = controller.Depositar(conta, valorDepositar);
            var okResult = result as OkObjectResult;

            Retorno contentResult = (Retorno)okResult.Value;
        }
    }
}
