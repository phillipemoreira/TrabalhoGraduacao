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
        public User Usuario { get; set; }
        public Item5W2H Item { get; set; }
        public IList<Item5W2H> Itens{ get; set; }
        public ICollection<User> Colaboradores { get; set; }

        public string GetJsonItensData()
        {
            IList<IList<string>> linhas = new List<IList<string>>();

            IList<string> header = new List<string>();
            header.Add("O que");
            header.Add("Porque");
            header.Add("Quando");
            header.Add("Onde");
            header.Add("Como");
            header.Add("Quem");
            header.Add("Quanto");
            header.Add("Status");
            header.Add("Ações");

            linhas.Add(header);

            IList<string> linhaTarefa = new List<string>();

            foreach (Item5W2H item in Itens)
            {
                linhaTarefa.Add(item.Oque);
                linhaTarefa.Add(item.Porque);
                linhaTarefa.Add(item.Quando);
                linhaTarefa.Add(item.Onde);
                linhaTarefa.Add(item.Como);
                string nomes = "";
                foreach (User usuario in item.Quem)
                {
                    nomes += usuario.FirstName +" "+ usuario.LastName +"\n";
                }
                linhaTarefa.Add(nomes);
                linhaTarefa.Add(item.Quanto);
                linhaTarefa.Add(item.Andamento.ToString());
                linhaTarefa.Add("");
            }

            linhas.Add(linhaTarefa);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(linhas);
        }

        public MultiSelectList GetColaboradores()
        {
            var values = Colaboradores.Select(u => new { Id = u.Code.ToString(), Name = u.GetNomeCompleto() });

            return new MultiSelectList(values, "Id", "Name");

        }
    }
}