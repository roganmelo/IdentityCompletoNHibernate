using IdentityCompletoNHibernate.App_Start.Identity;
using IdentityCompletoNHibernate.Mappings;
using IdentityCompletoNHibernate.Models;
using Microsoft.AspNet.Identity;
using SimpleInjector;

namespace IdentityCompletoNHibernate.App_Start
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<UnitOfWork>(Lifestyle.Scoped);
            container.RegisterPerWebRequest<IUserStore<IdentityUser>>(() => new UserStore<IdentityUser>(new UnitOfWork().Session));

            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }
    }
}