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
        // Load Exploits
        public static int InitExploits()
        {
            int count = 0;
            try {
                // Check if Directory Exsists
                if (Directory.Exists("Siege")) {
                    DirectoryInfo di = new DirectoryInfo("Siege");
                    // For each exploit file
                    foreach (var f in di.GetFiles("*" + Config.Extention))
                    {
                        string Fname = f.Name.ToString();
                        Config.ExpList.Add(Fname);
                        count++;
                    }
                }
                else
                {
                    // Create Directory
                    Directory.CreateDirectory("Siege");
                    DirectoryInfo di = new DirectoryInfo("Siege");
                    // For each exploit file
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
                // Check if Exploit exists
                if (File.Exists("siege\\" + input + Config.Extention)) {
                    Config.ExpPath = input;
                    // Read Exploit
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
                // Check if file exists
                if (File.Exists(path))
                {
                    // Read list
                    StreamReader SR = new StreamReader(path);
                    string Line;
                    while ((Line = SR.ReadLine()) != null)
                    {
                        // Add to target list
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
                // Check if log exists
                if (File.Exists(Config.OutputPath))
                {
                    // Read log if exists
                    StreamReader SR = new StreamReader(Config.OutputPath);
                    String Data = SR.ReadToEnd();
                    SR.Close();
                    // Open stream for logging
                    StreamWriter SW = new StreamWriter(Config.OutputPath);
                    SW.Write(Data);
                    SW.WriteLine(DateTime.Now + " " + input);
                    SW.Flush();
                    SW.Close();
                }
                else
                {
                    // Open stream for logging
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