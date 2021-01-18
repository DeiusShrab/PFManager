using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class ContinentDBOService
  {
    private readonly IMongoCollection<ContinentDBO> _Continents;

    public ContinentDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _Continents = database.GetCollection<ContinentDBO>("Continents");
    }

    public List<ContinentDBO> Get() => _Continents.Find(c => true).ToList();

    public ContinentDBO Get(string id) => _Continents.Find(c => c.Id == id).FirstOrDefault();

    public ContinentDBO Create(ContinentDBO Continent)
    {
      _Continents.InsertOne(Continent);
      return Continent;
    }

    public void Update(string id, ContinentDBO Continent) => _Continents.ReplaceOne(c => c.Id == id, Continent);

    public void Remove(ContinentDBO Continent) => _Continents.DeleteOne(c => c.Id == Continent.Id);

    public void Remove(string id) => _Continents.DeleteOne(c => c.Id == id);
  }
}
