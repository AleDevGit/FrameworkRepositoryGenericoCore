﻿using System.Linq;
using FrameworkRepositoryGenerico.DataBase.Contexto;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryCliente(MyCadastroContext context) : base(context)
        {
            _myCadastroContext = context;

        }


       
    }
}
