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
  public class ContinentController : ControllerBase
  {
    private readonly ContinentDBOService _ContinentService;
    private readonly IMapper _Mapper;

    public ContinentController(ContinentDBOService ContinentService, IMapper Mapper)
    {
      _ContinentService = ContinentService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<Continent>> Get() =>
        _Mapper.Map<List<Continent>>(_ContinentService.Get());

    [HttpGet("{id:length(24)}", Name = "GetContinent")]
    public ActionResult<Continent> Get(string id)
    {
      var ContinentDBO = _ContinentService.Get(id);

      if (ContinentDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<Continent>(ContinentDBO);
    }

    [HttpPost]
    public ActionResult<Continent> Create(Continent Continent)
    {
      var ContinentDBO = _ContinentService.Create(_Mapper.Map<ContinentDBO>(Continent));

      return CreatedAtRoute("GetContinent", new { id = ContinentDBO.Id.ToString() }, _Mapper.Map<Continent>(ContinentDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Continent ContinentIn)
    {
      var ContinentDBO = _ContinentService.Get(id);

      if (ContinentDBO == null)
      {
        return NotFound();
      }

      _ContinentService.Update(id, _Mapper.Map<ContinentDBO>(ContinentIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var ContinentDBO = _ContinentService.Get(id);

      if (ContinentDBO == null)
      {
        return NotFound();
      }

      _ContinentService.Remove(ContinentDBO.Id);

      return NoContent();
    }
  }
}
