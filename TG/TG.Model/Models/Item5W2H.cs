using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TG.Model.Models
{
    public class Item5W2H
    {
        public virtual Guid Code { get; set; }
        public virtual Plan5W2H Plan { get; set; }

        public virtual string Porque { get; set; }
        public virtual string Oque { get; set; }
        public virtual string Onde { get; set; }
        public virtual string Quando { get; set; }


        public Item5W2H()
        {
            this.Code = Guid.NewGuid();
        }
    }
}
