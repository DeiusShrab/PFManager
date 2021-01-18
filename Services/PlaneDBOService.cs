using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class PlaneDBOService
  {
    private readonly IMongoCollection<PlaneDBO> _Planes;

    public PlaneDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _Planes = database.GetCollection<PlaneDBO>("Planes");
    }

    public List<PlaneDBO> Get() => _Planes.Find(c => true).ToList();

    public PlaneDBO Get(string id) => _Planes.Find(c => c.Id == id).FirstOrDefault();

    public PlaneDBO Create(PlaneDBO Plane)
    {
      _Planes.InsertOne(Plane);
      return Plane;
    }

    public void Update(string id, PlaneDBO Plane) => _Planes.ReplaceOne(c => c.Id == id, Plane);

    public void Remove(PlaneDBO Plane) => _Planes.DeleteOne(c => c.Id == Plane.Id);

    public void Remove(string id) => _Planes.DeleteOne(c => c.Id == id);
  }
}
