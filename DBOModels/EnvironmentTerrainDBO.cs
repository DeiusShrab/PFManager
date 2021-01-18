using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.DBOModels
{
  public class EnvironmentTerrainDBO
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Temperature { get; set; }
    public string Description { get; set; }
    public bool IsWater { get; set; }
    public bool IsUnderground { get; set; }
    public bool IsRough { get; set; }
    public bool IsBroken { get; set; }
    public decimal TravelSpeedModifier { get; set; }
    public decimal MovementModifier { get; set; }
  }
}
