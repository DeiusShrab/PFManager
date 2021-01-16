using MongoDB.Driver;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class CampaignService
  {
    private readonly IMongoCollection<Campaign> _campaigns;

    public CampaignService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _campaigns = database.GetCollection<Campaign>(settings.CollectionName_Campaigns);
    }

    public List<Campaign> Get() => _campaigns.Find(c => true).ToList();

    public Campaign Get(string id) => _campaigns.Find(c => c.Id == id).FirstOrDefault();

    public Campaign Create(Campaign campaign)
    {
      _campaigns.InsertOne(campaign);
      return campaign;
    }

    public void Update(string id, Campaign campaign) => _campaigns.ReplaceOne(c => c.Id == id, campaign);

    public void Remove(Campaign campaign) => _campaigns.DeleteOne(c => c.Id == campaign.Id);

    public void Remove(string id) => _campaigns.DeleteOne(c => c.Id == id);
  }
}
