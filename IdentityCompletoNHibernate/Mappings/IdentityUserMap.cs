using FluentNHibernate.Mapping;
using IdentityCompletoNHibernate.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace IdentityCompletoNHibernate.Mappings
{
    //public class IdentityUserMap : ClassMapping<IdentityUser>
    //{
    //    public IdentityUserMap()
    //    {
    //        Table("Users");

    //        Id(x => x.Id, m => m.Generator(new UUIDHexCombGeneratorDef("D")));

    //        Property(x => x.AccessFailedCount);

    //        Property(x => x.Email);

    //        Property(x => x.EmailConfirmed);

    //        Property(x => x.LockoutEnabled);

    //        Property(x => x.LockoutEndDateUtc);

    //        Property(x => x.PasswordHash);

    //        Property(x => x.PhoneNumber);

    //        Property(x => x.PhoneNumberConfirmed);

    //        Property(x => x.TwoFactorEnabled);

    //        Property(x => x.UserName, map =>
    //        {
    //            map.Length(255);
    //            map.NotNullable(true);
    //            map.Unique(true);
    //        });

    //        Property(x => x.SecurityStamp);

    //        Bag(x => x.Claims, map =>
    //        {
    //            map.Key(k =>
    //            {
    //                k.Column("UserId");
    //                k.Update(false); // to prevent extra update afer insert
    //            });
    //            map.Cascade(Cascade.All | Cascade.DeleteOrphans);
    //        }, rel =>
    //        {
    //            rel.OneToMany();
    //        });

    //        Set(x => x.Logins, cam =>
    //        {
    //            cam.Table("User_Logins");
    //            cam.Key(km => km.Column("User_Id"));
    //            cam.Cascade(Cascade.All | Cascade.DeleteOrphans);
    //        }, map =>
    //        {
    //            map.Component(comp =>
    //            {
    //                comp.Property(p => p.LoginProvider);
    //                comp.Property(p => p.ProviderKey);
    //            });
    //        });

    //        Bag(x => x.Roles, map =>
    //        {
    //            map.Table("User_Roles");
    //            map.Key(k => k.Column("User_Id"));
    //        }, rel => rel.ManyToMany(p => p.Column("Role_Id")));
    //    }
    //}

    public class IdentityUserMap : ClassMap<IdentityUser>
    {
        public IdentityUserMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.Assigned().Length(128);
            Map(x => x.Email).Not.Nullable().Length(256);
            Map(x => x.EmailConfirmed).Not.Nullable().Default("false");
            Map(x => x.PasswordHash).Nullable();
            Map(x => x.SecurityStamp).Nullable();
            Map(x => x.PhoneNumber).Nullable();
            Map(x => x.PhoneNumberConfirmed).Not.Nullable().Default("false");
            Map(x => x.TwoFactorEnabled).Not.Nullable().Default("false");
            Map(x => x.LockoutEndDateUtc).Nullable();
            Map(x => x.LockoutEnabled).Not.Nullable().Default("false");
            Map(x => x.AccessFailedCount).Not.Nullable().Default("0");
            Map(x => x.UserName).Not.Nullable().Length(256);
            HasMany(x => x.Clients).Cascade.All().Table("User_Clients").KeyColumn("User_Id");
            HasMany(x => x.Logins).Table("User_Logins").KeyColumn("User_Id");
            HasMany(x => x.Roles).Table("User_Roles").KeyColumn("User_Id");
            HasMany(x => x.Claims).Table("User_Claims").KeyColumn("User_Id");
        }
    }
}