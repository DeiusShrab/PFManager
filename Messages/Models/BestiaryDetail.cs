using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class BestiaryDetail
  {
    public string Id { get; set; }
    public string Bestiary_Id { get; set; }
    public string MonsterSource { get; set; }
    public string Source { get; set; }
    public string Description { get; set; }
    public string FullText { get; set; }
  }
}
