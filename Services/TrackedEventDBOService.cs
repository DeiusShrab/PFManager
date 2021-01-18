using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class TrackedEventDBOService
  {
    private readonly IMongoCollection<TrackedEventDBO> _TrackedEvents;

    public TrackedEventDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _TrackedEvents = database.GetCollection<TrackedEventDBO>("TrackedEvents");
    }

    public List<TrackedEventDBO> Get() => _TrackedEvents.Find(c => true).ToList();

    public TrackedEventDBO Get(string id) => _TrackedEvents.Find(c => c.Id == id).FirstOrDefault();

    public TrackedEventDBO Create(TrackedEventDBO TrackedEvent)
    {
      _TrackedEvents.InsertOne(TrackedEvent);
      return TrackedEvent;
    }

    public void Update(string id, TrackedEventDBO TrackedEvent) => _TrackedEvents.ReplaceOne(c => c.Id == id, TrackedEvent);

    public void Remove(TrackedEventDBO TrackedEvent) => _TrackedEvents.DeleteOne(c => c.Id == TrackedEvent.Id);

    public void Remove(string id) => _TrackedEvents.DeleteOne(c => c.Id == id);
  }
}
