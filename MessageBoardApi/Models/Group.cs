using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MessageBoardApi.Models
{
  public class Group
  {
    // public Group()
    // {
    //   this.Messages = new HashSet<Message>();
    // }

    public int GroupId { get; set; }
    [Required]
    [StringLength(100)]
    public string GroupName { get; set; }
    // [Required]
    // public ICollection<Message> Messages { get; set; }
  }
}