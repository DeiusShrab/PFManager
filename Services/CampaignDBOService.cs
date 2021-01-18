using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class CampaignDBOService
  {
    private readonly IMongoCollection<CampaignDBO> _Campaigns;

    public CampaignDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _Campaigns = database.GetCollection<CampaignDBO>("Campaigns");
    }

    public List<CampaignDBO> Get() => _Campaigns.Find(c => true).ToList();

    public CampaignDBO Get(string id) => _Campaigns.Find(c => c.Id == id).FirstOrDefault();

    public CampaignDBO Create(CampaignDBO Campaign)
    {
      _Campaigns.InsertOne(Campaign);
      return Campaign;
    }

    public void Update(string id, CampaignDBO Campaign) => _Campaigns.ReplaceOne(c => c.Id == id, Campaign);

    public void Remove(CampaignDBO Campaign) => _Campaigns.DeleteOne(c => c.Id == Campaign.Id);

    public void Remove(string id) => _Campaigns.DeleteOne(c => c.Id == id);
  }
}
