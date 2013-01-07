using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Plan5W2HPlusPlus.Model.Models;

namespace Plan5W2HPlusPlus.Model.Mappings
{
    public class Plan5W2HMap : ClassMap<Plan5W2H>
    {
        public Plan5W2HMap()
        {
            Id(x => x.Code).GeneratedBy.Assigned();
            Map(x => x.Name);
            Map(x => x.Creation);
            Map(x => x.Start);
            Map(x => x.End);
            Map(x => x.InitialCost);
            Map(x => x.Description).CustomSqlType("text");
            HasMany(x => x.PlanItens).Not.LazyLoad();
        }
    }
}
