using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        List<AluguelDomain> ListarTodos();
        void Cadastrar(AluguelDomain novoAluguel);
        AluguelDomain BuscarporID(int idAluguel);
        void AtualizarporURL(int idAluguel, AluguelDomain aluguelAtualizado);
        void Deletar(int idAluguel);

    }
}
