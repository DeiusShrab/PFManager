using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class Player
  {
    public string Id { get; set; }
    public string DisplayName { get; set; }

    public List<string> Permissions { get; set; } = new List<string>();
  }
}
