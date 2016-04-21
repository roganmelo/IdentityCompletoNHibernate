using FluentNHibernate.Mapping;
using IdentityCompletoNHibernate.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace IdentityCompletoNHibernate.Mappings
{
    //public class IdentityRoleMap : ClassMapping<IdentityRole>
    //{
    //    public IdentityRoleMap()
    //    {
    //        Table("User_Roles");
    //        Id(x => x.Id, m => m.Generator(new UUIDHexCombGeneratorDef("D")));
    //        Property(x => x.Name, map =>
    //        {
    //            map.Length(255);
    //            map.NotNullable(true);
    //            map.Unique(true);
    //        });
    //        Bag(x => x.Users, map =>
    //        {
    //            map.Table("User_Roles");
    //            map.Cascade(Cascade.None);
    //            map.Key(k => k.Column("Role_Id"));
    //        }, rel => rel.ManyToMany(p => p.Column("User_Id")));
    //    }
    //}

    public class IdentityRoleMap : ClassMap<IdentityRole>
    {
        public IdentityRoleMap()
        {
            Table("User_Roles");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name).Not.Nullable().Unique().Length(255);
            HasMany(x => x.Users).Table("User_Roles");
        }
    }
}
