using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class PlayerDBOService
  {
    private readonly IMongoCollection<PlayerDBO> _Players;

    public PlayerDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _Players = database.GetCollection<PlayerDBO>("Players");
    }

    public List<PlayerDBO> Get() => _Players.Find(c => true).ToList();

    public PlayerDBO Get(string id) => _Players.Find(c => c.Id == id).FirstOrDefault();

    public PlayerDBO Create(PlayerDBO Player)
    {
      _Players.InsertOne(Player);
      return Player;
    }

    public void Update(string id, PlayerDBO Player) => _Players.ReplaceOne(c => c.Id == id, Player);

    public void Remove(PlayerDBO Player) => _Players.DeleteOne(c => c.Id == Player.Id);

    public void Remove(string id) => _Players.DeleteOne(c => c.Id == id);
  }
}
