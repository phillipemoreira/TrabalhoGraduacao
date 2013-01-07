using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Models
{
    public class Plan5W2H
    {
        public virtual Guid Code { get; set; }
        public virtual String Name { get; set; }
        public virtual DateTime Creation { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime End { get; set; }
        public virtual String Description { get; set; }
        public virtual String InitialCost { get; set; }
        public virtual IList<Item5W2H> PlanItens { get; set; }
        
        public Plan5W2H()
        {
            this.Code = Guid.NewGuid();
            this.Creation = DateTime.Now;
            this.PlanItens = new List<Item5W2H>();
        }
    }
}
