/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: VisionAppDriver.cs
// Description: 
//
// Name: 
// Last Edit: 
/////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision
{
    static class VisionAppDriver
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VisionSplashScreen());
            //Application.Run(new UIForm());
            
        }
    }
}
