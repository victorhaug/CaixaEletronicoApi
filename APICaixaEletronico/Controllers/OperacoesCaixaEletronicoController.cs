using APICaixaEletronico.DTO;
using APICaixaEletronico.DTO.DTO;
using APICaixaEletronico.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICaixaEletronico.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class OperacoesCaixaEletronicoController : Controller
    {
        private readonly IOperacoesCaixaEletronicoService _operacoesService;

        public OperacoesCaixaEletronicoController(IOperacoesCaixaEletronicoService operacoesService)
        {
            this._operacoesService = operacoesService;
        }


        [HttpPost]
        [Route("Sacar")]
        public ActionResult Sacar([FromBody]ContaDTO conta, decimal ValorSacar)
        {
            try
            {
                var result = _operacoesService.Sacar(conta, ValorSacar);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno()
                {
                    Codigo = 500,
                    Mensagem = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("Depositar")]
        public ActionResult Depositar([FromBody]ContaDTO conta, decimal valorDepositar)
        {
            try
            {
                var result = _operacoesService.Depositar(conta, valorDepositar);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno()
                {
                    Codigo = 500,
                    Mensagem = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("Saldo")]
        public ActionResult Saldo(long cpf)
        {
            try
            {
                var saldo = _operacoesService.Saldo(cpf);

                return Ok(saldo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno()
                {
                    Codigo = 500,
                    Data = null,
                    Mensagem = ex.Message
                });
            }
        }

    }
}
