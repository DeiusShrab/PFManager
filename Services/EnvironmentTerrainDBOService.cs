using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class EnvironmentTerrainDBOService
  {
    private readonly IMongoCollection<EnvironmentTerrainDBO> _EnvironmentTerrains;

    public EnvironmentTerrainDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _EnvironmentTerrains = database.GetCollection<EnvironmentTerrainDBO>("EnvironmentTerrains");
    }

    public List<EnvironmentTerrainDBO> Get() => _EnvironmentTerrains.Find(c => true).ToList();

    public EnvironmentTerrainDBO Get(string id) => _EnvironmentTerrains.Find(c => c.Id == id).FirstOrDefault();

    public EnvironmentTerrainDBO Create(EnvironmentTerrainDBO EnvironmentTerrain)
    {
      _EnvironmentTerrains.InsertOne(EnvironmentTerrain);
      return EnvironmentTerrain;
    }

    public void Update(string id, EnvironmentTerrainDBO EnvironmentTerrain) => _EnvironmentTerrains.ReplaceOne(c => c.Id == id, EnvironmentTerrain);

    public void Remove(EnvironmentTerrainDBO EnvironmentTerrain) => _EnvironmentTerrains.DeleteOne(c => c.Id == EnvironmentTerrain.Id);

    public void Remove(string id) => _EnvironmentTerrains.DeleteOne(c => c.Id == id);
  }
}
