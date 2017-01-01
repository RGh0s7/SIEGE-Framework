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
            try
            {
                WebClient Worker = new WebClient();
                Worker.DownloadString(url);
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