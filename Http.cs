using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;

namespace Siege
{
    class Http
    {
        public static bool BasicExec(string url)
        {
            try {
                // Check Get Or Post
                if (Config.Mode == 0)
                {
                    // Execute GET
                    return GetExec(url);
                }
                else if (Config.Mode == 1)
                {
                    // Check if valid Post
                    if (url.Contains("?"))
                    {
                        // Parse url
                        string[] FinishedPostUrl = url.Split(Convert.ToChar("?"));
                        // Execute POST
                        return PostExec(FinishedPostUrl[0],FinishedPostUrl[1]);
                    }
                    else
                    {
                        Console.WriteLine("SIEGE -> No Data in Request");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
                return false;
            }
         
        }
        public static bool GetExec(string url)
        {
            try
            {
                WebClient Worker = new WebClient();
                // Check if Useragent is set
                if (Config.Useragent.Length > 0)
                {
                    // Set Useragent
                    Worker.Headers["User-Agent"] = Config.Useragent;
                }
                // Execute Request
                Worker.DownloadString(url);
                if (Config.Output == true) {
                    FileSystem.WriteOutput("SIEGE -> 200 OK");
                }
                return true;
            }
            catch (Exception ex)
            {
                Core.StatusCodeParser(ex.Message,Config.unoffical);
                return false;
            }
        }
        public static bool PostExec(string url,string data)
        {
            try {
                WebClient Worker = new WebClient();
                // Check if Useragent is set
                if (Config.Useragent.Length > 0)
                {
                    // Set Useragent
                    Worker.Headers["User-Agent"] = Config.Useragent;
                }
                // Execute Request
                Worker.UploadString(url,data);
                if (Config.Output == true)
                {
                    FileSystem.WriteOutput("SIEGE -> 200 OK");
                }
                return true;
            }
            catch (Exception ex)
            {
                Core.StatusCodeParser(ex.Message, Config.unoffical);
                return false;
            }
        }
    }
}