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
  public class GroupsController : ControllerBase
  {
    private readonly MessageBoardApiContext _db;

    public GroupsController(MessageBoardApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Group>> Get(string groupName)
    {

    var query = _db.Groups.AsQueryable();

    // if (group != null)
    // {
    //   query = query.Where(entry => entry.Group == group);
    // }

    // if (datePosted != null)
    // {
    // query = query.Where(entry => entry.DatePosted == datePosted);
    // }

    if (groupName != null)
    {
    query = query.Where(entry => entry.GroupName == groupName);
    }

    return query.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Group>> Post(Group group)
    {
      _db.Groups.Add(group);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = group.GroupId }, group);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> GetGroup(int id)
    {
        var group = await _db.Groups.FindAsync(id);

        if (group == null)
        {
            return NotFound();
        }

        return group;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Group group)
    {
      if (id != group.GroupId)
      {
        return BadRequest();
      }

      _db.Entry(group).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!GroupExists(id))
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
    private bool GroupExists(int id)
    {
      return _db.Groups.Any(e => e.GroupId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
      var group = await _db.Groups.FindAsync(id);
      if (group == null)
      {
        return NotFound();
      }

      _db.Groups.Remove(group);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}