using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class TrackedEvent
  {
    public string Id { get; set; }
    public string DateOccurring { get; set; }
    public string DateLastOccurred { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Notes { get; set; }
    public int ReoccurFreq { get; set; } // Number of (TrackedEventFreq) between occurrences
    public int TrackedEventType { get; set; }
    public int TrackedEventFreq { get; set; }
    public string TrackedEventData { get; set; }
    public string Campaign_Id { get; set; }
    public string Continent_Id { get; set; } // NULL for globally recognized events, otherwise the ID of the continent that observes the event
  }
}
