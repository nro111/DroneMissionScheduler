using DroneMissionScheduler.Core.Interfaces;
using DroneMissionScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DroneMissionScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        private IDBContext _DBContext;
        private IMongoCollection<Drone> _DBCollection;
        public DroneController(IDBContext DBContext)
        {
            _DBContext = DBContext;
            _DBCollection = _DBContext.GetCollection<Drone>("Drones");
        }
        // GET: api/<DroneController>
        [HttpGet]
        [Route("getAll")]
        public async Task<string> GetAll()
        {
            try
            {
                var drones = await _DBCollection.FindAsync(_ => true);
                return JsonConvert.SerializeObject(drones.ToListAsync().Result);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }            
        }


        // GET api/<DroneController>/get/5
        [HttpGet]
        [Route("get/{id}")]
        public string Get(int id)
        {
            var drone = _DBCollection.FindAsync(x => x._id.Equals(id)).Result;
            return JsonConvert.SerializeObject(drone);
        }

        // POST api/<DroneController>/add/{json}
        [HttpPost]
        [Route("add/{json}")]
        public void Add(string json)
        {
            var drone = JsonConvert.DeserializeObject<Drone>(json);
            _DBCollection.InsertOneAsync(drone);
        }

        // PUT api/<DroneController>/id/{id}/as/{json}
        [HttpPut]
        [Route("update/id/{id}/as/{json}")]
        public void Update(int id, string json)
        {
            var drone = JsonConvert.DeserializeObject<Drone>(json);
            _DBCollection.ReplaceOneAsync(x => x._id.Equals(id), drone);
        }

        // DELETE api/<DroneController>/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            _DBCollection.DeleteOneAsync(x => x._id.Equals(id));
        }
    }
}
