namespace IdentityCompletoNHibernate.Models
{
    public class ClientModel
    {
        public virtual int Id { get; set; }

        public virtual string ClientKey { get; set; }

        public virtual IdentityUser User { get; set; }
    }
}