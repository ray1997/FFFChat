using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFFChat.Model;

public class Message
{
    public long AuthorID { get; set; } = -1;
    public string Author { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.MinValue;
    public string Content { get; set; } = string.Empty;
    public string Attachments { get; set; } = string.Empty;
    public string Reactions { get; set; } = string.Empty;
}