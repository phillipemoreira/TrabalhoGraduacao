using System;
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
            int totalFinalizados = this.PlanItens.Where(x => x.Andamento == Status.Finalizado).ToList().Count;
            if (this.PlanItens.Count > 0 && totalFinalizados > 0)
                return (Double)totalFinalizados / (Double)this.PlanItens.Count;
            return 0;
        }

        public virtual IList<Item5W2H> GetItensByUser(User usuario)
        {
            return this.PlanItens.Where(i => i.Quem.Contains(usuario)).OrderBy(i => i.Created).ToList();
        }
    }
}
