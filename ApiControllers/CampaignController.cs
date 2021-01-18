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
  public class CampaignController : ControllerBase
  {
    private readonly CampaignDBOService _CampaignService;
    private readonly IMapper _Mapper;

    public CampaignController(CampaignDBOService CampaignService, IMapper Mapper)
    {
      _CampaignService = CampaignService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<Campaign>> Get() =>
        _Mapper.Map<List<Campaign>>(_CampaignService.Get());

    [HttpGet("{id:length(24)}", Name = "GetCampaign")]
    public ActionResult<Campaign> Get(string id)
    {
      var CampaignDBO = _CampaignService.Get(id);

      if (CampaignDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<Campaign>(CampaignDBO);
    }

    [HttpPost]
    public ActionResult<Campaign> Create(Campaign Campaign)
    {
      var CampaignDBO = _CampaignService.Create(_Mapper.Map<CampaignDBO>(Campaign));

      return CreatedAtRoute("GetCampaign", new { id = CampaignDBO.Id.ToString() }, _Mapper.Map<Campaign>(CampaignDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Campaign CampaignIn)
    {
      var CampaignDBO = _CampaignService.Get(id);

      if (CampaignDBO == null)
      {
        return NotFound();
      }

      _CampaignService.Update(id, _Mapper.Map<CampaignDBO>(CampaignIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var CampaignDBO = _CampaignService.Get(id);

      if (CampaignDBO == null)
      {
        return NotFound();
      }

      _CampaignService.Remove(CampaignDBO.Id);

      return NoContent();
    }
  }
}
