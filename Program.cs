using System;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Scripting;
using System.Collections.Generic;

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
            // The path to the scripts
            string path = "scripts/" + filename;
            List<String> scripts = new();

            if (filename == "")
            {
                // Get amount of scripts inside the directory
                int amountOfScripts = Directory.GetFiles(path).Length;
                for (int i = 0; i < amountOfScripts; i++)
                {
                    try
                    {
                        // Get the file in position i, the whole path
                        scripts.Add(Directory.GetFiles(path)[i]);
                        // Retrieve the code as a string
                        string code = File.ReadAllText(scripts[i]);
                        // Execute the C# code
                        Task result = CSharpScript.EvaluateAsync(code, ScriptOptions.Default.AddImports("System", "System.Collections.Generic"));
                        Console.WriteLine(scripts[i] + " executed successfully");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            else
            {
                try
                {
                    // Retrieve the code as a string
                    string code = File.ReadAllText(path + ".cs");
                    // Execute the C# code
                    Task result = CSharpScript.EvaluateAsync(code, ScriptOptions.Default.AddImports("System", "System.Collections.Generic"));
                    Console.WriteLine("Script executed successfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
