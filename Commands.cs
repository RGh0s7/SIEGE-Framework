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
                Console.WriteLine("show - displays info");
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
                if (Input.StartsWith("var0 "))
                {
                    Config.var0 = Input.Substring("var0 ".Length);
                }
                if (Input.StartsWith("var1 "))
                {
                    Config.var1 = Input.Substring("var1 ".Length);
                }
                if (Input.StartsWith("var2 "))
                {
                    Config.var2 = Input.Substring("var2 ".Length);
                }
                if (Input.StartsWith("var3 "))
                {
                    Config.var3 = Input.Substring("var3 ".Length);
                }
                if (Input.StartsWith("var4 "))
                {
                    Config.var4 = Input.Substring("var4 ".Length);
                }
                if (Input.StartsWith("var5 "))
                {
                    Config.var5 = Input.Substring("var5 ".Length);
                }
                if (Input.StartsWith("var6 "))
                {
                    Config.var6 = Input.Substring("var6 ".Length);
                }
                if (Input.StartsWith("var7 "))
                {
                    Config.var7 = Input.Substring("var7 ".Length);
                }
                if (Input.StartsWith("var8 "))
                {
                    Config.var8 = Input.Substring("var8 ".Length);
                }
                if (Input.StartsWith("var9 "))
                {
                    Config.var9 = Input.Substring("var9 ".Length);
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
                    Console.WriteLine("Exploit Uri: " + FinishUrl);
                    if (Http.BasicExec(FinishUrl))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SIEGE -> 200 OK");
                        Console.ForegroundColor = ConsoleColor.White;
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
    }
}