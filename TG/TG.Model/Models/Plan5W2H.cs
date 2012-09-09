using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TG.Model.Models
{
    public class Plan5W2H
    {
        public virtual Guid Code { get; set; }
        public virtual User Owner { get; set; }

        public Plan5W2H()
        {
            this.Code = Guid.NewGuid();
        }
    }
}
