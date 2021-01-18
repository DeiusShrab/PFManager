using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class WeatherSpawn
  {
    public string Id { get; set; }
    public string Continent_Id { get; set; }
    public string Weather_Id { get; set; }
    public string Season_Id { get; set; }
    public int Weight { get; set; }
    public int Duration { get; set; } // If RandomDuration is true, this is the maximum duration (the minimum is 1)
    public bool RandomDuration { get; set; }
    public bool InterruptTravel { get; set; } // If true, will interrupt multi-day NextDay operations
    public string NextWeatherSpawn { get; set; }
    public string ParentWeatherSpawn { get; set; }
    public string Name { get; set; }
  }
}
