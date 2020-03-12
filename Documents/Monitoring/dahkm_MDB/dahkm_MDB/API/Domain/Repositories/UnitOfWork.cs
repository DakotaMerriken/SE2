using dahkm_MDB.API.Domain.Models.Services;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DahkmDbContext _context;
        public UnitOfWork(DahkmDbContext context)
        {
            _context = context; 
        }
        public void SaveChanges()
        {
            _context.SaveChanges(); 
        }
    }
}
