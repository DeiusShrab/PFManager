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
  public class PlayerController : ControllerBase
  {
    private readonly PlayerDBOService _PlayerService;
    private readonly IMapper _Mapper;

    public PlayerController(PlayerDBOService PlayerService, IMapper Mapper)
    {
      _PlayerService = PlayerService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<Player>> Get() =>
        _Mapper.Map<List<Player>>(_PlayerService.Get());

    [HttpGet("{id:length(24)}", Name = "GetPlayer")]
    public ActionResult<Player> Get(string id)
    {
      var PlayerDBO = _PlayerService.Get(id);

      if (PlayerDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<Player>(PlayerDBO);
    }

    [HttpPost]
    public ActionResult<Player> Create(Player Player)
    {
      var PlayerDBO = _PlayerService.Create(_Mapper.Map<PlayerDBO>(Player));

      return CreatedAtRoute("GetPlayer", new { id = PlayerDBO.Id.ToString() }, _Mapper.Map<Player>(PlayerDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Player PlayerIn)
    {
      var PlayerDBO = _PlayerService.Get(id);

      if (PlayerDBO == null)
      {
        return NotFound();
      }

      _PlayerService.Update(id, _Mapper.Map<PlayerDBO>(PlayerIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var PlayerDBO = _PlayerService.Get(id);

      if (PlayerDBO == null)
      {
        return NotFound();
      }

      _PlayerService.Remove(PlayerDBO.Id);

      return NoContent();
    }
  }
}
