using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IClienteRepository
    {
        List<ClienteDomain> ListarTodos();

        void Cadastar(ClienteDomain novoCliente);

        ClienteDomain BuscarporId(int idCliente);

        void AtualizarporURL(int idCliente, ClienteDomain clienteAtualizado);
        void Deletar(int idCliente);


    }
}
