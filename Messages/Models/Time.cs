using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class Time
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public int TimeOrder { get; set; }
    public bool IsNight { get; set; }
  }
}
