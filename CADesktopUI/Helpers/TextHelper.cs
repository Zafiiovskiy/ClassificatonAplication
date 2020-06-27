using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADesktopUI.Helpers
{
    public class TextHelper
    {
        public void WriteToFile(string FilePath, string Text)
        {
            File.WriteAllText(FilePath, Text);
        }
    }
}
