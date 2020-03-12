using dahkm_MDB.Interfaces;
using dahkm_MDB.API.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Models.Services
{
    public class MetricsService : IMetricsService
    {
        
        private readonly IMetricsRepository _metricsRepo;
        private readonly IUnitOfWork _unitOfWork; 
        public MetricsService(IMetricsRepository metricsRepo, IUnitOfWork unitOfWork)
        {
            _metricsRepo = metricsRepo;
            _unitOfWork = unitOfWork; 
        }

        public void DeleteMetrics(int id)
        {
            _metricsRepo.DeleteMetric(id);
            _unitOfWork.SaveChanges(); 
        }

        public Metrics GetMetric(int id)
        {
            return _metricsRepo.GetMetric(id); 
        }

        public IEnumerable<Metrics> GetMetrics()
        {
            return _metricsRepo.GetMetrics(); 
        }

        public void SaveMetrics(Metrics metric)
        {
            _metricsRepo.SaveMetric(metric);
            _unitOfWork.SaveChanges(); 
        }

        public void UpdateMetrics(int id)
        {
            _metricsRepo.UpdateMetric(id);
            _unitOfWork.SaveChanges(); 
        }
    }
}
