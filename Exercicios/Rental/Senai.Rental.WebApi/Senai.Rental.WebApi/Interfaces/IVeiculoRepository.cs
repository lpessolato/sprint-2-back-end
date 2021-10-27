using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculoRepository
    {
        List<VeiculoDomain> ListarTodos();
        void Cadastrar(VeiculoDomain novoVeiculo);

        VeiculoDomain BuscarporID(int idVeiculo);

        void AtualilzarporURL(int idVeiculo, VeiculoDomain veiculoAtualizado);
        void Deletar(int idVeiculo);


    }
}
