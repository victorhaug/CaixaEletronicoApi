using System;
using System.Collections.Generic;
using System.Text;
using APICaixaEletronico.DTO;

namespace APICaixaEletronico.Service.Interface
{
    public interface ICaixaEletronicoService
    {
        Retorno Login(long cpf, int senha);

        Retorno ListarUsuario(long cpf, int senha);
        
    }
}
