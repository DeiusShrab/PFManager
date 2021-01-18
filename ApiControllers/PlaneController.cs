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
  public class PlaneController : ControllerBase
  {
    private readonly PlaneDBOService _PlaneService;
    private readonly IMapper _Mapper;

    public PlaneController(PlaneDBOService PlaneService, IMapper Mapper)
    {
      _PlaneService = PlaneService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<Plane>> Get() =>
        _Mapper.Map<List<Plane>>(_PlaneService.Get());

    [HttpGet("{id:length(24)}", Name = "GetPlane")]
    public ActionResult<Plane> Get(string id)
    {
      var PlaneDBO = _PlaneService.Get(id);

      if (PlaneDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<Plane>(PlaneDBO);
    }

    [HttpPost]
    public ActionResult<Plane> Create(Plane Plane)
    {
      var PlaneDBO = _PlaneService.Create(_Mapper.Map<PlaneDBO>(Plane));

      return CreatedAtRoute("GetPlane", new { id = PlaneDBO.Id.ToString() }, _Mapper.Map<Plane>(PlaneDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Plane PlaneIn)
    {
      var PlaneDBO = _PlaneService.Get(id);

      if (PlaneDBO == null)
      {
        return NotFound();
      }

      _PlaneService.Update(id, _Mapper.Map<PlaneDBO>(PlaneIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var PlaneDBO = _PlaneService.Get(id);

      if (PlaneDBO == null)
      {
        return NotFound();
      }

      _PlaneService.Remove(PlaneDBO.Id);

      return NoContent();
    }
  }
}
