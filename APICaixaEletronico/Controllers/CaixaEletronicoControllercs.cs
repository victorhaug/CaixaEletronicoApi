﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICaixaEletronico.DTO;
using Microsoft.AspNetCore.Mvc;
using APICaixaEletronico.Service.Interface;


namespace APICaixaEletronico.Controllers
{
    [Route("api/[controller]")]
    public class CaixaEletronicoController : Controller
    {
        
        private readonly ICaixaEletronicoService _caixaEletronicoService;


        public CaixaEletronicoController(ICaixaEletronicoService caixaEletronicoService)
        {
            this._caixaEletronicoService = caixaEletronicoService;
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login(long cpf, int senha)
        {
            try
            {
                var result = _caixaEletronicoService.Login(cpf, senha);

                return Ok(result);
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

        [HttpGet]
        [Route("ListarUsuario")]
        public ActionResult ListarUsuario(long cpf, int senha)
        {
            try
            {
                var result = _caixaEletronicoService.ListarUsuario(cpf, senha);

                return Ok(result);
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
