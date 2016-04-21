using FluentNHibernate.Mapping;
using IdentityCompletoNHibernate.Models;

namespace IdentityCompletoNHibernate.Mappings
{
    public class IdentityUserLoginMap : ClassMap<IdentityUserLogin>
    {
        public IdentityUserLoginMap()
        {
            Table("User_Logins");
            Id(x => x.ProviderKey).GeneratedBy.Assigned();
            Map(x => x.LoginProvider);
        }
    }
}
