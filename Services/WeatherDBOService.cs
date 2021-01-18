using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class WeatherDBOService
  {
    private readonly IMongoCollection<WeatherDBO> _Weathers;

    public WeatherDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _Weathers = database.GetCollection<WeatherDBO>("Weathers");
    }

    public List<WeatherDBO> Get() => _Weathers.Find(c => true).ToList();

    public WeatherDBO Get(string id) => _Weathers.Find(c => c.Id == id).FirstOrDefault();

    public WeatherDBO Create(WeatherDBO Weather)
    {
      _Weathers.InsertOne(Weather);
      return Weather;
    }

    public void Update(string id, WeatherDBO Weather) => _Weathers.ReplaceOne(c => c.Id == id, Weather);

    public void Remove(WeatherDBO Weather) => _Weathers.DeleteOne(c => c.Id == Weather.Id);

    public void Remove(string id) => _Weathers.DeleteOne(c => c.Id == id);
  }
}
