using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class BestiaryDetailDBOService
  {
    private readonly IMongoCollection<BestiaryDetailDBO> _BestiaryDetails;

    public BestiaryDetailDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _BestiaryDetails = database.GetCollection<BestiaryDetailDBO>("BestiaryDetails");
    }

    public List<BestiaryDetailDBO> Get() => _BestiaryDetails.Find(c => true).ToList();

    public BestiaryDetailDBO Get(string id) => _BestiaryDetails.Find(c => c.Id == id).FirstOrDefault();

    public BestiaryDetailDBO Create(BestiaryDetailDBO BestiaryDetail)
    {
      _BestiaryDetails.InsertOne(BestiaryDetail);
      return BestiaryDetail;
    }

    public void Update(string id, BestiaryDetailDBO BestiaryDetail) => _BestiaryDetails.ReplaceOne(c => c.Id == id, BestiaryDetail);

    public void Remove(BestiaryDetailDBO BestiaryDetail) => _BestiaryDetails.DeleteOne(c => c.Id == BestiaryDetail.Id);

    public void Remove(string id) => _BestiaryDetails.DeleteOne(c => c.Id == id);
  }
}
