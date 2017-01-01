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
                Core.LoadProgram();
                while (Config.running == true)
                {
                    Core.PrintUI();
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
