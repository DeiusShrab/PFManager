using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PFManager.DBOModels;
using PFManager.Messages.Models;
using PFManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WeatherSpawnController : ControllerBase
  {
    private readonly WeatherSpawnDBOService _WeatherSpawnService;
    private readonly IMapper _Mapper;

    public WeatherSpawnController(WeatherSpawnDBOService WeatherSpawnService, IMapper Mapper)
    {
      _WeatherSpawnService = WeatherSpawnService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<WeatherSpawn>> Get() =>
        _Mapper.Map<List<WeatherSpawn>>(_WeatherSpawnService.Get());

    [HttpGet("{id:length(24)}", Name = "GetWeatherSpawn")]
    public ActionResult<WeatherSpawn> Get(string id)
    {
      var WeatherSpawnDBO = _WeatherSpawnService.Get(id);

      if (WeatherSpawnDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<WeatherSpawn>(WeatherSpawnDBO);
    }

    [HttpPost]
    public ActionResult<WeatherSpawn> Create(WeatherSpawn WeatherSpawn)
    {
      var WeatherSpawnDBO = _WeatherSpawnService.Create(_Mapper.Map<WeatherSpawnDBO>(WeatherSpawn));

      return CreatedAtRoute("GetWeatherSpawn", new { id = WeatherSpawnDBO.Id.ToString() }, _Mapper.Map<WeatherSpawn>(WeatherSpawnDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, WeatherSpawn WeatherSpawnIn)
    {
      var WeatherSpawnDBO = _WeatherSpawnService.Get(id);

      if (WeatherSpawnDBO == null)
      {
        return NotFound();
      }

      _WeatherSpawnService.Update(id, _Mapper.Map<WeatherSpawnDBO>(WeatherSpawnIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var WeatherSpawnDBO = _WeatherSpawnService.Get(id);

      if (WeatherSpawnDBO == null)
      {
        return NotFound();
      }

      _WeatherSpawnService.Remove(WeatherSpawnDBO.Id);

      return NoContent();
    }
  }
}
