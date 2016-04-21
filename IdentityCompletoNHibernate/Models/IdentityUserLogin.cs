namespace IdentityCompletoNHibernate.Models
{
    public class IdentityUserLogin
    {
        public virtual string LoginProvider { get; set; }

        public virtual string ProviderKey { get; set; }
    }
}
