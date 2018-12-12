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
    public partial class Text : Form
    {
        public Text( string title,string text)
        {
            InitializeComponent();
            this.Text = title;
            textBox1.Text = text;
            //textBox1.Text = textBox1.Text.Trim(Environment.NewLine);
        }
    }
}
