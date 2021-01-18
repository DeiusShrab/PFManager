using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class PermissionDBOService
  {
    private readonly IMongoCollection<PermissionDBO> _Permissions;

    public PermissionDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _Permissions = database.GetCollection<PermissionDBO>("Permissions");
    }

    public List<PermissionDBO> Get() => _Permissions.Find(c => true).ToList();

    public PermissionDBO Get(string id) => _Permissions.Find(c => c.Id == id).FirstOrDefault();

    public PermissionDBO Create(PermissionDBO Permission)
    {
      _Permissions.InsertOne(Permission);
      return Permission;
    }

    public void Update(string id, PermissionDBO Permission) => _Permissions.ReplaceOne(c => c.Id == id, Permission);

    public void Remove(PermissionDBO Permission) => _Permissions.DeleteOne(c => c.Id == Permission.Id);

    public void Remove(string id) => _Permissions.DeleteOne(c => c.Id == id);
  }
}
