using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Enums;
using Teach_API.Models;
using Teach_API.Repositories.Interfaces;

namespace Teach_API.Repositories
{
    public class PesquisaRepository : IPesquisasRepository
    {
        private SqlConnection _connection;

        public PesquisaRepository()
        {
            ValidarConnection();
        }

        private void ValidarConnection()
        {
            if (_connection == null || string.IsNullOrEmpty(_connection.ConnectionString))
                _connection = new TeachDbConnection().Create();
        }

        public IList<UsuariosPesquisa> ObterUsuariosCombinacao(Usuario dadosUsuario)
        {
            var listagem = new List<UsuariosPesquisa>();

            var sql = @"SELECT u.id_usuario AS idUsuario
	                            ,u.caminho_foto AS caminhoFoto
	                            ,u.nome_usuario AS nomeUsuario
	                            ,u.email AS email
	                            ,u.senha AS senha
	                            ,u.genero AS genero
	                            ,u.data_nascimento AS dataNascimento
	                            ,u.preferencia_conversa AS preferenciaConversa
	                            ,un.id_universidade AS idUniversidade
	                            ,un.universidade AS universidade
	                            ,aed.id_area_estudo_especifico AS idEspecificaDominio
	                            ,aed.area_especifica_descricao AS descEspecificaDominio
	                            ,aea.id_area_estudo_especifico AS idEspecificaAprendizado
	                            ,aea.area_especifica_descricao AS descEspecificaAprendizado
	                            ,agd.id_area_geral AS idGeralDominio
	                            ,agd.area_geral_descricao AS descGeralDominio
	                            ,aga.id_area_geral AS idGeralAprendizado
	                            ,aga.area_geral_descricao AS descGeralAprendizado
	                            ,imat.id_idioma AS idIdiomaMaterno
	                            ,imat.idioma AS descIdiomaMaterno
	                            ,iflu.id_idioma AS idIdiomaFluente
	                            ,iflu.idioma AS descIdiomaFluente
	                            ,iprat.id_idioma AS idIdiomaAprender
	                            ,iprat.idioma AS descIdiomaAprender
                            FROM usuario u
                            INNER JOIN universidades un ON (u.universidade = un.id_universidade)
                            INNER JOIN area_estudo_especifico aed ON (aed.id_area_estudo_especifico = u.area_estudo_especifico_dominio)
                            INNER JOIN area_estudo_especifico aea ON (aea.id_area_estudo_especifico = u.area_estudo_especifico_aprendizado)
                            INNER JOIN area_estudo_geral agd ON (agd.id_area_geral = u.area_estudo_geral_dominio)
                            INNER JOIN area_estudo_geral aga ON (aga.id_area_geral = u.area_estudo_geral_aprendizado)
                            INNER JOIN idiomas imat ON (imat.id_idioma = u.idioma_materno)
                            INNER JOIN idiomas iflu ON (iflu.id_idioma = ISNULL(u.idioma_fluente, u.idioma_materno))
                            INNER JOIN idiomas iprat ON (iprat.id_idioma = u.idioma_para_praticar)
                            WHERE u.area_estudo_geral_dominio = @areaestudogeralaprendizado
	                        AND (
		                        u.idioma_fluente IN (@idiomaAprendizado, @idiomaDominio, @idiomaMaterno)
		                        OR u.idioma_materno IN (@idiomaAprendizado, @idiomaDominio, @idiomaMaterno)
		                        )";

            ValidarConnection();

            using (SqlConnection connection = _connection)
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@areaestudogeralaprendizado", dadosUsuario.AreaEstudoParaAprenderGeral.Id);
                    command.Parameters.AddWithValue("@idiomaAprendizado", dadosUsuario.IdiomaParaAprender.Id);
                    command.Parameters.AddWithValue("@idiomaDominio", dadosUsuario.IdiomaFluenteSecundario.Id);
                    command.Parameters.AddWithValue("@idiomaMaterno", dadosUsuario.IdiomaOrigem.Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuarioPesquisa = new UsuariosPesquisa()
                            {
                                Id = Convert.ToInt32(reader["idUsuario"]),
                                CaminhoFoto = reader["caminhoFoto"].ToString(),
                                Nome = reader["nomeUsuario"].ToString(),
                                Genero = (Genero)Convert.ToInt32(reader["genero"]),
                                DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                                IdiomaOrigem = new Idioma { Id = Convert.ToInt32(reader["idIdiomaMaterno"]), Descricao = reader["descIdiomaMaterno"].ToString() },
                                IdiomaParaAprender = new Idioma { Id = Convert.ToInt32(reader["idIdiomaAprender"]), Descricao = reader["descIdiomaAprender"].ToString() },
                                IdiomaFluenteSecundario = new Idioma { Id = Convert.ToInt32(reader["idIdiomaFluente"]), Descricao = reader["descIdiomaFluente"].ToString() },
                                Universidade = new Universidade { Id = Convert.ToInt32(reader["idUniversidade"]), Descricao = reader["universidade"].ToString() },
                                AreaEstudoDominioGeral = new AreaEstudo { Id = Convert.ToInt32(reader["idGeralDominio"]), Descricao = reader["descGeralDominio"].ToString() },
                                AreaEstudoDominioEspecifica = new AreaEstudo { Id = Convert.ToInt32(reader["idEspecificaDominio"]), Descricao = reader["descEspecificaDominio"].ToString() },
                                AreaEstudoParaAprenderGeral = new AreaEstudo { Id = Convert.ToInt32(reader["idGeralAprendizado"]), Descricao = reader["descGeralAprendizado"].ToString() },
                                AreaEstudoParaAprenderEspecifico = new AreaEstudo { Id = Convert.ToInt32(reader["idEspecificaAprendizado"]), Descricao = reader["descEspecificaAprendizado"].ToString() },
                                TipoIteracao = (TipoIteracao)Convert.ToInt32(reader["preferenciaConversa"])
                            };

                            listagem.Add(usuarioPesquisa);
                        }
                    }
                }
            }

            return listagem;
        }
    }
}
