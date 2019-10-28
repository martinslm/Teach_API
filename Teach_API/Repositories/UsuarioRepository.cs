using System;
using System.Data.SqlClient;
using Teach_API.Models;
using Teach_API.Repositories.Interfaces;

namespace Teach_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlConnection _connection;

        public UsuarioRepository()
        {
            _connection = new TeachDbConnection().Create();
        }

        public int CadastrarUsuario(UsuarioModel usuario)
        {
            var sql = @"INSERT INTO usuario (
                                            email, 
                                            nome_usuario, 
                                            senha, 
                                            data_nascimento, 
                                            genero, 
                                            caminho_foto, 
                                            idioma_materno, 
                                            idioma_para_praticar, 
                                            idioma_fluente, 
                                            universidade, 
                                            area_estudo_geral_dominio, 
                                            area_estudo_especifico_dominio,
                                            area_estudo_geral_aprendizado, 
                                            area_estudo_especifico_aprendizado, 
                                            preferencia_conversa)
                                    VALUES (
                                            @email, 
                                            @nomeusuario, 
                                            @senha, 
                                            @datanascimento, 
                                            @genero, 
                                            @caminhofoto, 
                                            @idiomaMaterno, 
                                            @idiomaPraticar, 
                                            @idiomaFluente, 
                                            @universidade, 
                                            @areaestudogeraldominio, 
                                            @areaestudoespecificodominio, 
                                            @areaestudogeralaprendizado, 
                                            @areaestudoespecificoaprendizado, 
                                            @preferenciaconversa
                                            )

           SELECT IDENT_CURRENT('usuario') AS id_usuario";

            using (SqlConnection connection = _connection)
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", usuario.Email);
                    command.Parameters.AddWithValue("@nomeusuario", usuario.Nome);
                    command.Parameters.AddWithValue("@senha", usuario.Senha);
                    command.Parameters.AddWithValue("@datanascimento", usuario.DataNascimento);
                    command.Parameters.AddWithValue("@genero", (int)usuario.Genero);
                    command.Parameters.AddWithValue("@caminhofoto", usuario.CaminhoFoto);
                    command.Parameters.AddWithValue("@idiomaMaterno", usuario.IdIdiomaOrigem);
                    command.Parameters.AddWithValue("@idiomaPraticar", usuario.IdIdiomaAprendizado);
                    command.Parameters.AddWithValue("@idiomaFluente", usuario.IdIdiomaDominio);
                    command.Parameters.AddWithValue("@universidade", usuario.Universidade);
                    command.Parameters.AddWithValue("@areaestudogeraldominio", usuario.IdAreaEstudoGeralDominio);
                    command.Parameters.AddWithValue("@areaestudoespecificodominio", usuario.IdAreaEstudoEspecificoDominio);
                    command.Parameters.AddWithValue("@areaestudogeralaprendizado", usuario.IdAreaEstudoGeralAprendizado);
                    command.Parameters.AddWithValue("@areaestudoespecificoaprendizado", usuario.IdAreaEstudoEspecificoAprendizado);
                    command.Parameters.AddWithValue("@preferenciaconversa", (int)usuario.TipoIteracao);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? Convert.ToInt32(reader["id_usuario"]) : 0;
                    }
                }
            }
        }
        public int ValidarLogin(LoginModel loginModel)
        {
            var sql = @"SELECT id_usuario
                        FROM usuario
                        WHERE email = @email
                        AND senha = @senha";

            using (SqlConnection connection = _connection)
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", loginModel.Login);
                    command.Parameters.AddWithValue("@senha", loginModel.Senha);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? Convert.ToInt32(reader["id_usuario"]) : 0;
                    }
            }
        }
        }

        public bool ValidarContaExistente(string email)
        {
            var sql = @"SELECT id_usuario
                        FROM usuario
                        WHERE email = @email";

            using (SqlConnection connection = _connection)
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? true : false;
                    }
                }
            }
        }

        public UsuarioModel ObterDadosUsuario(int idUsuario)
        {
            return new UsuarioModel();
        }
        //criar método para obter os dados do usuário.
        //criar método para edição da conta. 
    }
}
