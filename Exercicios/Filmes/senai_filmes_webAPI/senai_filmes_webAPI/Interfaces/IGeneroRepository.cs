using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        //Estrutura dos métodos
        //tipoRetorno NomeMetodo (TipoParametro NomeParametro);
        //ex: GeneroDomain Cadastrar ();

        /// <summary>
        /// Listar todos os generos
        /// </summary>
        /// <returns>Uma lista de generos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um genero atravez do seu id
        /// </summary>
        /// <param name="idGenero">id do genero que sera buscado</param>
        /// <returns>Um genero buscado</returns>
        GeneroDomain BuscarPorId(int idGenero);

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com os dados do cadastro</param>
        void Cadastrar(GeneroDomain novoGenero);


        /// <summary>
        /// Atualiza um genero existente
        /// </summary>
        /// <param name="GeneroAtualizado">Novos dados atualizados</param>
        void AtualizarIdCorpo(GeneroDomain GeneroAtualizado);

        /// <summary>
        /// Atualiza um genero existente
        /// </summary>
        /// <param name="idGenero">id do genero que sera atalizado</param>
        /// <param name="GeneroAtualizado"></param>
        void AtualizarIdURL(int idGenero,GeneroDomain GeneroAtualizado);

        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="idGenero">id do Genero que sera deletado</param>
        void Deletar(int idGenero);
    }
}
