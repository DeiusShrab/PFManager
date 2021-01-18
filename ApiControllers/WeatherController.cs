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
  public class WeatherController : ControllerBase
  {
    private readonly WeatherDBOService _WeatherService;
    private readonly IMapper _Mapper;

    public WeatherController(WeatherDBOService WeatherService, IMapper Mapper)
    {
      _WeatherService = WeatherService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<Weather>> Get() =>
        _Mapper.Map<List<Weather>>(_WeatherService.Get());

    [HttpGet("{id:length(24)}", Name = "GetWeather")]
    public ActionResult<Weather> Get(string id)
    {
      var WeatherDBO = _WeatherService.Get(id);

      if (WeatherDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<Weather>(WeatherDBO);
    }

    [HttpPost]
    public ActionResult<Weather> Create(Weather Weather)
    {
      var WeatherDBO = _WeatherService.Create(_Mapper.Map<WeatherDBO>(Weather));

      return CreatedAtRoute("GetWeather", new { id = WeatherDBO.Id.ToString() }, _Mapper.Map<Weather>(WeatherDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Weather WeatherIn)
    {
      var WeatherDBO = _WeatherService.Get(id);

      if (WeatherDBO == null)
      {
        return NotFound();
      }

      _WeatherService.Update(id, _Mapper.Map<WeatherDBO>(WeatherIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var WeatherDBO = _WeatherService.Get(id);

      if (WeatherDBO == null)
      {
        return NotFound();
      }

      _WeatherService.Remove(WeatherDBO.Id);

      return NoContent();
    }
  }
}
