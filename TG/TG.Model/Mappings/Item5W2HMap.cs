using FluentNHibernate.Mapping;
using Plan5W2HPlusPlus.Model.Models;

namespace Plan5W2HPlusPlus.Model.Mappings
{
    public class Item5W2HMap : ClassMap<Item5W2H>
    {
        public Item5W2HMap()
        {
            Id(x => x.Code).GeneratedBy.Assigned();
            Map(x => x.Andamento);

            Map(x => x.Oque);
            Map(x => x.Quando);
            Map(x => x.Onde);
            Map(x => x.Porque);
            Map(x => x.Como);
            Map(x => x.Quanto);
            HasMany(x => x.Quem).Not.LazyLoad();
            HasOne(x => x.Plan);
        }
    }
}