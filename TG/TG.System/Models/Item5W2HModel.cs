using Plan5W2HPlusPlus.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Plan5W2HPlusPlus.Application.Models
{
    public class Item5W2HModel
    {
        public Item5W2H Item { get; set; }
        public ICollection<Item5W2H> Itens { get; set; }
        public ICollection<User> Colaboradores { get; set; }
        public Plan5W2H Plan { get; set; }

        public MultiSelectList GetColaboradores()
        {
            var values = Colaboradores.Select(u => new { Id = u.Code.ToString(), Name = u.GetNomeCompleto() });

            return new MultiSelectList(values, "Id", "Name");

        }
    }
}