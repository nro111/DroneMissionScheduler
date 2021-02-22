using DroneMissionScheduler.Core.Interfaces;
using DroneMissionScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DroneMissionScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionScheduleController : ControllerBase
    {
        private IDBContext _DBContext;
        private IMongoCollection<Mission> _DBCollection;
        public MissionScheduleController(IDBContext DBContext)
        {
            _DBContext = DBContext;
            _DBCollection = _DBContext.GetCollection<Mission>("Missions");
        }

        // GET: api/<MissionScheduleController>
        [HttpGet]
        [Route("getAll")]
        public async Task<string> GetAll()
        {
            var missions = await _DBCollection.FindAsync(_ => true);
            return JsonConvert.SerializeObject(missions.ToListAsync().Result);
        }


        // GET api/<MissionScheduleController>/get/5
        [HttpGet]
        [Route("get/{id}")]
        public string Get(int id)
        {
            var mission = _DBCollection.FindAsync(x => x._id.Equals(id)).Result;
            return JsonConvert.SerializeObject(mission);
        }

        // POST api/<MissionScheduleController>/add/{json}
        [HttpPost]
        [Route("add/{json}")]
        public void Add(string json)
        {
            var mission = JsonConvert.DeserializeObject<Mission>(json);
            _DBCollection.InsertOneAsync(mission);
        }

        // PUT api/<MissionScheduleController>/id/{id}/as/{json}
        [HttpPut]
        [Route("update/id/{id}/as/{json}")]
        public void Update(int id, string json)
        {
            var missionSchedule = JsonConvert.DeserializeObject<Mission>(json);
            _DBCollection.ReplaceOneAsync(x => x._id.Equals(id), missionSchedule);
        }

        // DELETE api/<MissionScheduleController>/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            _DBCollection.DeleteOneAsync(x => x._id.Equals(id));
        }
    }
}
