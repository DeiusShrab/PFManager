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
  public class BestiaryDetailController : ControllerBase
  {
    private readonly BestiaryDetailDBOService _BestiaryDetailService;
    private readonly IMapper _Mapper;

    public BestiaryDetailController(BestiaryDetailDBOService BestiaryDetailService, IMapper Mapper)
    {
      _BestiaryDetailService = BestiaryDetailService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<BestiaryDetail>> Get() =>
        _Mapper.Map<List<BestiaryDetail>>(_BestiaryDetailService.Get());

    [HttpGet("{id:length(24)}", Name = "GetBestiaryDetail")]
    public ActionResult<BestiaryDetail> Get(string id)
    {
      var BestiaryDetailDBO = _BestiaryDetailService.Get(id);

      if (BestiaryDetailDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<BestiaryDetail>(BestiaryDetailDBO);
    }

    [HttpPost]
    public ActionResult<BestiaryDetail> Create(BestiaryDetail BestiaryDetail)
    {
      var BestiaryDetailDBO = _BestiaryDetailService.Create(_Mapper.Map<BestiaryDetailDBO>(BestiaryDetail));

      return CreatedAtRoute("GetBestiaryDetail", new { id = BestiaryDetailDBO.Id.ToString() }, _Mapper.Map<BestiaryDetail>(BestiaryDetailDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, BestiaryDetail BestiaryDetailIn)
    {
      var BestiaryDetailDBO = _BestiaryDetailService.Get(id);

      if (BestiaryDetailDBO == null)
      {
        return NotFound();
      }

      _BestiaryDetailService.Update(id, _Mapper.Map<BestiaryDetailDBO>(BestiaryDetailIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var BestiaryDetailDBO = _BestiaryDetailService.Get(id);

      if (BestiaryDetailDBO == null)
      {
        return NotFound();
      }

      _BestiaryDetailService.Remove(BestiaryDetailDBO.Id);

      return NoContent();
    }
  }
}
