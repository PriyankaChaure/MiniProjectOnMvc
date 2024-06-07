using MiniProjectMVC.CustFilter;
using MiniProjectMVC.Models;
using System.Web.Mvc;

namespace MiniProjectMVC.Areas.UserArea
{
    [UserAuth]
    public class UserAreaHomeController : Controller
    {
        MiniContext p =new MiniContext();
         
        public ActionResult Index()
        {
             
            return View();
        }
         
    }
}