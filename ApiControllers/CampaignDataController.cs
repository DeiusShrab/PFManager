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
  public class CampaignDataController : ControllerBase
  {
    private readonly CampaignDataDBOService _CampaignDataService;
    private readonly IMapper _Mapper;

    public CampaignDataController(CampaignDataDBOService CampaignDataService, IMapper Mapper)
    {
      _CampaignDataService = CampaignDataService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<CampaignData>> Get() =>
        _Mapper.Map<List<CampaignData>>(_CampaignDataService.Get());

    [HttpGet("{id:length(24)}", Name = "GetCampaignData")]
    public ActionResult<CampaignData> Get(string id)
    {
      var CampaignDataDBO = _CampaignDataService.Get(id);

      if (CampaignDataDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<CampaignData>(CampaignDataDBO);
    }

    [HttpPost]
    public ActionResult<CampaignData> Create(CampaignData CampaignData)
    {
      var CampaignDataDBO = _CampaignDataService.Create(_Mapper.Map<CampaignDataDBO>(CampaignData));

      return CreatedAtRoute("GetCampaignData", new { id = CampaignDataDBO.Id.ToString() }, _Mapper.Map<CampaignData>(CampaignDataDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, CampaignData CampaignDataIn)
    {
      var CampaignDataDBO = _CampaignDataService.Get(id);

      if (CampaignDataDBO == null)
      {
        return NotFound();
      }

      _CampaignDataService.Update(id, _Mapper.Map<CampaignDataDBO>(CampaignDataIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var CampaignDataDBO = _CampaignDataService.Get(id);

      if (CampaignDataDBO == null)
      {
        return NotFound();
      }

      _CampaignDataService.Remove(CampaignDataDBO.Id);

      return NoContent();
    }
  }
}
