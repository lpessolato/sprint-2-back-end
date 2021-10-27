using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IMarcaRepository
    {
        List<MarcaDomain> ListarTodos();
        void Cadastar(MarcaDomain novaMarca);

        MarcaDomain BuscarporId(int idMarca);

        void AtualizarporURL(int idMarca, MarcaDomain marcaAtualizada);

        void Deletar(int idMarca);

    }
}
