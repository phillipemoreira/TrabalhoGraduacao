using FluentNHibernate.Mapping;
using TG.Model.Models;

namespace TG.Model.Mappings
{
    public class Item5W2HMap : ClassMap<Item5W2H>
    {
        public Item5W2HMap()
        {
            Id(x => x.Code).GeneratedBy.Assigned();
            
            Map(x => x.Oque);
            Map(x => x.Quando);
            Map(x => x.Onde);
            Map(x => x.Porque);
        }
    }
}
