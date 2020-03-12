using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dahkm_MDB.Interfaces;
using dahkm_MDB.API.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;



namespace dahkm_MDB.API.Controllers
{
    [Route("api/MetricsController")]
    public class MetricsController : Controller
    {
        private readonly IMetricsService _metricsService; 
        public MetricsController(IMetricsService metricsService)
        {
            _metricsService = metricsService; 
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Metrics> GetListOfMetrics()
        {
            var metrics = _metricsService.GetMetrics();
            return metrics; 
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Metrics Get(int id)
        {
            return _metricsService.GetMetric(id); 
        }

        // POST api/MetricsController
        [HttpPost]
        public ActionResult<Metrics> Post(Metrics metric)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var newMetric = new Metrics();
            newMetric.ClicksAfternoon = metric.ClicksAfternoon;
            newMetric.ClicksAM = metric.ClicksAM;
            newMetric.ClicksPM = metric.ClicksPM;
            newMetric.ConversionRate = metric.ConversionRate;
            newMetric.Date = metric.Date;

            _metricsService.SaveMetrics(newMetric);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Metrics> Put(Metrics metric)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            var existingMetric = _metricsService.GetMetric(metric.Id);
            if (existingMetric != null)
            {
                existingMetric.ClicksAfternoon = metric.ClicksAfternoon;
                existingMetric.ClicksAM = metric.ClicksAM;
                existingMetric.Date = metric.Date;
                existingMetric.ClicksPM = metric.ClicksPM;
                existingMetric.ConversionRate = metric.ConversionRate;

                _metricsService.UpdateMetrics(existingMetric.Id); 
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _metricsService.DeleteMetrics(id); 
        }
    }
}
