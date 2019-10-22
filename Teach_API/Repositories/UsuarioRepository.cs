using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
        public int CadastrarUsuario()
        {
            throw new NotImplementedException();
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
    }
}
