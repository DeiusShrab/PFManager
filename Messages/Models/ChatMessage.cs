using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class ChatMessage
  {

    public string Id { get; set; }
    public string Sender_Id { get; set; } // Player_Id
    public string Campaign_Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string Contents { get; set; }
    public string WhisperTo { get; set; } // Player_Id, null if public message
  }
}
