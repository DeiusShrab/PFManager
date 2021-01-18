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
  public class MonsterSpawnController : ControllerBase
  {
    private readonly MonsterSpawnDBOService _MonsterSpawnService;
    private readonly IMapper _Mapper;

    public MonsterSpawnController(MonsterSpawnDBOService MonsterSpawnService, IMapper Mapper)
    {
      _MonsterSpawnService = MonsterSpawnService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<MonsterSpawn>> Get() =>
        _Mapper.Map<List<MonsterSpawn>>(_MonsterSpawnService.Get());

    [HttpGet("{id:length(24)}", Name = "GetMonsterSpawn")]
    public ActionResult<MonsterSpawn> Get(string id)
    {
      var MonsterSpawnDBO = _MonsterSpawnService.Get(id);

      if (MonsterSpawnDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<MonsterSpawn>(MonsterSpawnDBO);
    }

    [HttpPost]
    public ActionResult<MonsterSpawn> Create(MonsterSpawn MonsterSpawn)
    {
      var MonsterSpawnDBO = _MonsterSpawnService.Create(_Mapper.Map<MonsterSpawnDBO>(MonsterSpawn));

      return CreatedAtRoute("GetMonsterSpawn", new { id = MonsterSpawnDBO.Id.ToString() }, _Mapper.Map<MonsterSpawn>(MonsterSpawnDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, MonsterSpawn MonsterSpawnIn)
    {
      var MonsterSpawnDBO = _MonsterSpawnService.Get(id);

      if (MonsterSpawnDBO == null)
      {
        return NotFound();
      }

      _MonsterSpawnService.Update(id, _Mapper.Map<MonsterSpawnDBO>(MonsterSpawnIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var MonsterSpawnDBO = _MonsterSpawnService.Get(id);

      if (MonsterSpawnDBO == null)
      {
        return NotFound();
      }

      _MonsterSpawnService.Remove(MonsterSpawnDBO.Id);

      return NoContent();
    }
  }
}
