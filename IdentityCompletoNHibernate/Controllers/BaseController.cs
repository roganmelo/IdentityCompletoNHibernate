using IdentityCompletoNHibernate.Mappings;
using System.Web.Mvc;

namespace IdentityCompletoNHibernate.Controllers
{
    public class BaseController : Controller
    {
        private UnitOfWork _unitOfWork;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid && filterContext.HttpContext.Error == null)
                _unitOfWork = DependencyResolver.Current.GetService<UnitOfWork>();

            if (!filterContext.IsChildAction)
                _unitOfWork.BeginTransaction();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction && filterContext.Controller.ViewData.ModelState.IsValid && filterContext.HttpContext.Error == null && _unitOfWork != null)
                _unitOfWork.Commit();
        }
    }
}