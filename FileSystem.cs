using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
namespace Siege
{
    class FileSystem
    {
        public static int InitExploits()
        {
            int count = 0;
            try {
                if (Directory.Exists("Siege")) {
                    DirectoryInfo di = new DirectoryInfo("Siege");
                    foreach (var f in di.GetFiles("*" + Config.Extention))
                    {
                        string Fname = f.Name.ToString();
                        Config.ExpList.Add(Fname);
                        count++;
                    }
                }
                else
                {
                    Directory.CreateDirectory("Siege");
                    DirectoryInfo di = new DirectoryInfo("Siege");
                    foreach (var f in di.GetFiles("*" + Config.Extention))
                    {
                        string Fname = f.Name.ToString();
                        Config.ExpList.Add(Fname);
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
            return count;
        }
        public static bool SetExploit(string input)
        {
            try
            {
                if (File.Exists("siege\\" + input + Config.Extention)) {
                    Config.ExpPath = input;
                    StreamReader SR = new StreamReader("siege\\" + input + Config.Extention);
                    Config.ExpUri = SR.ReadToEnd();
                    return true;
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
    }
}