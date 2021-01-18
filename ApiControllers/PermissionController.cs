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
  public class PermissionController : ControllerBase
  {
    private readonly PermissionDBOService _PermissionService;
    private readonly IMapper _Mapper;

    public PermissionController(PermissionDBOService PermissionService, IMapper Mapper)
    {
      _PermissionService = PermissionService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<Permission>> Get() =>
        _Mapper.Map<List<Permission>>(_PermissionService.Get());

    [HttpGet("{id:length(24)}", Name = "GetPermission")]
    public ActionResult<Permission> Get(string id)
    {
      var PermissionDBO = _PermissionService.Get(id);

      if (PermissionDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<Permission>(PermissionDBO);
    }

    [HttpPost]
    public ActionResult<Permission> Create(Permission Permission)
    {
      var PermissionDBO = _PermissionService.Create(_Mapper.Map<PermissionDBO>(Permission));

      return CreatedAtRoute("GetPermission", new { id = PermissionDBO.Id.ToString() }, _Mapper.Map<Permission>(PermissionDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Permission PermissionIn)
    {
      var PermissionDBO = _PermissionService.Get(id);

      if (PermissionDBO == null)
      {
        return NotFound();
      }

      _PermissionService.Update(id, _Mapper.Map<PermissionDBO>(PermissionIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var PermissionDBO = _PermissionService.Get(id);

      if (PermissionDBO == null)
      {
        return NotFound();
      }

      _PermissionService.Remove(PermissionDBO.Id);

      return NoContent();
    }
  }
}
