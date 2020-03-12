using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.API.Domain.Models.Services;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Repositories
{
    public class ManufacturerRepository : BaseRepository, IManufacturerRepository
    {
        public ManufacturerRepository(DahkmDbContext context) : base(context)
        {
        }

        public void DeleteManufacturer(int id)
        {
            Manufacturer manufacturer = _context.Find<Manufacturer>(id);
            _context.Remove(manufacturer);
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return _context.Manufacturers.ToList<Manufacturer>();
        }

        public Manufacturer GetManufacturer(int id)
        {
            return _context.Find<Manufacturer>(id);
        }

        public void SaveManufacturer(Manufacturer manufacturer)
        {
            _context.Add(manufacturer);

        }

        public void UpdateManufacturer(int id)
        {
            Manufacturer manufacturer = _context.Find<Manufacturer>(id);
            _context.Update<Manufacturer>(manufacturer);
        }
    }
}
