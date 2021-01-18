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
  public class TimeController : ControllerBase
  {
    private readonly TimeDBOService _TimeService;
    private readonly IMapper _Mapper;

    public TimeController(TimeDBOService TimeService, IMapper Mapper)
    {
      _TimeService = TimeService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<Time>> Get() =>
        _Mapper.Map<List<Time>>(_TimeService.Get());

    [HttpGet("{id:length(24)}", Name = "GetTime")]
    public ActionResult<Time> Get(string id)
    {
      var TimeDBO = _TimeService.Get(id);

      if (TimeDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<Time>(TimeDBO);
    }

    [HttpPost]
    public ActionResult<Time> Create(Time Time)
    {
      var TimeDBO = _TimeService.Create(_Mapper.Map<TimeDBO>(Time));

      return CreatedAtRoute("GetTime", new { id = TimeDBO.Id.ToString() }, _Mapper.Map<Time>(TimeDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Time TimeIn)
    {
      var TimeDBO = _TimeService.Get(id);

      if (TimeDBO == null)
      {
        return NotFound();
      }

      _TimeService.Update(id, _Mapper.Map<TimeDBO>(TimeIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var TimeDBO = _TimeService.Get(id);

      if (TimeDBO == null)
      {
        return NotFound();
      }

      _TimeService.Remove(TimeDBO.Id);

      return NoContent();
    }
  }
}
