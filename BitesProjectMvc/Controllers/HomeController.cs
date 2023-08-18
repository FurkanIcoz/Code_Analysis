using BitesProjectMvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitesProjectMvc.Controllers
{
    public class HomeController : Controller
    {
        private List<int> selectedRuleIds = new List<int>();
        private RuleList ruleList = new RuleList();

        private CodeFile code;
        private CodeAnalysis code_analysis;

        public HomeController()
        {
            code = new CodeFile();
            code_analysis = new CodeAnalysis();
        }
        public ActionResult MainPage()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CodeLines(string file_path)
        {
            file_path = Session["FilePath"] as string;
            code_analysis = new CodeAnalysis();
            List<string> codeLines = code_analysis.CodeLines(file_path);

            if (Session["CodeLines"] == null)
            {
                Session["CodeLines"] = new List<CodeLine>();
            }

            if (Session["CodeFile"] != null && code.FilePath == file_path)
            {
                code.Lines = code_analysis.Code_Id(code_analysis.CodeLines(file_path));
            }
            else
            {
                code.FilePath = file_path;
                code.Lines = code_analysis.Code_Id(code_analysis.CodeLines(file_path));
            }

            Session["CodeFile"] = code;
            Session["CodeLines"] = code.Lines;

            return View(code);
        }


        [HttpPost]
        public ActionResult GetFilePath(HttpPostedFileBase dosyaSec)
        {
            if (dosyaSec != null && dosyaSec.ContentLength > 0)
            {
                string dosyaYolu = Server.MapPath("~/Files/" + dosyaSec.FileName);
                dosyaSec.SaveAs(dosyaYolu);
                Session["FilePath"] = dosyaYolu;

                return RedirectToAction("CodeLines");
            }

            return View("DosyaSecmeOrnegi");
        }

        [HttpPost]
        public ActionResult ToggleRule(int ruleId)
        {
            CodeFile codeFile = Session["CodeFile"] as CodeFile;

            if (codeFile.SelectedRuleIds.Contains(ruleId))
            {
                codeFile.SelectedRuleIds.Remove(ruleId);
            }
            else
            {
                codeFile.SelectedRuleIds.Add(ruleId);
            }

            foreach (var line in codeFile.Lines)
            {
                bool isLineInvalid = IsLineInvalid(line.Code, codeFile.SelectedRuleIds);
                line.IsValid = !isLineInvalid;
            }

            Session["CodeFile"] = codeFile;

            return PartialView("_CodeLinesView", codeFile);
        }

        public ActionResult SelectedRules()
        {
            List<string> invalidLineSummaries = new List<string>();

            if (Session["CodeLines"] == null)
            {
                Session["CodeLines"] = new List<CodeLine>();
            }

            List<CodeLine> codeLines = Session["CodeLines"] as List<CodeLine>;

            foreach (var line in codeLines)
            {
                foreach (var ruleId in code.SelectedRuleIds)
                {
                    var rule = GetRuleById(ruleId);

                    if (!rule.RuleFunc(line.Code))
                    {
                        string summary = $" \"{rule.RuleName}\" Line {line.ID}";
                        invalidLineSummaries.Add(summary);
                    } 
                }
            }

            return PartialView("_SummaryView", invalidLineSummaries);

        }


        private bool IsLineInvalid(string codeLine, List<int> selectedRuleIds)
        {
            RulesFunctions ruleFunctions = new RulesFunctions();

            foreach (var ruleId in selectedRuleIds)
            {
                var rule = GetRuleById(ruleId);
                if (!rule.RuleFunc(codeLine))
                {
                    return true;
                }
            }

            return false;
        }


        [HttpPost]
        public ActionResult SelectedRules(List<int> selectedRuleIds)
        {
            List<string> invalidLineSummaries = new List<string>();

            if (Session["CodeLines"] == null)
            {
                Session["CodeLines"] = new CodeFile { Lines = new List<CodeLine>() };
            }

            CodeFile codeFile = Session["CodeFile"] as CodeFile;

            foreach (var line in codeFile.Lines)
            {
                bool isLineInvalid = IsLineInvalid(line.Code, codeFile.SelectedRuleIds);
                line.IsValid = !isLineInvalid;
            }

            Session["CodeFile"] = codeFile;

            foreach (var line in codeFile.Lines)
            {
                foreach (var ruleId in codeFile.SelectedRuleIds)
                {
                    var rule = GetRuleById(ruleId);
                    if (!rule.RuleFunc(line.Code))
                    {
                        string summary = $" \"{rule.RuleName}\" Line {line.ID}";
                        invalidLineSummaries.Add(summary);
                    }
                }
            }

            return PartialView("_SummaryView", invalidLineSummaries);

        }

        private Rules GetRuleById(int ruleId)
        {
            return ruleList.rulesList().FirstOrDefault(r => r.RuleID == ruleId);
        }
    }
}