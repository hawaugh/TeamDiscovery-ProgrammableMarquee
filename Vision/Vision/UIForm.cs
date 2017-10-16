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
        private Panel panel1;

        public UIForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyMarquee = new Marquee(this.panel1);
        }

        private void UIForm_Load(object sender, EventArgs e)
        {

        }
    }
}
