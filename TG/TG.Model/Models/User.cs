using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TG.Model.Models
{
    public class User
    {
        public virtual Guid Code { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        
        public User()
        {
            this.Code = Guid.NewGuid();
        }
    }
}
