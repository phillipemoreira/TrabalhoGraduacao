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
        public virtual SatusConvite Aceito { get; set; }

        public Invite ()
        {
            this.Code = Guid.NewGuid();
            this.Aceito = SatusConvite.Pendente;
            this.Invited = DateTime.Now;
        }

        public enum SatusConvite
        {
            Aceito,
            Rejeitado,
            Pendente
        }
    }
}
