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
  public class EnvironmentTerrainController : ControllerBase
  {
    private readonly EnvironmentTerrainDBOService _EnvironmentTerrainService;
    private readonly IMapper _Mapper;

    public EnvironmentTerrainController(EnvironmentTerrainDBOService EnvironmentTerrainService, IMapper Mapper)
    {
      _EnvironmentTerrainService = EnvironmentTerrainService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<EnvironmentTerrain>> Get() =>
        _Mapper.Map<List<EnvironmentTerrain>>(_EnvironmentTerrainService.Get());

    [HttpGet("{id:length(24)}", Name = "GetEnvironmentTerrain")]
    public ActionResult<EnvironmentTerrain> Get(string id)
    {
      var EnvironmentTerrainDBO = _EnvironmentTerrainService.Get(id);

      if (EnvironmentTerrainDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<EnvironmentTerrain>(EnvironmentTerrainDBO);
    }

    [HttpPost]
    public ActionResult<EnvironmentTerrain> Create(EnvironmentTerrain EnvironmentTerrain)
    {
      var EnvironmentTerrainDBO = _EnvironmentTerrainService.Create(_Mapper.Map<EnvironmentTerrainDBO>(EnvironmentTerrain));

      return CreatedAtRoute("GetEnvironmentTerrain", new { id = EnvironmentTerrainDBO.Id.ToString() }, _Mapper.Map<EnvironmentTerrain>(EnvironmentTerrainDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, EnvironmentTerrain EnvironmentTerrainIn)
    {
      var EnvironmentTerrainDBO = _EnvironmentTerrainService.Get(id);

      if (EnvironmentTerrainDBO == null)
      {
        return NotFound();
      }

      _EnvironmentTerrainService.Update(id, _Mapper.Map<EnvironmentTerrainDBO>(EnvironmentTerrainIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var EnvironmentTerrainDBO = _EnvironmentTerrainService.Get(id);

      if (EnvironmentTerrainDBO == null)
      {
        return NotFound();
      }

      _EnvironmentTerrainService.Remove(EnvironmentTerrainDBO.Id);

      return NoContent();
    }
  }
}
