using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Siege
{
    class Commands
    {
        public static void Help()
        {
            try { 
                Console.WriteLine("---------- Help ----------");
                Console.WriteLine(" ");
                Console.WriteLine("use - use exploit from exploit directory");
                Console.WriteLine("set - set predefined variable used by exploits");
                Console.WriteLine("search - used for searching exploits");
                Console.WriteLine("clear - clean's console text");
                Console.WriteLine("show - displays info (Ex. vars | settings | list | exploits)");
                Console.WriteLine("exploit / run - runs exploit");
                Console.WriteLine("reload - Reload exploits and program");
                Console.WriteLine("exit - exits program");
                Console.WriteLine("help / ? - shows this text");
                Console.WriteLine(" ");
                Console.WriteLine("--------------------------");
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void Show()
        {
            try { 
                if (Config.ExpUri != String.Empty)
                {
                    Console.WriteLine();
                    Console.WriteLine("---------- vars ----------");
                    Console.WriteLine();
                    string Uri = Config.ExpUri;
                    if (Uri.Contains("+target"))
                    {
                        Console.WriteLine("Target -> " +  Config.Target);
                    }
                    if (Uri.Contains("+var0"))
                    {
                        Console.WriteLine("Var0 -> " + Config.var0);
                    }
                    if (Uri.Contains("+var1"))
                    {
                        Console.WriteLine("Var1 -> " + Config.var1);
                    }
                    if (Uri.Contains("+var2"))
                    {
                        Console.WriteLine("Var2 -> " + Config.var2);
                    }
                    if (Uri.Contains("+var3"))
                    {
                        Console.WriteLine("Var3 -> " + Config.var3);
                    }
                    if (Uri.Contains("+var4"))
                    {
                        Console.WriteLine("Var4 -> " + Config.var4);
                    }
                    if (Uri.Contains("+var5"))
                    {
                        Console.WriteLine("Var5 -> " + Config.var5);
                    }
                    if (Uri.Contains("+var6"))
                    {
                        Console.WriteLine("Var6 -> " + Config.var6);
                    }
                    if (Uri.Contains("+var7"))
                    {
                        Console.WriteLine("Var7 -> " + Config.var7);
                    }
                    if (Uri.Contains("+var8"))
                    {
                        Console.WriteLine("Var8 -> " + Config.var8);
                    }
                    if (Uri.Contains("+var9"))
                    {
                        Console.WriteLine("Var9 -> " + Config.var9);
                    }
                    Console.WriteLine();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine();
                }
                else
                {
                    ShowAll();
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void ShowAll()
        {
            try { 
                Console.WriteLine();
                Console.WriteLine("---------- vars ----------");
                Console.WriteLine();
                Console.WriteLine("Target -> " + Config.Target);
                Console.WriteLine("Var0 -> " + Config.var0);
                Console.WriteLine("Var1 -> " + Config.var1);
                Console.WriteLine("Var2 -> " + Config.var2);
                Console.WriteLine("Var3 -> " + Config.var3);
                Console.WriteLine("Var4 -> " + Config.var4);
                Console.WriteLine("Var5 -> " + Config.var5);
                Console.WriteLine("Var6 -> " + Config.var6);
                Console.WriteLine("Var7 -> " + Config.var7);
                Console.WriteLine("Var8 -> " + Config.var8);
                Console.WriteLine("Var9 -> " + Config.var9);
                Console.WriteLine();
                Console.WriteLine("--------------------------");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void ShowList()
        {
            try
            {
                if (Config.TargetList.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("---------- List ----------");
                    Console.WriteLine();
                    int Line = 1;
                    foreach (var item in Config.TargetList)
                    {
                        Console.WriteLine(Line + " -> " + item);
                        Line++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("SIEGE -> Not using any list");
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void ShowExploits()
        {
            try
            {
                if (Config.ExpList.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("---------- Exploits ----------");
                    Console.WriteLine();
                    int Line = 1;
                    foreach (var item in Config.ExpList)
                    {
                        Console.WriteLine(Line + " -> " + item);
                        Line++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("------------------------------");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("SIEGE -> Not using any list");
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void ShowSettings()
        {
            try
            {
                    Console.WriteLine();
                    Console.WriteLine("---------- Settings ----------");
                    Console.WriteLine();
                    Console.WriteLine("Output -> " + Config.Output);
                    Console.WriteLine("Output path -> " + Config.OutputPath);
                    Console.WriteLine("Listmode -> " + Config.Output);
                    Console.WriteLine();
                    Console.WriteLine("------------------------------");
                    Console.WriteLine();
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void use(string Input)
        {
            try { 
                if (Input.Length > 0)
                {
                    FileSystem.SetExploit(Input);
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void set(string Input)
        {
            try { 
                if (Input.StartsWith("target "))
                {
                    Config.Target = Input.Substring("target ".Length);
                }
                else if (Input.StartsWith("var0 "))
                {
                    Config.var0 = Input.Substring("var0 ".Length);
                }
                else if (Input.StartsWith("var1 "))
                {
                    Config.var1 = Input.Substring("var1 ".Length);
                }
                else if (Input.StartsWith("var2 "))
                {
                    Config.var2 = Input.Substring("var2 ".Length);
                }
                else if (Input.StartsWith("var3 "))
                {
                    Config.var3 = Input.Substring("var3 ".Length);
                }
                else if (Input.StartsWith("var4 "))
                {
                    Config.var4 = Input.Substring("var4 ".Length);
                }
                else if (Input.StartsWith("var5 "))
                {
                    Config.var5 = Input.Substring("var5 ".Length);
                }
                else if (Input.StartsWith("var6 "))
                {
                    Config.var6 = Input.Substring("var6 ".Length);
                }
                else if (Input.StartsWith("var7 "))
                {
                    Config.var7 = Input.Substring("var7 ".Length);
                }
                else if (Input.StartsWith("var8 "))
                {
                    Config.var8 = Input.Substring("var8 ".Length);
                }
                else if (Input.StartsWith("var9 "))
                {
                    Config.var9 = Input.Substring("var9 ".Length);
                }
                else if (Input.StartsWith("list "))
                {
                   FileSystem.ReadList(Input.Substring("list ".Length));
                }
                else if (Input.StartsWith("listmode "))
                {
                    if (Input.Substring("listmode ".Length) == "true")
                    {
                        Config.ListMode = true;
                        Console.WriteLine("SIEGE -> List mode = true");
                    }
                    else if (Input.Substring("listmode ".Length) == "false")
                    {
                        Config.ListMode = false;
                        Console.WriteLine("SIEGE -> List mode = false");
                    }
                    else
                    {
                        Console.WriteLine("SIEGE -> Invalid list mode (use true or false lowercase only!)");
                    }
                }
                else if (Input.StartsWith("output "))
                {
                    if (Input.Substring("output ".Length).Length > 0)
                    {
                        Config.OutputPath = Config.OutputPath = Input.Substring("output ".Length);
                        Console.WriteLine("SIEGE -> Output Path = " + Config.OutputPath);
                    }
                    else
                    {
                        Console.WriteLine("SIEGE -> Invalid output path");
                    }
                }
                else if (Input.StartsWith("outputmode "))
                {
                    if (Input.Substring("outputmode ".Length) == "true")
                    {
                        Config.Output = true;
                        Console.WriteLine("SIEGE -> Output mode = true");
                    }
                    else if (Input.Substring("outputmode ".Length) == "false")
                    {
                        Config.Output = false;
                        Console.WriteLine("SIEGE -> Output mode = false");
                    }
                    else
                    {
                        Console.WriteLine("SIEGE -> Invalid Output mode (use true or false lowercase only!)");
                    }
                }
                else
                {
                    Console.WriteLine("SIEGE -> Unknown variable or setting");
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void Search(string Input)
        {
            try { 
                Console.WriteLine();
                int found = 0;
                if (Config.ExpList.Count != 0)
                {
                    foreach (var value in Config.ExpList)
                    {
                        if (value.Contains(Input))
                        {
                            Console.WriteLine(value.Substring(0,value.Length - Config.Extention.Length));
                            found++;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Exploits Found: " + found);
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void Exploit()
        {
            try { 
                if (Config.ExpUri.Length > 0 && Config.ExpPath.Length > 0) {
                    string FinishUrl = Core.StringBuilder();
                    Console.WriteLine();
                    if (Config.ListMode = false)
                    {
                        Console.WriteLine("SIEGE -> Exploit Uri = " + FinishUrl);
                        FileSystem.WriteOutput("SIEGE -> Exploit Uri = " + FinishUrl);
                        if (Http.BasicExec(FinishUrl))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("SIEGE -> 200 OK");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        if (Config.TargetList.Count > 0)
                        {
                            foreach (var value in Config.TargetList)
                            {
                                Config.Target = value;
                                FinishUrl = Core.StringBuilder();
                                Console.WriteLine("SIEGE -> Exploit Uri = " + FinishUrl);
                                FileSystem.WriteOutput("SIEGE -> Exploit Uri = " + FinishUrl);
                                if (Http.BasicExec(FinishUrl))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("SIEGE -> 200 OK");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("SIEGE -> Make sure that you set a valid list");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("SIEGE -> Not using any exploit");
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void Reload()
        {
            try {
                Clear();
                Config.ExpList.Clear();
                Config.TargetList.Clear();
                Config.ExpUri = string.Empty;
                Config.Target = string.Empty;
                Config.var0 = string.Empty;
                Config.var1 = string.Empty;
                Config.var2 = string.Empty;
                Config.var3 = string.Empty;
                Config.var4 = string.Empty;
                Config.var5 = string.Empty;
                Config.var6 = string.Empty;
                Config.var7 = string.Empty;
                Config.var8 = string.Empty;
                Config.var9 = string.Empty;
                Config.ListMode = false;
                Config.Output = false;
                Config.OutputPath = "Output.txt";
                Core.LoadProgram();
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void Clear()
        {
            try {
                Console.Clear();
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void Exit()
        {
            try {
                Config.running = false;
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void ListMode()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
    }
}