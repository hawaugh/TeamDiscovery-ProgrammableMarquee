using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//author: Heather Waugh
namespace Vision
{
    public partial class MarqueeForm : Form
    {

        public MarqueeForm()
        {
            InitializeComponent();
        }

        private void MarqueeForm_Load(object sender, EventArgs e)
        {
            newMatrixGrid();
        }

        //Method to create new grid in the DataGridView
        private void newMatrixGrid()
        {
            dataGridView1.ColumnCount = 96;
            dataGridView1.RowCount = 16;

            //fill background of each cell using a for loop
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                }
            }
        }


    }
}
