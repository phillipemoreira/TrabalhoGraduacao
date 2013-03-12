using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Models
{
    public class User
    {
        public virtual Guid Code { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual ICollection<Plan5W2H> Plans { get; set; }
        public virtual ICollection<User> Friends { get; set; }

        public User()
        {
            this.Code = Guid.NewGuid();
            this.Plans = new List<Plan5W2H>();
            this.Friends = new List<User>();
        }

        public virtual String GetNomeCompleto()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
