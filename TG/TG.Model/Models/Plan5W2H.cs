﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Models
{
    public class Plan5W2H
    {
        public virtual Guid Code { get; set; }
        public virtual Status Andamento { get; set; }
        public virtual String Name { get; set; }
        public virtual DateTime Creation { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime End { get; set; }
        public virtual String Description { get; set; }
        public virtual String InitialCost { get; set; }
        public virtual ICollection<Item5W2H> PlanItens { get; set; }
        public virtual User Owner { get; set; }
        public virtual Double Concluido { get; set; }
        
        public Plan5W2H()
        {
            this.Code = Guid.NewGuid();
            this.Andamento = Status.EmAndamento;
            this.Creation = DateTime.Now;
            this.PlanItens = new List<Item5W2H>();
        }

        public virtual Double PorcentagemConcluido()
        {
            return this.PlanItens.Count > 0 ? 
                    this.PlanItens.Count / this.PlanItens.Where(x => x.Andamento == Status.Finalizado).ToList().Count : 0;
        }
    }
}
