using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plan5W2HPlusPlus.Model.Models;
using FluentNHibernate.Mapping;

namespace Plan5W2HPlusPlus.Model.Mappings
{
    public class MessageMap : ClassMap<Message>
    {
        public MessageMap()
        {
            Id(x => x.Code).GeneratedBy.Assigned();
            References(x => x.De);
            References(x => x.Para);
            Map(x => x.Sent);
            Map(x => x.SentMessage);
        }
    }
}