using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TG.Model.Models;
using FluentNHibernate.Mapping;

namespace TG.Model.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Code).GeneratedBy.Assigned();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
            Map(x => x.UserName);
            Map(x => x.Password);
            HasMany(x => x.Plans);
        }
    }
}
