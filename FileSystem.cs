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
                    Console.WriteLine("SIEGE -> Exploit not found");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
                return false;
            }
        }
        public static void ReadList(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    StreamReader SR = new StreamReader(path);
                    string Line;
                    while ((Line = SR.ReadLine()) != null)
                    {
                        Config.TargetList.Add(Line);
                    }
                    Console.WriteLine("SIEGE -> Done reading list");
                }
                else
                {
                    Console.WriteLine("SIEGE -> List does not exsist");
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
        public static void WriteOutput(string input)
        {
            try
            {

                if (File.Exists(Config.OutputPath))
                {
                    StreamReader SR = new StreamReader(Config.OutputPath);
                    String Data = SR.ReadToEnd();
                    SR.Close();
                    StreamWriter SW = new StreamWriter(Config.OutputPath);
                    SW.Write(Data);
                    SW.WriteLine(DateTime.Now + " " + input);
                    SW.Flush();
                    SW.Close();
                }
                else
                {
                    StreamWriter SW = new StreamWriter(Config.OutputPath);
                    SW.WriteLine(DateTime.Now + " " + input);
                    SW.Flush();
                    SW.Close();
                }         
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
            }
        }
    }
}