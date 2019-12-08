using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MichalRykowskiWebsite.Models;
using Newtonsoft.Json.Linq;

namespace MichalRykowskiWebsite.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : ControllerBase
    {
        private readonly MessageContext _context;
        public MessageController(MessageContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Message>> GetMessages()
        {
            return _context.MessageItems;
        }

        [HttpGet("{id}")]
        public ActionResult<Message> GetMessage(int id)
        {
            Message msg = _context.MessageItems.Find(id);
            if (msg == null)
            {
                return NotFound();
            }
            return msg;
        }

        [HttpPost()]
        public ActionResult<Message> PostMessage(Message message)
        {
            try
            {
                message.Date = DateTime.Now;
                _context.MessageItems.Add(message);
                _context.SaveChanges();
            }
            catch 
            {
                return BadRequest();
            }
            return CreatedAtAction("GetMessageItem", new Message { Id = message.Id}, message);
        }
    }
}
