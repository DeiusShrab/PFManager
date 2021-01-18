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
  public class ChatMessageController : ControllerBase
  {
    private readonly ChatMessageDBOService _ChatMessageService;
    private readonly IMapper _Mapper;

    public ChatMessageController(ChatMessageDBOService ChatMessageService, IMapper Mapper)
    {
      _ChatMessageService = ChatMessageService;
      _Mapper = Mapper;
    }

    [HttpGet]
    public ActionResult<List<ChatMessage>> Get() =>
        _Mapper.Map<List<ChatMessage>>(_ChatMessageService.Get());

    [HttpGet("{id:length(24)}", Name = "GetChatMessage")]
    public ActionResult<ChatMessage> Get(string id)
    {
      var ChatMessageDBO = _ChatMessageService.Get(id);

      if (ChatMessageDBO == null)
      {
        return NotFound();
      }

      return _Mapper.Map<ChatMessage>(ChatMessageDBO);
    }

    [HttpPost]
    public ActionResult<ChatMessage> Create(ChatMessage ChatMessage)
    {
      var ChatMessageDBO = _ChatMessageService.Create(_Mapper.Map<ChatMessageDBO>(ChatMessage));

      return CreatedAtRoute("GetChatMessage", new { id = ChatMessageDBO.Id.ToString() }, _Mapper.Map<ChatMessage>(ChatMessageDBO));
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, ChatMessage ChatMessageIn)
    {
      var ChatMessageDBO = _ChatMessageService.Get(id);

      if (ChatMessageDBO == null)
      {
        return NotFound();
      }

      _ChatMessageService.Update(id, _Mapper.Map<ChatMessageDBO>(ChatMessageIn));

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var ChatMessageDBO = _ChatMessageService.Get(id);

      if (ChatMessageDBO == null)
      {
        return NotFound();
      }

      _ChatMessageService.Remove(ChatMessageDBO.Id);

      return NoContent();
    }
  }
}
