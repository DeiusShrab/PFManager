using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.DBOModels
{
  public class CampaignDataDBO
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Campaign_Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
  }
}
