using senai_Filmes2_webAPI.Domains;
using senai_Filmes2_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Filmes2_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-LC177KN\SQLEXPRESS; initial catalog=CATALOGO; User Id=sa; pwd=senai@132;";
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"   Select idUsuario, email, senha, permissao from USUARIOS
                                          Where email = @email
                                          and senha = @senha";
                
                using (SqlCommand cmd = new SqlCommand (querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                   SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(reader[0]),
                            email = Convert.ToString(reader[1]),
                            senha = Convert.ToString(reader[2]),
                            permissao = Convert.ToString(reader[3])
                        };
                        return usuarioBuscado;
                            
                    }
                    return null;

                }



            }
            
        }
    }
}
