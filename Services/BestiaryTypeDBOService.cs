using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class BestiaryTypeDBOService
  {
    private readonly IMongoCollection<BestiaryTypeDBO> _BestiaryTypes;

    public BestiaryTypeDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _BestiaryTypes = database.GetCollection<BestiaryTypeDBO>("BestiaryTypes");
    }

    public List<BestiaryTypeDBO> Get() => _BestiaryTypes.Find(c => true).ToList();

    public BestiaryTypeDBO Get(string id) => _BestiaryTypes.Find(c => c.Id == id).FirstOrDefault();

    public BestiaryTypeDBO Create(BestiaryTypeDBO BestiaryType)
    {
      _BestiaryTypes.InsertOne(BestiaryType);
      return BestiaryType;
    }

    public void Update(string id, BestiaryTypeDBO BestiaryType) => _BestiaryTypes.ReplaceOne(c => c.Id == id, BestiaryType);

    public void Remove(BestiaryTypeDBO BestiaryType) => _BestiaryTypes.DeleteOne(c => c.Id == BestiaryType.Id);

    public void Remove(string id) => _BestiaryTypes.DeleteOne(c => c.Id == id);
  }
}
