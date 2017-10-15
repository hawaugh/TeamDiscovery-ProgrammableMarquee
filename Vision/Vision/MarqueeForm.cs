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
        const int cColWidth = 12;
        const int cRowHeight = 12;
        const int cMaxColumn = 96;
        const int cMaxRow = 16;
        const int matrixWidth = cColWidth * cMaxColumn + 10;
        const int matrixHeight = cRowHeight * cMaxRow + 10;
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
            DGV.BackgroundColor  = Color.Black;
            DGV.ScrollBars = ScrollBars.None;
            DGV.Size = new Size(matrixWidth + 20, matrixHeight + 20);
            DGV.Location = new Point(0, 0);
            DGV.CellPainting += Dgv_CellPainting;
            DGV.ForeColor = Color.Transparent;
            //DGV.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // add 1536 cells
            for (int i = 0; i < cMaxColumn; i++)
            {
                DataGridViewImageColumn imageCell = new DataGridViewImageColumn();

                //TxCol.MaxInputLength = 1;   // only one digit allowed in a cell
                DGV.Columns.Add(imageCell);
                DGV.Columns[i].Name = i.ToString();
                DGV.Columns[i].Width = cColWidth;
                DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
                for (int j = 0; j < cMaxRow; j++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Height = cRowHeight;
                    row.DividerHeight = 2;
                    DGV.Rows.Add(row);

                }
            
            
            Controls.Add(DGV);

        }

        private void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            Brush Brs = new SolidBrush(Color.Blue);
            GraphicsExtensions.FillCircle(e.Graphics, Brs, e.CellBounds.Location.X + 5 , e.CellBounds.Location.Y + 5 , 5);
            e.Handled = true;

        }
    }
}
    

    public static class GraphicsExtensions
    {
        public static void FillCircle(this Graphics g, Brush brush, float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }
    }










