using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class Continent
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsUnderground { get; set; }
    public bool IsWater { get; set; }
    public string MapPath { get; set; }
  }
}
