using MongoDB.Driver;
using PFManager.DBOModels;
using PFManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Services
{
  public class ChatMessageDBOService
  {
    private readonly IMongoCollection<ChatMessageDBO> _ChatMessages;

    public ChatMessageDBOService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _ChatMessages = database.GetCollection<ChatMessageDBO>("ChatMessages");
    }

    public List<ChatMessageDBO> Get() => _ChatMessages.Find(c => true).ToList();

    public ChatMessageDBO Get(string id) => _ChatMessages.Find(c => c.Id == id).FirstOrDefault();

    public ChatMessageDBO Create(ChatMessageDBO ChatMessage)
    {
      _ChatMessages.InsertOne(ChatMessage);
      return ChatMessage;
    }

    public void Update(string id, ChatMessageDBO ChatMessage) => _ChatMessages.ReplaceOne(c => c.Id == id, ChatMessage);

    public void Remove(ChatMessageDBO ChatMessage) => _ChatMessages.DeleteOne(c => c.Id == ChatMessage.Id);

    public void Remove(string id) => _ChatMessages.DeleteOne(c => c.Id == id);
  }
}
