using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class MonsterSpawnDBOService
  {
    private readonly IMongoCollection<MonsterSpawnDBO> _MonsterSpawns;

    public MonsterSpawnDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _MonsterSpawns = database.GetCollection<MonsterSpawnDBO>("MonsterSpawns");
    }

    public List<MonsterSpawnDBO> Get() => _MonsterSpawns.Find(c => true).ToList();

    public MonsterSpawnDBO Get(string id) => _MonsterSpawns.Find(c => c.Id == id).FirstOrDefault();

    public MonsterSpawnDBO Create(MonsterSpawnDBO MonsterSpawn)
    {
      _MonsterSpawns.InsertOne(MonsterSpawn);
      return MonsterSpawn;
    }

    public void Update(string id, MonsterSpawnDBO MonsterSpawn) => _MonsterSpawns.ReplaceOne(c => c.Id == id, MonsterSpawn);

    public void Remove(MonsterSpawnDBO MonsterSpawn) => _MonsterSpawns.DeleteOne(c => c.Id == MonsterSpawn.Id);

    public void Remove(string id) => _MonsterSpawns.DeleteOne(c => c.Id == id);
  }
}
