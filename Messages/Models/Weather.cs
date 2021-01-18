using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class Weather
  {
    public string Id { get; set; }
    public string Description { get; set; }
    public bool HeatDanger { get; set; }
    public bool HeatLethal { get; set; }
    public bool ColdDanger { get; set; }
    public bool ColdLethal { get; set; }
    public bool HighWind { get; set; }
    public bool VisionObscured { get; set; }
    public string Effects { get; set; }
    public string Name { get; set; }
    public bool Magical { get; set; }
    public bool Deadly { get; set; }
    public bool Flooding { get; set; }
  }
}
