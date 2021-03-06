﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Models
{
    public class Item5W2H
    {
        public virtual Guid Code { get; set; }
        public virtual Status Andamento { get; set; }
        public virtual DateTime Created { get; set; }

        public virtual string Porque { get; set; }
        public virtual string Oque { get; set; }
        public virtual string Onde { get; set; }
        public virtual string Quando { get; set; }
        public virtual string Como { get; set; }
        public virtual ICollection<User> Quem { get; set; }
        public virtual string Quanto { get; set; }
        public virtual Plan5W2H Plan { get; set; }

        public Item5W2H()
        {
            this.Code = Guid.NewGuid();
            this.Created = DateTime.Now;
            this.Andamento = Status.EmAndamento;
            this.Quem = new List<User>();
        }
    }
}
