using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CADesktopUI.Helpers
{
    public class TextHelper
    {
        public void WriteToFile(string FilePath, string Text)
        {
            File.WriteAllText(FilePath, Text);
        }

        public string FormatResult(string Result)
        {
            Result = Result.Trim('\r','\n');
            Result = Result.Trim(']', '[');
            Result = Result.Replace('.', ',');
            if (Double.TryParse(Result, out double ResultInDouble))
            {
                if (ResultInDouble > 2)
                {
                    return "It's a Dog";
                }
                else if (ResultInDouble < -2)
                {
                    return "It's a Cat";
                }
                else
                {
                    return "It's not a cat or a dog";
                }
            }
            else
            {
                return "Conversion error";
            }
        }
    }
}
