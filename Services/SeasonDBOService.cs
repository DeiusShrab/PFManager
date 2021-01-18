using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class SeasonDBOService
  {
    private readonly IMongoCollection<SeasonDBO> _Seasons;

    public SeasonDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _Seasons = database.GetCollection<SeasonDBO>("Seasons");
    }

    public List<SeasonDBO> Get() => _Seasons.Find(c => true).ToList();

    public SeasonDBO Get(string id) => _Seasons.Find(c => c.Id == id).FirstOrDefault();

    public SeasonDBO Create(SeasonDBO Season)
    {
      _Seasons.InsertOne(Season);
      return Season;
    }

    public void Update(string id, SeasonDBO Season) => _Seasons.ReplaceOne(c => c.Id == id, Season);

    public void Remove(SeasonDBO Season) => _Seasons.DeleteOne(c => c.Id == Season.Id);

    public void Remove(string id) => _Seasons.DeleteOne(c => c.Id == id);
  }
}
