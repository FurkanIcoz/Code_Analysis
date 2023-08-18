using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitesProjectMvc.Models
{
    public class CodeFile
    {
        public string FilePath { get; set; }
        public List<CodeLine> Lines { get; set; } = new List<CodeLine>();
        public List<int> SelectedRuleIds { get; set; } = new List<int>();


    }
}