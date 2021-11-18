using Sp_medical_group_webAPI.Contexts;
using Sp_medical_group_webAPI.Domains;
using Sp_medical_group_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sp_medical_group_webAPI.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        MedicalContext ctx = new MedicalContext();
        public void Atualizar(int idPaciente, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(idPaciente);

            if (pacienteAtualizado.NomePaciente != null)
            {
                pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;

                ctx.Pacientes.Update(pacienteBuscado);
                ctx.SaveChanges();
            }

        }

        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(e => e.IdPaciente == idPaciente);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);
            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            ctx.Pacientes.Remove(BuscarPorId(idPaciente));

            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
