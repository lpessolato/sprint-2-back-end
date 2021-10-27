using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IModeloRepository
    {
        List<ModeloDomain> ListarTodos();

        void Cadastrar(ModeloDomain novoModelo);

        ModeloDomain BuscarporId(int idModelo);

        void AtualizarIdURL(int idModelo, ModeloDomain modeloAtualizado);

        void Deletar(int idModelo);

    }       
}
