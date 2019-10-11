///
/// Path Finder - An Implementation of the A* Algorithm for a 2D grid space.
/// 
/// (c) 24th November 2018 Kane Lean (Poole High School)
/// Code provided under GNUv3 Licensing. 
/// 

using System;
using System.Windows.Forms;

namespace PathFinder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
