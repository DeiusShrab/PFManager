using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class MonthDBOService
  {
    private readonly IMongoCollection<MonthDBO> _Months;

    public MonthDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _Months = database.GetCollection<MonthDBO>("Months");
    }

    public List<MonthDBO> Get() => _Months.Find(c => true).ToList();

    public MonthDBO Get(string id) => _Months.Find(c => c.Id == id).FirstOrDefault();

    public MonthDBO Create(MonthDBO Month)
    {
      _Months.InsertOne(Month);
      return Month;
    }

    public void Update(string id, MonthDBO Month) => _Months.ReplaceOne(c => c.Id == id, Month);

    public void Remove(MonthDBO Month) => _Months.DeleteOne(c => c.Id == Month.Id);

    public void Remove(string id) => _Months.DeleteOne(c => c.Id == id);
  }
}
