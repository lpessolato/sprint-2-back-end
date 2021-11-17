using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_medical_group_webAPI.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Atendimentos = new HashSet<Atendimento>();
        }

        public short IdMedico { get; set; }
        public int? IdUsuario { get; set; }
        public byte? IdClinica { get; set; }
        public short? IdDepartamento { get; set; }
        public string NomeMedico { get; set; }
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Atendimento> Atendimentos { get; set; }
    }
}
