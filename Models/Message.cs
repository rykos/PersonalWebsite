using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MichalRykowskiWebsite.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
