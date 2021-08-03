using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsappLib.Models;

namespace WhatsappBulk.Models
{
    public class PrepareMessage
    {
        public List<Contact> Contacts { get; set; }
        public string Message {get;set;}
        public int FileCount { get; set; }
        public string ImagePath { get; set; }
        public int DelayAntarContact { get; set; }
        public int DelayXContact { get; set; }
        public int CounterContact { get; set; }
        public int NUserJeda { get; set; }
        public Random Rnd { get; set; }
    }
}
