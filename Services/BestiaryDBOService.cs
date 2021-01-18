using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class BestiaryDBOService
  {
    private readonly IMongoCollection<BestiaryDBO> _Bestiaries;

    public BestiaryDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _Bestiaries = database.GetCollection<BestiaryDBO>("Bestiaries");
    }

    public List<BestiaryDBO> Get() => _Bestiaries.Find(c => true).ToList();

    public BestiaryDBO Get(string id) => _Bestiaries.Find(c => c.Id == id).FirstOrDefault();

    public BestiaryDBO Create(BestiaryDBO Bestiary)
    {
      _Bestiaries.InsertOne(Bestiary);
      return Bestiary;
    }

    public void Update(string id, BestiaryDBO Bestiary) => _Bestiaries.ReplaceOne(c => c.Id == id, Bestiary);

    public void Remove(BestiaryDBO Bestiary) => _Bestiaries.DeleteOne(c => c.Id == Bestiary.Id);

    public void Remove(string id) => _Bestiaries.DeleteOne(c => c.Id == id);
  }
}
