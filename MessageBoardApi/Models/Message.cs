using System;
using System.ComponentModel.DataAnnotations;

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
}