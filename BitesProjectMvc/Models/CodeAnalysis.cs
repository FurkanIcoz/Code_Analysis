using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BitesProjectMvc.Models
{
    public class CodeAnalysis
    {
        public List<string> CodeLines(string file_path)
        {

            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(file_path))
            {
                while (!(reader.EndOfStream))
                {
                    string line = "\t" + reader.ReadLine();
                    lines.Add(line);
                }
            }
            return lines;
        }

        public List<CodeLine> Code_Id(List<string> code)
        {
            List<CodeLine> code_lines = new List<CodeLine>();

            for (int i = 0; i < code.Count; i++)
            {
                CodeLine codeLine = new CodeLine()
                {
                    ID = i+1,
                    Code = code[i]
                };
                code_lines.Add(codeLine);
            }
            return code_lines;
        }

    }
}