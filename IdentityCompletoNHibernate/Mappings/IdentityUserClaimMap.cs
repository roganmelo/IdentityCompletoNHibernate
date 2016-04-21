using FluentNHibernate.Mapping;
using IdentityCompletoNHibernate.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace IdentityCompletoNHibernate.Mappings
{
    //public class IdentityUserClaimMap : ClassMapping<IdentityUserClaim>
    //{
    //    public IdentityUserClaimMap()
    //    {
    //        Table("User_Claims");
    //        Id(x => x.Id, m => m.Generator(Generators.Identity));
    //        Property(x => x.ClaimType);
    //        Property(x => x.ClaimValue);

    //        ManyToOne(x => x.User, m => m.Column("User_Id"));
    //    }
    //}

    public class IdentityUserClaimMap : ClassMap<IdentityUserClaim>
    {
        public IdentityUserClaimMap()
        {
            Table("User_Claims");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ClaimType).Column("Type");
            Map(x => x.ClaimValue).Column("Value");
            References(x => x.User).Column("User_Id");
        }
    }
}
