using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Filmes2_webAPI.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Informe o email" )]
        public string email { get; set; }

        [Required(ErrorMessage ="informe a senha")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no minimo 3 caracteres e no maximo 10")]
        public string senha { get; set; }
        public string permissao { get; set; }

    }
}
