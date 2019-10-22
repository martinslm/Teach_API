﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Models;

namespace Teach_API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        int ValidarLogin (LoginModel loginModel);
        int CadastrarUsuario();
    }
}
