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
                if (Config.Mode == 0)
                {
                    return GetExec(url);
                }
                else if (Config.Mode == 1)
                {
                    if (url.Contains("?"))
                    {
                        string[] FinishedPostUrl = url.Split(Convert.ToChar("?"));
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
                if (Config.Useragent.Length > 0)
                {
                    Worker.Headers["User-Agent"] = Config.Useragent;
                }
                Worker.DownloadString(url);
                if (Config.Output == true) {
                    FileSystem.WriteOutput("SIEGE -> 200 OK");
                }
                return true;
            }
            catch (Exception ex)
            {
                Core.StatusCodeParser(ex.Message);
                return false;
            }
        }
        public static bool PostExec(string url,string data)
        {
            try {
                WebClient Worker = new WebClient();
                if (Config.Useragent.Length > 0)
                {
                    Worker.Headers["User-Agent"] = Config.Useragent;
                }
                Worker.UploadString(url,data);
                if (Config.Output == true)
                {
                    FileSystem.WriteOutput("SIEGE -> 200 OK");
                }
                return true;
            }
            catch (Exception ex)
            {
                Core.StatusCodeParser(ex.Message);
                return false;
            }
        }
    }
}