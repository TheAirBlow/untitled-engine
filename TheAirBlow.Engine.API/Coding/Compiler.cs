using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheAirBlow.Engine.API.Coding
{
    internal static class Compiler
    {
        internal static Assembly CompileSourceCodeDom(string sourceCode)
        {
            sourceCode = "using TheAirBlow.Engine.API.Coding;" +
                "\nusing System;" +
                "\nusing System.Text;" +
                "\nusing System.Collections.Generic;" +
                "\nusing System.Linq;" +
                "\nusing System.Threading.Tasks;" +
                "\n\npublic class ObjectAssembly : EngineObject {" + sourceCode;

            sourceCode += "}";
            CodeDomProvider cpd = new CSharpCodeProvider();
            var cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            cp.ReferencedAssemblies.Add("System.Data.dll");
            cp.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");
            cp.ReferencedAssemblies.Add("System.Drawing.dll");
            cp.ReferencedAssemblies.Add("System.Net.Http.dll");
            cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            cp.ReferencedAssemblies.Add("System.Xml.dll");
            cp.ReferencedAssemblies.Add("Newtonsoft.Json.dll");
            cp.ReferencedAssemblies.Add("TheAirBlow.Engine.API.dll");
            cp.GenerateExecutable = false;
            CompilerResults cr = cpd.CompileAssemblyFromSource(cp, sourceCode);

            return cr.CompiledAssembly;
        }

        internal static void ExecuteFromAssembly(Assembly assembly, string methodName, object[] args)
        {
            Type type = assembly.GetType("ObjectAssembly");
            MethodInfo method = type.GetMethod(methodName);
            object obj = assembly.CreateInstance("ObjectAssembly");
            method.Invoke(obj, BindingFlags.InvokeMethod, null, args, CultureInfo.CurrentCulture);
        }

        internal static void ExecuteFromAssembly(Assembly assembly, string methodName)
            => ExecuteFromAssembly(assembly, methodName, null);
    }
}
