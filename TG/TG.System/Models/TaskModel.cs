using Plan5W2HPlusPlus.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plan5W2HPlusPlus.Application.Models
{
    public class TaskModel
    {
        public ICollection<Plan5W2H> Plans { get; set; }
    }
}