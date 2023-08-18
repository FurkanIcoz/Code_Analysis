using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitesProjectMvc.Models
{
    public class CodeLine
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public bool IsValid { get; set; } = true;
    }
}        
