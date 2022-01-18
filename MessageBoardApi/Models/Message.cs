using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MessageBoardApi.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    [Required]
    [StringLength(20)]
    public string UserName { get; set; }
    [Required]
    [StringLength(250)]
    public string Content { get; set; }
    [Required]
    public DateTime DatePosted { get; set; }
    [Required]
    [StringLength(20)]
    public string Group { get; set; }
  }

  public class GroupComparer : IEqualityComparer<Message>
  {
    public bool Equals(Message x, Message y)
    {
      if (x.Group == y.Group)
      {
        return true;
      }
      else 
      {
        return false;
      }
    }

    public int GetHashCode(Message obj)
    {
      return obj.Group.GetHashCode();
    }
  }
}