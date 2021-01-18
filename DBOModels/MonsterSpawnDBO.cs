using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.DBOModels
{
  public class MonsterSpawnDBO
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Continent_Id { get; set; }
    public string Season_Id { get; set; }
    public string Bestiary_Id { get; set; }
    public string Time_Id { get; set; }
    public string EnvironmentTerrain_Id { get; set; }
    public string Plane_Id { get; set; }
  }
}
