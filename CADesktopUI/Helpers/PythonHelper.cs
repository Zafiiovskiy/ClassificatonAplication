using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADesktopUI.Helpers
{
    public class PythonHelper
    {
        public string RunFile(string pathToPythonCode)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\Andrian\PycharmProjects\FlaskCrashCourse\venv\Scripts\python.exe"; // need a path to compiler on lockal machine
            var sctipt = pathToPythonCode;
            start.Arguments = String.Format("\"{0}\"", pathToPythonCode);
            start.UseShellExecute = false;
            start.CreateNoWindow = true; 
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;

            var result = "";
            var errors = "";
            using (Process process = Process.Start(start))
            {
                errors = process.StandardError.ReadToEnd();
                result = process.StandardOutput.ReadToEnd();
            }
            return result + errors;
        }


        /// <summary>
        /// Need to implement 'tensorflow, pickle, keras'
        /// Current version of IronPython won't support this external libreries
        /// pythonnet in .NET Core will
        /// </summary>
      
        public string PatchParameter(string parameter, int serviceid, string PathToPythonScript)
        {
            var engine = Python.CreateEngine(); // Extract Python language engine from their grasp
            var scope = engine.CreateScope(); // Introduce Python namespace (scope)
            var d = new Dictionary<string, object>
            {
                { "serviceid", serviceid},
                { "parameter", parameter}
            }; // Add some sample parameters. Notice that there is no need in specifically setting the object type, interpreter will do that part for us in the script properly with high probability

            scope.SetVariable("params", d); // This will be the name of the dictionary in python script, initialized with previously created .NET Dictionary
            ScriptSource source = engine.CreateScriptSourceFromFile(PathToPythonScript); // Load the script
            object result = source.Execute(scope);
            parameter = scope.GetVariable<string>("parameter"); // To get the finally set variable 'parameter' from the python script
            return parameter;
        }
    }
}
