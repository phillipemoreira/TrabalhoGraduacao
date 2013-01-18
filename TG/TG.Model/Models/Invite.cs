using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Models
{
    public class Invite
    {
        public virtual Guid Code { get; set; }
        public virtual DateTime Invited { get; set; }
        public virtual User De { get; set; }
        public virtual User Para { get; set; }
        public virtual String Message { get; set; }

        public Invite ()
        {
            this.Code = new Guid();
        }
    }
}
