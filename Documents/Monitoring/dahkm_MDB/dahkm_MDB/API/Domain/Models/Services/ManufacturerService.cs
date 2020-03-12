using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Models.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ManufacturerService(IManufacturerRepository manufacturerRepo, IUnitOfWork unitOfWork)
        {
            _manufacturerRepo = manufacturerRepo;
            _unitOfWork = unitOfWork; 
        }
        public void DeleteManufacturer(int id)
        {
            _manufacturerRepo.DeleteManufacturer(id);
            _unitOfWork.SaveChanges(); 
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return _manufacturerRepo.GetManufacturers(); 
        }

        public Manufacturer GetManufacturer(int id)
        {
            return _manufacturerRepo.GetManufacturer(id); 
        }

        public void SaveManufacturer(Manufacturer manufacturer)
        {
            _manufacturerRepo.SaveManufacturer(manufacturer);
            _unitOfWork.SaveChanges(); 
        }

        public void UpdateManufacturer(int id)
        {
            _manufacturerRepo.UpdateManufacturer(id);
            _unitOfWork.SaveChanges(); 
        }
    }
}
