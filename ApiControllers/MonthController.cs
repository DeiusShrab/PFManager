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
  public class MonthController : ControllerBase
  {
    private readonly MonthDBOService _MonthService;
    private readonly IMapper _Mapper;

    public MonthController(MonthDBOService MonthService, IMapper Mapper)
    {
      _MonthService = MonthService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<Month>> Get() =>
        _Mapper.Map<List<Month>>(_MonthService.Get());

    [HttpGet("{id:length(24)}", Name = "GetMonth")]
    public ActionResult<Month> Get(string id)
    {
      var MonthDBO = _MonthService.Get(id);

      if (MonthDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<Month>(MonthDBO);
    }

    [HttpPost]
    public ActionResult<Month> Create(Month Month)
    {
      var MonthDBO = _MonthService.Create(_Mapper.Map<MonthDBO>(Month));

      return CreatedAtRoute("GetMonth", new { id = MonthDBO.Id.ToString() }, _Mapper.Map<Month>(MonthDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Month MonthIn)
    {
      var MonthDBO = _MonthService.Get(id);

      if (MonthDBO == null)
      {
        return NotFound();
      }

      _MonthService.Update(id, _Mapper.Map<MonthDBO>(MonthIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var MonthDBO = _MonthService.Get(id);

      if (MonthDBO == null)
      {
        return NotFound();
      }

      _MonthService.Remove(MonthDBO.Id);

      return NoContent();
    }
  }
}
