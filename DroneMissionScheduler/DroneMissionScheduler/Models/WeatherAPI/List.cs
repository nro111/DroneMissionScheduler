using System.Collections.Generic;

namespace DroneMissionScheduler.Models.WeatherAPI
{
    public class List
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public int visibility { get; set; }
        public int pop { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
    }
}
