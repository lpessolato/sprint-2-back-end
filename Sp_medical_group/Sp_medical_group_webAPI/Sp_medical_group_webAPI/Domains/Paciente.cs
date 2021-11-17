using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_medical_group_webAPI.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Atendimentos = new HashSet<Atendimento>();
        }

        public short IdPaciente { get; set; }
        public int? IdUsuario { get; set; }
        public string NomePaciente { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Atendimento> Atendimentos { get; set; }
    }
}
