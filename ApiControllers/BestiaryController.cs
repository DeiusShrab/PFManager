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
  public class BestiaryController : ControllerBase
  {
    private readonly BestiaryDBOService _BestiaryService;
    private readonly IMapper _Mapper;

    public BestiaryController(BestiaryDBOService BestiaryService, IMapper Mapper)
    {
      _BestiaryService = BestiaryService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<Bestiary>> Get() =>
        _Mapper.Map<List<Bestiary>>(_BestiaryService.Get());

    [HttpGet("{id:length(24)}", Name = "GetBestiary")]
    public ActionResult<Bestiary> Get(string id)
    {
      var BestiaryDBO = _BestiaryService.Get(id);

      if (BestiaryDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<Bestiary>(BestiaryDBO);
    }

    [HttpPost]
    public ActionResult<Bestiary> Create(Bestiary Bestiary)
    {
      var BestiaryDBO = _BestiaryService.Create(_Mapper.Map<BestiaryDBO>(Bestiary));

      return CreatedAtRoute("GetBestiary", new { id = BestiaryDBO.Id.ToString() }, _Mapper.Map<Bestiary>(BestiaryDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Bestiary BestiaryIn)
    {
      var BestiaryDBO = _BestiaryService.Get(id);

      if (BestiaryDBO == null)
      {
        return NotFound();
      }

      _BestiaryService.Update(id, _Mapper.Map<BestiaryDBO>(BestiaryIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var BestiaryDBO = _BestiaryService.Get(id);

      if (BestiaryDBO == null)
      {
        return NotFound();
      }

      _BestiaryService.Remove(BestiaryDBO.Id);

      return NoContent();
    }
  }
}
