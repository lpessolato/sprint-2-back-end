using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_medical_group_webAPI.Domains
{
    public partial class Atendimento
    {
        public int IdAtendimento { get; set; }
        public short? IdPaciente { get; set; }
        public short? IdMedico { get; set; }
        public byte? IdStatus { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; }
    }
}
