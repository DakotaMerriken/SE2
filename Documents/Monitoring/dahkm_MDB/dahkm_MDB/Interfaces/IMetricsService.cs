using dahkm_MDB.API.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.Interfaces
{
    public interface IMetricsService
    {
        IEnumerable<Metrics> GetMetrics();
        Metrics GetMetric(int id);
        void DeleteMetrics(int id);
        void UpdateMetrics(int id);
        void SaveMetrics(Metrics metric); 
    }
}
