using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class Month
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Season_Id { get; set; }
    public int Days { get; set; }
    public int MonthOrder { get; set; }
  }
}
