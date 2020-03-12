using dahkm_MDB.API.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.Interfaces
{
    public interface IMetricsRepository
    {
        IEnumerable<Metrics> GetMetrics();
        Metrics GetMetric(int id);
        void SaveMetric(Metrics metric);
        void UpdateMetric(int id);
        void DeleteMetric(int id); 
    }
}
