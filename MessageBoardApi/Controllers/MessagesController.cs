using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;
using System.Linq;
using System;

namespace MessageBoardApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardApiContext _db;

    public MessagesController(MessageBoardApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Message>> Get([FromQuery]int groupId, [FromQuery]string content)
    {

    var query = _db.Messages.AsQueryable();

    if (groupId != 0)
    {
      query = query.Where(entry => entry.GroupId == groupId);
    }

    // if (datePosted != null)
    // {
    // query = query.Where(entry => entry.DatePosted == datePosted);
    // }

    if (content != null)
    {
    query = query.Where(entry => entry.Content == content);
    }

    // if (allGroups) 
    // {
    //   query = query.Distinct();
    //   query = from entry in query 
    //       orderby entry.Group 
    //       select entry;
    // }


    return query.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Message>> Post([FromBody]Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = message.MessageId }, message);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage([FromQuery]int id)
    {
        var message = await _db.Messages.FindAsync(id);

        if (message == null)
        {
            return NotFound();
        }

        return message;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromQuery]int id, [FromBody]Message message)
    {
      if (id != message.MessageId)
      {
        return BadRequest();
      }

      _db.Entry(message).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MessageExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage([FromQuery]int id)
    {
      var message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }

      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}