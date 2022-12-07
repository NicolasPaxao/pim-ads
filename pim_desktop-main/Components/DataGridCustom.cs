using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_desktop.Components
{
    public class DataGridCustom : DataGridView
    {
        public string EmptyResultText { get; set; }

        public DataGridCustom()
        {
            this.Paint += DataGridCustom_Paint;
        }

        private void DataGridCustom_Paint(object sender, PaintEventArgs e)
        {
            if (!string.IsNullOrEmpty(EmptyResultText))
            {
                if (this.Rows.Count == 0)
                {
                    using (var gfx = e.Graphics)
                    {
                        gfx.DrawString(this.EmptyResultText, this.Font, Brushes.Black,
                            new PointF((this.Width - this.Font.Size * EmptyResultText.Length) / 2, this.Height / 2));
                    }
                }
            }
        }
    }
}
