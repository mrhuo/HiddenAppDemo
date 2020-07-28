using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace HiddenApp2
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(10 * 1000);
                MessageBox.Show("我在后台执行哟...");
            })).Start();
            Application.Run();
        }
    }
}
