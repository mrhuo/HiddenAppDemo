using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HiddenApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.Visible = false;
            this.Width = 0;
            this.Height = 0;
            this.Left = -1000;
            this.Top = -1000;
            this.ControlBox = false;
            this.AutoSize = false;
            this.Opacity = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(10 * 1000);
                MessageBox.Show("我在后台执行哟...");
            })).Start();
        }
    }
}
