/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: UIForm.cs
// Description: 
//
// Name: Heather
// Last Edit: 10/22
/////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision
{
    public partial class UIForm : Form
    {
        Marquee MyMarquee = null;       

        public UIForm()
        {
            InitializeComponent();
        }      

        private void UIForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MyMarquee = new Marquee(this.panel1);
            Message myMessage = new Vision.Message("DISCOVERY", Color.Red, Color.Black, Color.Black, Color.Green, 0, 0, 0);
            MyMarquee.displayStaticMessage(myMessage);
        }
    }
}
