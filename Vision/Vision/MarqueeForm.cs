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
        const int cColWidth = 20;
        const int cRowHeight = 20;
        const int cMaxColumn = 96;
        const int cMaxRow = 16;
        const int matrixWidth = cColWidth * cMaxColumn + 3;
        const int matrixHeight = cRowHeight * cMaxRow + 3;
        DataGridView DGV;

        public MarqueeForm()
        {
            InitializeComponent();
        }

        private void MarqueeForm_Load(object sender, EventArgs e)
        {
            DGV = new DataGridView();
            DGV.Name = "DGV";
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToAddRows = false;
            DGV.RowHeadersVisible = false;
            DGV.ColumnHeadersVisible = false;
            DGV.GridColor = Color.DarkBlue;
            DGV.DefaultCellStyle.BackColor = Color.AliceBlue;
            DGV.ScrollBars = ScrollBars.None;
            DGV.Size = new Size(matrixWidth, matrixHeight);
            DGV.Location = new Point(50, 50);
            DGV.Font = new System.Drawing.Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            DGV.ForeColor = Color.DarkBlue;
            DGV.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // add 1536 cells
            for (int i = 0; i < cMaxColumn; i++)
            {
                DataGridViewTextBoxColumn TxCol = new DataGridViewTextBoxColumn();
                TxCol.MaxInputLength = 1;   // only one digit allowed in a cell
                DGV.Columns.Add(TxCol);
                DGV.Columns[i].Name = "Col " + (i + 1).ToString();
                DGV.Columns[i].Width = cColWidth;
                DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (int j = 0; j < cMaxRow; j++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = cRowHeight;
                DGV.Rows.Add(row);
            }

            Controls.Add(DGV);

        }
    }
}







