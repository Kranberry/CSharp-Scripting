using System;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Scripting;
using System.Collections.Generic;
using System.Reflection;

namespace CsharpScripting
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower().Contains("run"))
                {
                    if (input.ToLower() == "run")
                        RunScripts();
                    else
                        RunScripts(input.Substring(4));
                }
            }
        }

        static void RunScripts(string filename = "")
        {
            // Get the current assembly to give access to the scripting interface
            var asm = Assembly.GetCallingAssembly();
            // The path to the scripts
            string path = "scripts/" + filename;
            List<String> scripts = new();

            // Anything can happen inside the scripts. So try catch is a perfect option to not crash the application on bad syntax
            try
            {
                if (filename == "")
                {
                    // Get amount of scripts inside the directory
                    int amountOfScripts = Directory.GetFiles(path).Length;
                    for (int i = 0; i < amountOfScripts; i++)
                    {
                        // Get the file in position i, the whole path
                        scripts.Add(Directory.GetFiles(path)[i]);
                        // Retrieve the code as a string
                        string code = File.ReadAllText(scripts[i]);
                        // Execute the C# code and add default imports to the scripts you are running. In this case the System Class and the Generic Class 
                        Task result = CSharpScript.EvaluateAsync(code,
                            ScriptOptions.Default  // Set the default options like imports and refrences
                            .AddReferences(asm)     // Add this assembly as a refrence
                            .AddImports("System", "System.Collections.Generic", "CsharpScripting")); // Add this namespace as a default using directive

                        //ScriptOptions.Default.AddReferences("CsharpScripting"));
                        Console.WriteLine(scripts[i] + " executed successfully");
                    }
                }
                else
                {
                    // Retrieve the code as a string
                    string code = File.ReadAllText(path + ".cs");
                    // Execute the C# code

                    Task result = CSharpScript.EvaluateAsync(code,
                        ScriptOptions.Default
                        .AddReferences(asm)
                        .AddImports("System", "System.Collections.Generic", "CsharpScripting.ScriptingInterface"));
                    Console.WriteLine("Script executed successfully");

                }
            }
            catch (Exception e)
            {
                // Print out the exception to the wrongdoer
                Console.WriteLine(e);
            }
        }
    }
}
