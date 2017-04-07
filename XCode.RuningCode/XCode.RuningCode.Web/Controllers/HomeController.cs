using System.Linq;
using System.Web.Mvc;
using XCode.RuningCode.Core.Attributes;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Service.Abstracts;

namespace XCode.RuningCode.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Init()
        {
            var typeFinder = XCodeContainer.Resolve<ITypeFinder>();

            var drTypes = typeFinder.FindClassesOfType<Controller>();
            var testss = drTypes.Where(x => x.GetCustomAttributes(typeof(NavigateNameAttribute), true).Any());
            foreach (var dr_type in testss)
            {
                var name = dr_type.Name;
                var controller_name = name.Substring(0, name.Length - 10);
                var attribute_name = dr_type.NavigateName();

                var test = dr_type.GetMethods().Where(x => x.IsPublic && x.GetCustomAttributes(typeof(NavigateNameAttribute), true).Any());
                foreach (var method_info in test)
                {
                    var name1 = method_info.Name;
                    var attribute_name1 = method_info.NavigateName();
                }
            }

            return RedirectToAction("Index");
        }
    }
}