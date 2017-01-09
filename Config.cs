using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Siege
{
    class Config
    {
        public static bool running = true;
        public static string ProgramTitle = "SIEGE";
        public static string Version = "1.7";
        public static string Extention = ".siege";
        public static string Target, var0, var1, var2, var3, var4, var5, var6, var7, var8, var9;
        public static string ExpUri = string.Empty, ExpPath = string.Empty;
        public static List<string> ExpList = new List<string>();
        public static bool ListMode = false;
        public static List<string> TargetList = new List<string>();
        public static bool Output = false;
        public static string OutputPath = "output.txt";
        public static string Useragent = string.Empty;
        public static int Mode = 0;
    }
}