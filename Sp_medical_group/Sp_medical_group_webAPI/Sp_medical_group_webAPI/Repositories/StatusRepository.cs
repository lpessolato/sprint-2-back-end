using Sp_medical_group_webAPI.Contexts;
using Sp_medical_group_webAPI.Domains;
using Sp_medical_group_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sp_medical_group_webAPI.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        MedicalContext ctx = new MedicalContext();
        public void Atualizar(int idStatus, Status statusAtualizado)
        {
            throw new NotImplementedException();
            /// Status statusBuscado = ctx.Statuses.Find(idStatus);

            /// if (statusAtualizado.NomeStatus != null)
            /// {
            ///statusBuscado.NomeStatus = statusAtualizado.NomeStatus;
            /// }
        }

        public Status BuscarPorId(int idStatus)
        {
            return ctx.Statuses.FirstOrDefault(e => e.IdStatus == idStatus);
        }

        public void Cadastrar(Status novoStatus)
        {
            ctx.Statuses.Add(novoStatus);

            ctx.SaveChanges();
        }

        public void Deletar(int idStatus)
        {
            throw new NotImplementedException();
        }

        public List<Status> Listar()
        {            
            return ctx.Statuses.ToList();
        }
    }
}
