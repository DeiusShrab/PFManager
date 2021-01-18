using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Models
{
  public class DatabaseSettings : IDatabaseSettings
  {
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
  }

  public interface IDatabaseSettings
  {
    string DatabaseName { get; set; }
    string ConnectionString { get; set; }
  }
}
