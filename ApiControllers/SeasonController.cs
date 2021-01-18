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
  public class SeasonController : ControllerBase
  {
    private readonly SeasonDBOService _SeasonService;
    private readonly IMapper _Mapper;

    public SeasonController(SeasonDBOService SeasonService, IMapper Mapper)
    {
      _SeasonService = SeasonService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<Season>> Get() =>
        _Mapper.Map<List<Season>>(_SeasonService.Get());

    [HttpGet("{id:length(24)}", Name = "GetSeason")]
    public ActionResult<Season> Get(string id)
    {
      var SeasonDBO = _SeasonService.Get(id);

      if (SeasonDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<Season>(SeasonDBO);
    }

    [HttpPost]
    public ActionResult<Season> Create(Season Season)
    {
      var SeasonDBO = _SeasonService.Create(_Mapper.Map<SeasonDBO>(Season));

      return CreatedAtRoute("GetSeason", new { id = SeasonDBO.Id.ToString() }, _Mapper.Map<Season>(SeasonDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Season SeasonIn)
    {
      var SeasonDBO = _SeasonService.Get(id);

      if (SeasonDBO == null)
      {
        return NotFound();
      }

      _SeasonService.Update(id, _Mapper.Map<SeasonDBO>(SeasonIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var SeasonDBO = _SeasonService.Get(id);

      if (SeasonDBO == null)
      {
        return NotFound();
      }

      _SeasonService.Remove(SeasonDBO.Id);

      return NoContent();
    }
  }
}
