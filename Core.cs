using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Siege
{
    class Core
    {
        public static void LoadProgram()
        {
            try {
                Console.Title = Config.ProgramTitle + " " + Config.Version;
                Console.WriteLine("---------- SIEGE ----------");
                Console.WriteLine("Program Version: " + Config.Version);
                Console.WriteLine("Exploits Loaded: " + FileSystem.InitExploits());
                Console.WriteLine("---------------------------");
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        public static void PrintUI()
        {
            try {
                if (Config.ExpPath.Length > 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("SIEGE [");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Config.ExpPath.ToUpper());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("] > ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("SIEGE > ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        public static void CommandPaser(string RawInput)
        {
            try {
                if (RawInput.Length > 0)
                {
                    string[] input = RawInput.Split(Convert.ToChar(" "));
                    input[0] = input[0].ToLower();
                    if (input[0].StartsWith("use"))
                    {
                        Commands.use(RawInput.Substring("use ".Length));
                    }
                    else if (input[0].StartsWith("set"))
                    {
                        Commands.set(RawInput.Substring("set ".Length));
                    }
                    else if (input[0] == "exploit")
                    {
                        Commands.Exploit();
                    }
                    else if (input[0].StartsWith("search"))
                    {
                        Commands.Search(RawInput.Substring("search ".Length));
                    }
                    else if (input[0] == "show")
                    {
                        int Count = 0;
                        foreach (var item in input)
                        {
                            Count++;
                        }
                        if (Count > 1)
                        {
                            if (input[1] == "all")
                            {
                                Commands.ShowAll();
                            }
                            else if (input[1] == "list")
                            {
                                Commands.ShowList();
                            }
                            else if (input[1] == "settings")
                            {
                                Commands.ShowSettings();
                            }
                            else if (input[1] == "exploits")
                            {
                                Commands.ShowExploits();
                            }
                            else
                            {
                                Commands.Show();
                            }
                        }
                        else
                        {
                            Commands.Show();
                        }
                    }
                    else if (input[0] == "help" || input[0] == "?")
                    {
                        Commands.Help();
                    }
                    else if (input[0] == "clear")
                    {
                        Commands.Clear();
                    }
                    else if(input[0] == "reload")
                    {
                        Commands.Reload();
                    }
                    else if (input[0] == "exit")
                    {
                        Commands.Exit();
                    }
                    else
                    {
                        Console.WriteLine("SIEGE -> Invalid or Unknown command please try again or use ?"); 
                    }
                }
                else
                {
                    Console.WriteLine("SIEGE -> Invalid or Unknown command please try again or use ?");
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        public static string StringBuilder()
        {
            try
            {
                if (Config.ExpUri.Length > 0) { 
                string output = Config.ExpUri;
                if (output.Contains("+target"))
                {
                    output = output.Replace("+target", Config.Target);
                }
                if (output.Contains("+var0"))
                {
                     output = output.Replace("+var0", Config.var0);
                }
                if (output.Contains("+var1"))
                {
                     output = output.Replace("+var1", Config.var1);
                }
                if (output.Contains("+var2"))
                {
                     output = output.Replace("+var2", Config.var2);
                }
                if (output.Contains("+var3"))
                {
                    output =  output.Replace("+var3", Config.var3);
                }
                if (output.Contains("+var4"))
                {
                     output = output.Replace("+var4", Config.var4);
                }
                if (output.Contains("+var5"))
                {
                     output = output.Replace("+var5", Config.var5);
                }
                if (output.Contains("+var6"))
                {
                    output = output.Replace("+var6", Config.var6);
                }
                if (output.Contains("+var7"))
                {
                    output = output.Replace("+var7", Config.var7);
                }
                if (output.Contains("+var8"))
                {
                    output = output.Replace("+var8", Config.var8);
                }
                if (output.Contains("+var9"))
                {
                    output = output.Replace("+var9", Config.var9);
                }
                return output;
                }
                else
                {
                    Console.WriteLine("SIEGE -> Not using any exploit");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                return string.Empty;
            }
        }
        public static void LogError(string input)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("SIEGE -> Error: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(input + Environment.NewLine);
        }
        public static void StatusCodeParser(string input)
        {
            try { 
                if (input.Contains("400"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 400 Bad Request");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 400 Bad Request");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("401"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 401 Unauthorized");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 401 Unauthorized");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("402"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 402 Payment Required");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 402 Payment Required");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("403"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 403 Forbidden");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 403 Forbidden");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("404"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 404 Not Found");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 404 Not Found");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("405"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 405 Method Not Allowed");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 405 Method Not Allowed");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("406"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 406 Not Acceptable");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 406 Not Acceptable");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("407"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 407 Proxy Authentication Required");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 407 Proxy Authentication Required");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("408"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 408 Request Time-out");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 408 Request Time-out");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("409"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 409 Conflict");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 409 Conflict");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("410"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 410 Gone");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 410 Gone");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("411"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 411 Length Required");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 411 Length Required");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("412"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 412 Precondition Failed");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 412 Precondition Failed");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("413"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 413 Payload Too Large");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 413 Payload Too Large");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("414"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 414 URI Too Long");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 414 URI Too Long");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("415"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 415 Unsupported Media Type");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 415 Unsupported Media Type");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("416"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 416 Range Not Satisfiable");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 416 Range Not Satisfiable");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("417"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 417 Expectation Failed");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 417 Expectation Failed");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("418"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 418 I'm a teapot");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 418 I'm a teapot");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("421"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 421 Misdirected Request");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 421 Misdirected Request");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("422"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 422 Unprocessable Entity");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 422 Unprocessable Entity");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("423"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 423 Locked");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 423 Locked");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("424"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 424 Failed Dependency");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 424 Failed Dependency");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("426"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 426 Upgrade Required");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 426 Upgrade Required");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("428"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 428 Precondition Required");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 428 Precondition Required");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("429"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 429 Too Many Requests");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 429 Too Many Requests");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("431"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 431 Request Header Fields Too Large");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 431 Request Header Fields Too Large");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("451"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 451 Unavailable For Legal Reasons");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 451 Unavailable For Legal Reasons");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("500"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 500 Internal Server Error");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 500 Internal Server Error");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("501"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 501 Not Implemented");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 501 Not Implemented");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("502"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 500 Internal Server Error");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 500 Internal Server Error");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("503"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 503 Service Unavailable");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 503 Service Unavailable");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("504"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 504 Gateway Time-out");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 504 Gateway Time-out");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("505"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 505 HTTP Version Not Supported");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 505 HTTP Version Not Supported");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("506"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 506 Variant Also Negotiater");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 506 Variant Also Negotiater");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("507"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 507 Insufficient Storage");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 507 Insufficient Storage");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("508"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 508 Loop Detected");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 508 Loop Detected");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("510"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 510 Not Extended");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 510 Not Extended");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("511"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 511 Network Authentication Required");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 511 Network Authentication Required");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> Unknown Status code");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> Unknown Status code");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
    }
}