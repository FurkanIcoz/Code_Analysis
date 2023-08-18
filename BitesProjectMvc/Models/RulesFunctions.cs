using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitesProjectMvc.Models
{
    public class RulesFunctions
    {       
        public bool MaxLength10(string codeLine)
        {
            if (codeLine.Length>= 20) return false;
            else return true;
        }
        public bool MaxLength12(string codeLine)
        {
            if (codeLine.Length >= 30) return false;
            else return true;
        }
        public bool MaxLength14(string codeLine)
        {
            if (codeLine.Length >= 40) return false;
            else return true;
        }
        public bool MaxLength16(string codeLine)
        {
            if (codeLine.Length >= 50) return false;
            else return true;
        }
        public bool MaxLength18(string codeLine)
        {
            if (codeLine.Length >= 60) return false;
            else return true;
        }
    }
}