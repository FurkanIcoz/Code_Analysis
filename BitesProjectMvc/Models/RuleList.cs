using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitesProjectMvc.Models
{
    public class RuleList
    {
        private Rules rule1, rule2, rule3, rule4, rule5;

        public List<Rules> rulesList()
        {
            
            RulesFunctions rule_func = new RulesFunctions();
            rule1 = new Rules()
            {
                RuleID = 1,
                RuleName = "Rule - 1",
                RuleFunc = rule_func.MaxLength10
            };

            rule2 = new Rules()
            {
                RuleID = 2,
                RuleName = "Rule - 2",
                RuleFunc = rule_func.MaxLength12
            };

            rule3 = new Rules()
            {
                RuleID = 3,
                RuleName = "Rule - 3",
                RuleFunc = rule_func.MaxLength14
            };

            rule4 = new Rules()
            {
                RuleID = 4,
                RuleName = "Rule - 4",
                RuleFunc = rule_func.MaxLength16
            };

            rule5 = new Rules()
            {
                RuleID = 5,
                RuleName = "Rule - 5",
                RuleFunc = rule_func.MaxLength18
            };
            List<Rules> rules = new List<Rules>()
            {
                rule1, rule2, rule3, rule4, rule5
            };


            return rules;
        }
    }
}