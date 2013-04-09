using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Models
{
    public class Message
    {
        public virtual Guid Code { get; set; }
        public virtual DateTime Sent { get; set; }
        public virtual User De { get; set; }
        public virtual User Para { get; set; }
        public virtual String SentMessage { get; set; }

        public Message ()
        {
            this.Code = Guid.NewGuid();
            this.Sent = DateTime.Now;
        }
    }
}
