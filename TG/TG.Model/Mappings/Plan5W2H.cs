using FluentNHibernate.Mapping;
using TG.Model.Models;

namespace PrimeiraAplicacao.Teste.Model.Mappings
{
    class UserMap : ClassMap<Plan5W2H>
    {
        public UserMap()
        {
            Id(x => x.Code).GeneratedBy.Assigned();            
        }
    }
}
