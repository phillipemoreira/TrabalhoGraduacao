using Plan5W2HPlusPlus.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plan5W2HPlusPlus.Application.Models
{
    public class ColaboradoresModel
    {
        public IEnumerable<User> Colaboradores { get; set; }
        public IList<Invite> ConvidadosPorMim { get; set; }
        public IList<Invite> EstaoMeConvidando { get; set; }
        public User Usuario { get; set; }

        public MultiSelectList GetColaboradores()
        {
            var values = Colaboradores.Select(u => new { Id = u.Code, Name = u.GetNomeCompleto() });

            return new MultiSelectList(values, "Id", "Name");

        }
    }
}