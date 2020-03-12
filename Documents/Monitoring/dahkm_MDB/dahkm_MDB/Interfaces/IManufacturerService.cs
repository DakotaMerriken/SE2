using dahkm_MDB.API.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.Interfaces
{
    public interface IManufacturerService
    {
        IEnumerable<Manufacturer> GetManufacturers();
        Manufacturer GetManufacturer(int id);
        void DeleteManufacturer(int id);
        void UpdateManufacturer(int id);
        void SaveManufacturer(Manufacturer manufacturer);
    }
}
