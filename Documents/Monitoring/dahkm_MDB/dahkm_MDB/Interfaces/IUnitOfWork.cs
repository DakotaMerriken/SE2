﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges(); 
    }
}
