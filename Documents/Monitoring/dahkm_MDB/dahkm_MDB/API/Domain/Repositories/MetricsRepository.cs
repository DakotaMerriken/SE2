using dahkm_MDB.Interfaces;
using dahkm_MDB.API.Domain.Models.Entities;
using dahkm_MDB.API.Domain.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Repositories
{
    public class MetricsRepository : BaseRepository, IMetricsRepository
    {
        public MetricsRepository(DahkmDbContext context) : base(context)
        {

        }

        public void DeleteMetric(int id)
        {
            Metrics metric = _context.Find<Metrics>(id);
            _context.Remove(metric); 
        }

        public Metrics GetMetric(int id)
        {
            return _context.Find<Metrics>(id); 
        }

        public IEnumerable<Metrics> GetMetrics()
        {
            return _context.Metrics.ToList<Metrics>(); 
        }

        public void SaveMetric(Metrics metric)
        {
            _context.Add(metric); 
        }

        public void UpdateMetric(int id)
        {
            Metrics metric = _context.Find<Metrics>(id);
            _context.Update<Metrics>(metric); 
        }
    }
}
