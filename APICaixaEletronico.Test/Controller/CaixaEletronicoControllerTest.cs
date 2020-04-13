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
    class CaixaEletronicoControllerTest
    {
        private CaixaEletronicoController controller;
        private Mock<ICaixaEletronicoService> mockService;
        private UnitTest1 teste;

        public CaixaEletronicoControllerTest()
        {
            mockService = new Mock<ICaixaEletronicoService>();
            controller = new CaixaEletronicoController(mockService.Object);
            teste = new UnitTest1();
        }

        [TestMethod]
        public void TestLogin()
        {
            mockService.Setup(x => x.Login(It.IsAny<long>(), It.IsAny<int>()))
                .Returns(new Retorno()
                {
                    Codigo = 200,
                    Data = JsonConvert.SerializeObject(true),
                    Mensagem = "Login efetuado com sucesso."
                });

            IActionResult result = controller.Login(teste.Contas().CpfCli, teste.ListarContas().SenhaConta);

            var okResult = result as OkObjectResult;

            Retorno contentResult = (Retorno)okResult.Value;

            Assert.AreEqual(contentResult.Codigo, 200);
            Assert.AreEqual(contentResult.Mensagem, "Login efetuado com sucesso.");
            Assert.IsNotNull(contentResult.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TesteLoginException()
        {
            mockService.Setup(x => x.Login(It.IsAny<long>(), It.IsAny<int>()))
                .Throws(new Exception("Internal server error"));

            IActionResult result = controller.Login(teste.Contas().CpfCli, teste.ListarContas().SenhaConta);

            var okResult = result as OkObjectResult;

            Retorno contentResult = (Retorno)okResult.Value;
        }

        [TestMethod]
        public void TesteListarUsuario()
        {
            ContaDTO conta = new ContaDTO();

            mockService.Setup(x => x.ListarUsuario(It.IsAny<long>(), It.IsAny<int>()))
                .Returns(new Retorno()
                {
                    Codigo = 200,
                    Data = JsonConvert.SerializeObject(conta),
                    Mensagem = "Consulta efetuada com sucesso."
                });

            IActionResult result = controller.ListarUsuario(It.IsAny<long>(), It.IsAny<int>());

            var okResult = result as OkObjectResult;

            Retorno contentResult = (Retorno)okResult.Value;

            Assert.AreEqual(contentResult.Codigo, 200);
            Assert.AreEqual(contentResult.Mensagem, "Consulta efetuada com sucesso.");
            Assert.IsNotNull(contentResult.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TesteListarUsuarioException()
        {
            mockService.Setup(x => x.ListarUsuario(It.IsAny<long>(), It.IsAny<int>()))
                .Throws(new Exception("Internal server error"));

            IActionResult result = controller.ListarUsuario(teste.Contas().CpfCli, 200);

            var okResult = result as OkObjectResult;

            Retorno contentResult = (Retorno)okResult.Value;
        }
    }
}
