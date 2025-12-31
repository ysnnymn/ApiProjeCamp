using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProjeCamp.WebApi.Context;
using ApiProjeCamp.WebApi.Dtos.MessageDtos;
using ApiProjeCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            var messages = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(messages));
            
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var messages=_context.Messages.FirstOrDefault(x=>x.MessageId==id);
            if(null==messages) return NotFound();
            return Ok(_mapper.Map<ResultMessageDto>(messages));
            
        }

        [HttpPost]
        public IActionResult CreateMessages(CreateMessageDto createMessageDto)
        {
            var messages=_mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(messages);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateMessages(UpdateMessageDto updateMessageDto)
        {
            var messsages = _context.Messages.FirstOrDefault(x => x.MessageId == updateMessageDto.MessageId);
            if(null==messsages) return NotFound();
            _mapper.Map(updateMessageDto, messsages);
            _context.Messages.Update(messsages);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteMessages(int id)
        {
            var messages = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            
            if(null==messages) return NotFound();
            _context.Messages.Remove(messages);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }
    }
}
