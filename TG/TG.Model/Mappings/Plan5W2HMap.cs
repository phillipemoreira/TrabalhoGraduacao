using FluentNHibernate.Mapping;
using TG.Model.Models;

namespace TG.Model.Mappings
{
    public class Plan5W2HMap : ClassMap<Plan5W2H>
    {
        public Plan5W2HMap()
        {
            Id(x => x.Code).GeneratedBy.Assigned();
            HasOne(x => x.Owner);
        }
    }
}
