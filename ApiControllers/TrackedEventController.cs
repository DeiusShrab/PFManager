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
  public class TrackedEventController : ControllerBase
  {
    private readonly TrackedEventDBOService _TrackedEventService;
    private readonly IMapper _Mapper;

    public TrackedEventController(TrackedEventDBOService TrackedEventService, IMapper Mapper)
    {
      _TrackedEventService = TrackedEventService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<TrackedEvent>> Get() =>
        _Mapper.Map<List<TrackedEvent>>(_TrackedEventService.Get());

    [HttpGet("{id:length(24)}", Name = "GetTrackedEvent")]
    public ActionResult<TrackedEvent> Get(string id)
    {
      var TrackedEventDBO = _TrackedEventService.Get(id);

      if (TrackedEventDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<TrackedEvent>(TrackedEventDBO);
    }

    [HttpPost]
    public ActionResult<TrackedEvent> Create(TrackedEvent TrackedEvent)
    {
      var TrackedEventDBO = _TrackedEventService.Create(_Mapper.Map<TrackedEventDBO>(TrackedEvent));

      return CreatedAtRoute("GetTrackedEvent", new { id = TrackedEventDBO.Id.ToString() }, _Mapper.Map<TrackedEvent>(TrackedEventDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, TrackedEvent TrackedEventIn)
    {
      var TrackedEventDBO = _TrackedEventService.Get(id);

      if (TrackedEventDBO == null)
      {
        return NotFound();
      }

      _TrackedEventService.Update(id, _Mapper.Map<TrackedEventDBO>(TrackedEventIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var TrackedEventDBO = _TrackedEventService.Get(id);

      if (TrackedEventDBO == null)
      {
        return NotFound();
      }

      _TrackedEventService.Remove(TrackedEventDBO.Id);

      return NoContent();
    }
  }
}
