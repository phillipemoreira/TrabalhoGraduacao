using Plan5W2HPlusPlus.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plan5W2HPlusPlus.Application.Models
{
    public class Plan5W2HModel
    {
        public User Usuario { get; set; }
        public IList<Plan5W2H> Plans { get; set; }
        public Plan5W2H Plan { get; set; }
    }
}