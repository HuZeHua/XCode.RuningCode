using System.Collections.Generic;
using System.Web.Mvc;
using XCode.RuningCode.Core.Attributes;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Web.Areas.Adm.Controllers
{
    [NavigateName("示例文档",MenuType.Module, MenuName.Demo)]
    public class DemoController : AdmBaseController
    {
        public DemoController()
        {
        }
        [NavigateName("按钮", MenuType.Menu)]
        public ActionResult Base()
        {
            return View();
        }

        [NavigateName("ICON图标", MenuType.Menu)]
        public ActionResult Fontawosome()
        {
            return View();
        }
        [NavigateName("表单", MenuType.Menu)]
        public ActionResult Form()
        {
            return View();
        }
        [NavigateName("高级控件", MenuType.Menu)]
        public ActionResult Advance()
        {
            return View();
        }
        [NavigateName("相册", MenuType.Menu)]
        public ActionResult Gallery()
        {
            return View();
        }
        [NavigateName("个人主页", MenuType.Menu)]
        public new ActionResult Profile()
        {
            return View();
        }
        [NavigateName("邮件-收件箱", MenuType.Menu)]
        public ActionResult InBox()
        {
            return View();
        }
        [NavigateName("邮件-查看邮件", MenuType.Menu)]
        public ActionResult InBoxDetail()
        {
            return View();
        }
        [NavigateName("邮件-写邮件", MenuType.Menu)]
        public ActionResult InBoxCompose()
        {
            return View();
        }
        [NavigateName("编辑器", MenuType.Menu)]
        public ActionResult Editor()
        {
            return View();
        }
        [NavigateName("表单验证", MenuType.Menu)]
        public ActionResult FormValidate()
        {
            return View();
        }
        [NavigateName("图表", MenuType.Menu)]
        public ActionResult Chart()
        {
            return View();
        }
        [NavigateName("图表-Morris", MenuType.Menu)]
        public ActionResult ChartMorris()
        {
            return View();
        }
        [NavigateName("ChartJs", MenuType.Menu)]
        public ActionResult ChartJs()
        {
            return View();
        }
        [NavigateName("表格", MenuType.Menu)]
        public ActionResult DataTable()
        {
            return View();
        }
        [NavigateName("高级表格", MenuType.Menu)]
        public ActionResult DataTableAdv()
        {
            return View();
        }

        public JsonResult GetData()
        {
            ResultDto<dynamic> res = new ResultDto<dynamic>();
            
            List<dynamic> list = new List<dynamic>(10);
            for (int i = 0; i < 10; i++)
            {
                list.Add(new
                {
                    name = "AA" + i,
                    position = "局长" + i,
                    office = "Office" + i,
                    salary = i*987
                });
            }
            res.data = list;
            res.length = 10;
            res.recordsTotal = 10;
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}