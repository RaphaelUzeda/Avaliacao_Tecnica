using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avaliacao_Tecnica.Domain.Interfaces;
using Avaliacao_Tecnica.Domain.Models;
using Avaliacao_Tecnica.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Avaliacao_Tecnica.Infra.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        protected readonly BaseContext Db;
        protected readonly DbSet<Client> DbSet;

        public ClientRepository(BaseContext context)
        {
            Db = context;
            DbSet = Db.Set<Client>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Client> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await DbSet.ToListAsync();
        }
      
        public void Add(Client Client)
        {
           DbSet.Add(Client);
        }

        public void Update(Client Client)
        {
            DbSet.Update(Client);
        }

        public void Remove(Client Client)
        {
            DbSet.Remove(Client);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
