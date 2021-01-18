using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class CampaignDataDBOService
  {
    private readonly IMongoCollection<CampaignDataDBO> _CampaignDatas;

    public CampaignDataDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _CampaignDatas = database.GetCollection<CampaignDataDBO>("CampaignDatas");
    }

    public List<CampaignDataDBO> Get() => _CampaignDatas.Find(c => true).ToList();

    public CampaignDataDBO Get(string id) => _CampaignDatas.Find(c => c.Id == id).FirstOrDefault();

    public CampaignDataDBO Create(CampaignDataDBO CampaignData)
    {
      _CampaignDatas.InsertOne(CampaignData);
      return CampaignData;
    }

    public void Update(string id, CampaignDataDBO CampaignData) => _CampaignDatas.ReplaceOne(c => c.Id == id, CampaignData);

    public void Remove(CampaignDataDBO CampaignData) => _CampaignDatas.DeleteOne(c => c.Id == CampaignData.Id);

    public void Remove(string id) => _CampaignDatas.DeleteOne(c => c.Id == id);
  }
}
