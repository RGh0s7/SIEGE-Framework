using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace Siege
{ 
static class Program
{
    static void Main(string[] args)
    {
            try { 
                // Load Program
                Core.LoadProgram();
                // Loop through command line parser
                while (Config.running == true)
                {
                    // Print UI from core
                    Core.PrintUI();
                    // Read Command
                    string ComStr = Console.ReadLine();
                    Core.CommandPaser(ComStr);
                }
            }
            catch (Exception ex)
            {
                Core.LogError(ex.Message);
                Console.ReadLine();
            }
        }

}
}
