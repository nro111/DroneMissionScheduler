using DroneMissionScheduler.Core.Interfaces;
using DroneMissionScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
    public class PilotController : ControllerBase
    {
        private IDBContext _DBContext;
        private IMongoCollection<Pilot> _DBCollection;
        public PilotController(IDBContext DBContext)
        {
            _DBContext = DBContext;
            _DBCollection = _DBContext.GetCollection<Pilot>("Pilots");
        }
        // GET: api/<PilotController>/getAll
        [HttpGet]
        [Route("getAll")]
        public string GetAll()
        {
            var pilots = _DBCollection.FindAsync(_ => true).Result.ToList();
            return JsonConvert.SerializeObject(pilots);
        }

        // GET api/<PilotController>/get/5
        [HttpGet]
        [Route("get/{id}")]
        public string Get(int id)
        {
            var pilot = _DBCollection.FindAsync(x => x._id.Equals(id)).Result;
            return JsonConvert.SerializeObject(pilot);
        }

        // POST api/<PilotController>/add/{json}
        [HttpPost]
        [Route("add/{json}")]
        public void Add(string json)
        {
            var pilot = JsonConvert.DeserializeObject<Pilot>(json);
            _DBCollection.InsertOneAsync(pilot);
        }

        // PUT api/<PilotController>/id/{id}/as/{json}
        [HttpPut]
        [Route("update/id/{id}/as/{json}")]
        public void Update(int id, string json)
        {
            var pilot = JsonConvert.DeserializeObject<Pilot>(json);
            _DBCollection.ReplaceOneAsync(x => x._id.Equals(id), pilot);
        }

        // DELETE api/<PilotController>/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            _DBCollection.DeleteOneAsync(x => x._id.Equals(id));
        }
    }
}