using Sp_medical_group_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_medical_group_webAPI.Interfaces
{
    interface IStatusRepository
    {
        /// <summary>
        /// Lista todos os Status 
        /// </summary>
        /// <returns></returns> Lista de Status
        List<Status> Listar();

        Status BuscarPorId(int idStatus);

        void Cadastrar(Status novoStatus);

        void Atualizar(int idStatus, Status statusAtualizado);

        void Deletar(int idStatus);

        //List<Status> Listar
    }
}
