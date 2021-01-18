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
  public class BestiaryTypeController : ControllerBase
  {
    private readonly BestiaryTypeDBOService _BestiaryTypeService;
    private readonly IMapper _Mapper;

    public BestiaryTypeController(BestiaryTypeDBOService BestiaryTypeService, IMapper Mapper)
    {
      _BestiaryTypeService = BestiaryTypeService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<BestiaryType>> Get() =>
        _Mapper.Map<List<BestiaryType>>(_BestiaryTypeService.Get());

    [HttpGet("{id:length(24)}", Name = "GetBestiaryType")]
    public ActionResult<BestiaryType> Get(string id)
    {
      var BestiaryTypeDBO = _BestiaryTypeService.Get(id);

      if (BestiaryTypeDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<BestiaryType>(BestiaryTypeDBO);
    }

    [HttpPost]
    public ActionResult<BestiaryType> Create(BestiaryType BestiaryType)
    {
      var BestiaryTypeDBO = _BestiaryTypeService.Create(_Mapper.Map<BestiaryTypeDBO>(BestiaryType));

      return CreatedAtRoute("GetBestiaryType", new { id = BestiaryTypeDBO.Id.ToString() }, _Mapper.Map<BestiaryType>(BestiaryTypeDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, BestiaryType BestiaryTypeIn)
    {
      var BestiaryTypeDBO = _BestiaryTypeService.Get(id);

      if (BestiaryTypeDBO == null)
      {
        return NotFound();
      }

      _BestiaryTypeService.Update(id, _Mapper.Map<BestiaryTypeDBO>(BestiaryTypeIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var BestiaryTypeDBO = _BestiaryTypeService.Get(id);

      if (BestiaryTypeDBO == null)
      {
        return NotFound();
      }

      _BestiaryTypeService.Remove(BestiaryTypeDBO.Id);

      return NoContent();
    }
  }
}
