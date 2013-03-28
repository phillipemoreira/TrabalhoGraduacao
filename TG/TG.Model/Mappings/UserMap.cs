using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plan5W2HPlusPlus.Model.Models;
using FluentNHibernate.Mapping;

namespace Plan5W2HPlusPlus.Model.Mappings
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
            HasMany(x => x.Plans).Cascade.AllDeleteOrphan().Not.LazyLoad();
            HasManyToMany(x => x.Friends)
                .ParentKeyColumn("FriendId")
                .ChildKeyColumn("UserId")
                .Table("UserFriends")
                .Cascade.SaveUpdate().Not.LazyLoad();
        }
    }
}
