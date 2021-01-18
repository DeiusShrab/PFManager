using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class TimeDBOService
  {
    private readonly IMongoCollection<TimeDBO> _Times;

    public TimeDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _Times = database.GetCollection<TimeDBO>("Times");
    }

    public List<TimeDBO> Get() => _Times.Find(c => true).ToList();

    public TimeDBO Get(string id) => _Times.Find(c => c.Id == id).FirstOrDefault();

    public TimeDBO Create(TimeDBO Time)
    {
      _Times.InsertOne(Time);
      return Time;
    }

    public void Update(string id, TimeDBO Time) => _Times.ReplaceOne(c => c.Id == id, Time);

    public void Remove(TimeDBO Time) => _Times.DeleteOne(c => c.Id == Time.Id);

    public void Remove(string id) => _Times.DeleteOne(c => c.Id == id);
  }
}
