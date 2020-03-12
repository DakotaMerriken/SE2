using dahkm_MDB.API.Domain.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DahkmDbContext _context;

        public BaseRepository(DahkmDbContext context)
        {
            _context = context; 
        }
    }
}
