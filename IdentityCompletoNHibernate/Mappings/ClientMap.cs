using FluentNHibernate.Mapping;
using IdentityCompletoNHibernate.Models;

namespace IdentityCompletoNHibernate.Mappings
{
    public class ClientMap : ClassMap<ClientModel>
    {
        public ClientMap()
        {
            Table("User_Clients");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ClientKey).Nullable();
            References(x => x.User).Column("User_Id");
        }
    }
}