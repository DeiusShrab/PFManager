using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class WeatherSpawnDBOService
  {
    private readonly IMongoCollection<WeatherSpawnDBO> _WeatherSpawns;

    public WeatherSpawnDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _WeatherSpawns = database.GetCollection<WeatherSpawnDBO>("WeatherSpawns");
    }

    public List<WeatherSpawnDBO> Get() => _WeatherSpawns.Find(c => true).ToList();

    public WeatherSpawnDBO Get(string id) => _WeatherSpawns.Find(c => c.Id == id).FirstOrDefault();

    public WeatherSpawnDBO Create(WeatherSpawnDBO WeatherSpawn)
    {
      _WeatherSpawns.InsertOne(WeatherSpawn);
      return WeatherSpawn;
    }

    public void Update(string id, WeatherSpawnDBO WeatherSpawn) => _WeatherSpawns.ReplaceOne(c => c.Id == id, WeatherSpawn);

    public void Remove(WeatherSpawnDBO WeatherSpawn) => _WeatherSpawns.DeleteOne(c => c.Id == WeatherSpawn.Id);

    public void Remove(string id) => _WeatherSpawns.DeleteOne(c => c.Id == id);
  }
}
