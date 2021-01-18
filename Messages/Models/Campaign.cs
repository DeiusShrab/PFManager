using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class Campaign
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; }
    public bool IsActive { get; set; }
  }
}
