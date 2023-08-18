using BitesProjectMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitesProjectMvc.Controllers
{

    public class SummaryController : Controller
    {

        private CodeAnalysis code_analysis = new CodeAnalysis();
        public ActionResult Index()
        {
            return View();
        }

        private void Code_Analysis()
        {
           
            string path = Session["FilePath"] as string;
            List<CodeLine> lines = new List<CodeLine>();
            lines = code_analysis.Code_Id(Session["CodeLines"] as List<string>);
        }

    }
}