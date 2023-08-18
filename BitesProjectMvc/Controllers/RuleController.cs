using BitesProjectMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitesProjectMvc.Controllers
{
    public class RuleController : Controller
    {
        RuleList ruleList = new RuleList();
        private List<Rules> rules;
        public ActionResult RulePage()
        {
            rules = ruleList.rulesList();
            return View(rules);
            
        }
        private void CheckLines(int id)
        {
            id = Convert.ToInt32(Session["ID"] as string);
        }

        [HttpPost]
        public ActionResult GetSelectedRules(List<int> selectedRuleIds)
        {
            Session["SelectedRuleIds"] = selectedRuleIds;
            return Json(new { success = true });
        }

    }
}