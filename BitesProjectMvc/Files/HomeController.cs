using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpPost]
        public ActionResult GetRuleID(int id)
        {
            CodeFile codeFile = new CodeFile();
            List<int> WrongLines = new List<int>();
            for (int i = 0; i<codeFile.LineCount; i++)
            {

                Rules rule = new Rules();
                if (!(rule.CheckRule(id, codeFile.ID_Text[i + 1], true)))
                {
                    System.Diagnostics.Debug.WriteLine(codeFile.ID_Text[i + 1]);

                    WrongLines.Add(i+1);
                }
            }
            return Json(new { success = true, message = WrongLines }, JsonRequestBehavior.AllowGet);
        }
        // GET: Home
        public ActionResult Index()
        {
            Rules rule = new Rules();

          //  string file_path = "C:\\Users\\furka\\source\\repos\\Project1cpp\\Project1cpp\\FirstProjectcpp.cpp";
            CodeFile cd = new CodeFile();

            var combinedData = Tuple.Create(cd, rule);
            return View(combinedData);
        }
        public ActionResult CodeText()
        {
            return View();
        }
    }
}