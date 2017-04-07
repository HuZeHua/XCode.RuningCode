using System;
using System.Linq;
using System.Web.Mvc;
using XCode.RuningCode.Core.Attributes;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly INavigateService service;

        public HomeController(INavigateService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Init()
        {
            var type_finder = XCodeContainer.Resolve<ITypeFinder>();

            var dr_types = type_finder.FindClassesOfType<Controller>();
            var types = dr_types.Where(x => x.GetCustomAttributes(typeof(NavigateNameAttribute), true).Any());

            foreach (MenuName enmu_name in Enum.GetValues(typeof(MenuName)))
            {
                var parent = new NavigateDto()
                {
                    Name = enmu_name.value_name(),
                    Url = "#",
                    Type = MenuType.Module
                };
                service.Add(parent);

                var nav_attr = types.Where(x => x.GetAttribute<NavigateNameAttribute>().ParentName == enmu_name);

                foreach (var type in nav_attr)
                {
                    var controller_name = type.Name.Substring(0, type.Name.Length - 10);
                    var test = type.GetMethods().Where(x => x.IsPublic && x.GetCustomAttributes(typeof(NavigateNameAttribute), true).Any());
                    foreach (var method_info in test)
                    {
                        var tetssss = method_info.GetAttribute<NavigateNameAttribute>(false);

                        service.add_children_nav(parent, new NavigateDto()
                        {
                            Name = method_info.NavigateName(),
                            Type = tetssss.Type,
                            ControllerName = controller_name,
                            ActionName = method_info.Name,
                            Url = "/Adm/" + controller_name + "/" + method_info.Name
                        });
                    }
                }
            }


            return RedirectToAction("Index");
        }
    }
}