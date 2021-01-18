using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.DBOModels
{
  public class BestiaryDetailDBO
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Bestiary_Id { get; set; }
    public string MonsterSource { get; set; }
    public string Source { get; set; }
    public string Description { get; set; }
    public string FullText { get; set; }
  }
}
