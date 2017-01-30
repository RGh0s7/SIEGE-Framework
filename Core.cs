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
                // Program Header Text
                String[] ASCIIart = {"---------------------------"," ", @" _____ _                 ", @"/  ___(_)                ", @"\ `--. _  ___  __ _  ___ ", @" `--. \ |/ _ \/ _` |/ _ \", @"/\__/ / |  __/ (_| |  __/", @"\____/|_|\___|\__, |\___|", @"               __/ |     ", @"              |___/      "," ", "---------------------------", "|  https://darksiders.nl  |", "---------------------------", "Program Version: " + Config.Version, "Exploits Loaded: " + FileSystem.InitExploits(), "---------------------------"," "," " };
                // For each line in ASCII array 
                foreach (var s in ASCIIart)
                {
                    Console.WriteLine(s);
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        public static void PrintUI()
        {
            try {
                // Check if Exploit is set
                if (Config.ExpPath.Length > 0)
                {
                    // Print UI
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
                    // Print without UI
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
                // Check if there is input
                if (RawInput.Length > 0)
                {
                    string[] input = RawInput.Split(Convert.ToChar(" "));
                    input[0] = input[0].ToLower();
                    // Check input in command list
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
                // Check if Exploit is set
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
        public static void StatusCodeParser(string input,bool unofficial)
        {
            try { 
            // Client Errors
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
                // Server Errors
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
                else if (input.Contains("419") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 419 I'm a fox");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 419 I'm a fox");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("420") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 420 Method Failure / Enhance Your Calm");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 420 Method Failure / Enhance Your Calm");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("450") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 450 Blocked by Windows Parental Controls");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 450 Blocked by Windows Parental Controls");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("498") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 498 Invalid Token (Esri)");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 498 Invalid Token (Esri)");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("499") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 499 Token Required (Esri) / Request has been forbidden by antivirus / Client Closed Request");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 499 Token Required (Esri) / Request has been forbidden by antivirus / Client Closed Request");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("509") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 509 Bandwidth Limit Exceeded");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 509 Bandwidth Limit Exceeded");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("530") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 530 Site is frozen");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 530 Site is frozen");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("598") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 598 Network read timeout error");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 598 Network read timeout error");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("599") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 599 Network connect timeout error");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 599 Network connect timeout error");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("440") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 440 Login Time-out");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 440 Login Time-out");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("449") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 449 Retry With");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 449 Retry With");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("451") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 451 Redirect");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 451 Redirect");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("444") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 444 No Response");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 444 No Response");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("495") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 495 SSL Certificate Error");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 495 SSL Certificate Error");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("496") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 496 SSL Certificate Required");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 496 SSL Certificate Required");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("497") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 497 HTTP Request Sent to HTTPS Port");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 497 HTTP Request Sent to HTTPS Port");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("520") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 520 Unknown Error");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 520 Unknown Error");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("521") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 521 Web Server Is Down");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 521 Web Server Is Down");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("522") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 522 Connection Timed Out");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 522 Connection Timed Out");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("523") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 523 Origin Is Unreachable");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 523 Origin Is Unreachable");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("524") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 524 A Timeout Occurred");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 524 A Timeout Occurred");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("525") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 525 SSL Handshake Failed");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 525 SSL Handshake Failed");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("526") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 526 Invalid SSL Certificate");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 526 Invalid SSL Certificate");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Contains("527") && unofficial == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SIEGE -> 527 Railgun Error");
                    if (Config.Output == true)
                    {
                        FileSystem.WriteOutput("SIEGE -> 527 Railgun Error");
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