﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TG.Model.Models
{
    public class Item5W2H
    {
        public virtual Guid Code { get; set; }

        public virtual string Porque { get; set; }
        public virtual string Oque { get; set; }
        public virtual string Onde { get; set; }
        public virtual string Quando { get; set; }
        public virtual string Como { get; set; }
        public virtual IList<User> Quem { get; set; }
        public virtual string Quanto { get; set; }

        public Item5W2H()
        {
            this.Code = Guid.NewGuid();
        }
    }
}
