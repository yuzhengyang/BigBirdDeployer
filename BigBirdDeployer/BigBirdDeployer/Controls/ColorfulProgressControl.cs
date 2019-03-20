using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BigBirdDeployer.Controls
{
    public partial class ColorfulProgressControl : UserControl
    {
        public ColorfulProgressControl()
        {
            InitializeComponent();
        }
        public void SetValue(int value)
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;

            int width = (PnMain.Width * value) / 100;
            PnProgress.Width = width;

            SetColor(value);
        }
        private void SetColor(int value)
        {
            Color bg = Color.White;
            Color pg = Color.Black;
            if (value > 0 && value <= 20) { pg = ColorTranslator.FromHtml("#00FF00"); }
            if (value > 20 && value <= 40) { pg = ColorTranslator.FromHtml("#CCFF00"); }
            if (value > 40 && value <= 60) { pg = ColorTranslator.FromHtml("#FFFF00"); }
            if (value > 60 && value <= 80) { pg = ColorTranslator.FromHtml("#FF6600"); }
            if (value > 80 && value <= 100) { pg = ColorTranslator.FromHtml("#FF0000"); }
            PnMain.BackColor = bg;
            PnProgress.BackColor = pg;
        }
    }
}
