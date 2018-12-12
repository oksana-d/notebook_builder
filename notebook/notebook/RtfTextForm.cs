using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace notebook
{
    public partial class RtfTextForm : Form
    {
        public RtfTextForm(string rtftext)
        {
            InitializeComponent();
            textBox1.Text = rtftext;
        }
    }
}
