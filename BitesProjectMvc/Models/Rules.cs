using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitesProjectMvc.Models
{
    public class Rules
    {
        public int RuleID { get; set; }
        public string RuleName { get; set; }
        public Func<string, bool> RuleFunc { get; set; }

    }
}