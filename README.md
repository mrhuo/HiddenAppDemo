群里有个同学问了问题 `如何隐藏运行 winform 程序？`，提起了我的兴趣，玩玩呗？那就玩玩吧！

1、HiddenApp1，第一版

将一个 `winform` 程序隐藏执行，隐藏执行的方式有很多种，第一个 `demo` 就用最简单的方式，实现隐藏执行。

`demo` 执行时，不会显示任何窗体，但是过10秒，会弹出对话框证明程序在运行。

1) 按照常规思路，在窗体初始化完成之后，调整窗体参数。

```
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        //不要显示在任务栏
        this.ShowInTaskbar = false;
        //隐藏窗体
        this.Visible = false;
        //窗体宽度调整为0
        this.Width = 0;
        //窗体高度调整为0
        this.Height = 0;
        //窗体最左边设置成-10000，保证在屏幕外边
        this.Left = -10000;
        //窗体最顶部设置成-10000，保证在屏幕外边
        this.Top = -10000;
    }
}
```

2) 在 `Form1_Load` 方法里新启动一个线程，弹出对话框试试。

```
private void Form1_Load(object sender, EventArgs e)
{
    new Thread(new ThreadStart(() =>
    {
        Thread.Sleep(10 * 1000);
        MessageBox.Show("我在后台执行哟...");
    })).Start();
}
```

运行起来发现还是有显示，而且左边和顶变的位置没有设置成功。如图：

![](https://mmbiz.qpic.cn/mmbiz_png/aClMHOpCiag8Siabd4czFxCrn57SWO83X0JkWrLZf7kjXvh00nI1xOzxtWSLDpSpjfXJl9HocqlYv5oZypGOrIhQ/640?wx_fmt=png&tp=webp&wxfrom=5&wx_lazy=1&wx_co=1)

3) 还有一个 `opacity`，窗体透明度的属性，设置成0。如下：

```
this.Opacity = 0;
```
4) 现在就好了，看不见窗体，达到了隐藏的目的，简单粗暴，但是还凑合实用。

![](https://mmbiz.qpic.cn/mmbiz_png/aClMHOpCiag8Siabd4czFxCrn57SWO83X0nAnM8M4V0Rd9R75bqBWTBCLwdgheibDcXFaPkRAJAhT0CT20UwUTNzg/640?wx_fmt=png&tp=webp&wxfrom=5&wx_lazy=1&wx_co=1)

> 不足之处：窗体虽然是隐藏了，但只是调整了透明度（心里有点不爽，明明它是存在的）。

2、HiddenApp2，第二版

经过第一个 `demo`，我们简单的实现了一个隐藏运行的应用程序，那么还有什么方式能隐藏执行呢？

细心的同学发现，这里在 `Program.cs` 文件 `Main` 方法中运行了一个 `new Form1()`，那么有什么办法能不执行这一句，应用程序还能运行呢？

我们把这一句注释掉，看到 `Application` 类提供了一个 `Run` 方法，不带任何参数。我们试着删掉没用的 `Form1` 这个窗体，把代码改成下面这样执行一下试试。

```
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);
//Application.Run(new Form1());
Application.Run();
```

prefect！程序照常可以运行，任务管理器中可以看到 `HiddenApp2.exe` 这个进程，也不用费心隐藏窗体，何乐不为？

PS: 某些想法不良的同学，可能想到了隐藏起来干点坏事，记住：法网恢恢、疏而不漏！

再来改造一下，让他实现上面的功能，10秒后弹出一个对话框，证明程序确实在运行。

```
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);
//Application.Run(new Form1());
new Thread(new ThreadStart(() =>
{
    Thread.Sleep(10 * 1000);
    MessageBox.Show("我在后台执行哟...");
})).Start();
Application.Run();
```

代码很简单，就是启动一个线程延迟10秒后弹窗，有的同学可能要问了，为啥 `new Thread` 不放在 `Application.Run()` 方法之后？因为 `Application.Run()` 会使应用程序主进程阻塞执行，所以后面的代码不会执行。

3、HiddenApp3（剪切板尾巴：ClipboardTail）

这一节里，我们使用第二步里使用的方法来干一点坏事（PS：我喜欢），做一个 `剪切板尾巴` ，我们会经常的复制粘贴东西，但是你复制粘贴的内容我很感兴趣，哈哈。

最终效果：他会在你复制的文本后面缀上设置好的文字，然后放进剪切板。
    
PS: 迅雷的监视剪切板，就是监视了剪切板中是否有 Html 格式的文本，从中间解析 URL，实现下载。

winform 开发里使用剪切板使用 `Clipboard` 这个密封类，来看下定义：

```
namespace System.Windows.Forms
{
    public sealed class Clipboard
    {
        public static void Clear();
        public static bool ContainsAudio();
        public static bool ContainsData(string format);
        public static bool ContainsFileDropList();
        public static bool ContainsImage();
        public static bool ContainsText(TextDataFormat format);
        public static bool ContainsText();
        public static Stream GetAudioStream();
        public static object GetData(string format);
        public static IDataObject GetDataObject();
        public static StringCollection GetFileDropList();
        public static Image GetImage();
        public static string GetText();
        public static string GetText(TextDataFormat format);
        public static void SetAudio(Stream audioStream);
        public static void SetAudio(byte[] audioBytes);
        public static void SetData(string format, object data);
        public static void SetDataObject(object data);
        public static void SetDataObject(object data, bool copy, int retryTimes, int retryDelay);
        public static void SetDataObject(object data, bool copy);
        public static void SetFileDropList(StringCollection filePaths);
        public static void SetImage(Image image);
        public static void SetText(string text);
        public static void SetText(string text, TextDataFormat format);
    }
}

```

这一节主要是使用 `public static string GetText();` 这个方法，来盗取用户剪切的内容，并在其后边追加一个尾巴来恶搞一下。

原理：使用后台线程，定时的把剪切板内容复制下来，然后追加一些文字，再写回剪切板。废话不多说，直接上核心代码：

```
var text = Clipboard.GetText();
//不要问我为啥不用 String.IsNullOrEmpty()，因为我用的 .Net Framework 3.5
if (text != null && text.Length > 0)
{
    if (!text.EndsWith(TAIL))
    {
        Clipboard.SetText(text + TAIL);
        Debug.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] successful catch text【{text}】changed to【{Clipboard.GetText()}】");
    }
}
```

代码很短，但是很恶搞，不要拿来干坏事。

#### 有趣的问题：

看下面的代码：

```
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
        Clipboard.SetDataObject(new MemoryStream(new byte[0]));
        data = Clipboard.GetDataObject()?.GetData(typeof(MemoryStream));
        //2
        data = null;
        GC.Collect();
    }));
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
}
```

看到剪切板 `Clipboard.SetDataObject` 方法可以接受一个 `object` 参数，我好奇的弄了一个很大的 `byte[]` 放了进去，结果发现在 `GetData()` 方法调用后内存剧增（完全算得上内存炸弹），大小是2倍的 `byte[]` 大小字节，我又重启一个线程来，再次调用 `SetDataObject()` 方法设置剪切板内容，发现内存不会释放。

加了第一个 `GC.Collect();` 之后，内存会降一半，我猜想 `data` 变量被释放，但是剪切板内容没释放，2倍大小的字节应该是 `data` 变量占用 2G，剪切板占用 2G。如图：

![刚启动](https://mmbiz.qpic.cn/mmbiz_png/aClMHOpCiag8Siabd4czFxCrn57SWO83X0pBtYHwKWUS0L62S7IQcaMwEfXkAJapk1xHhkicTa1Lgq93sUtfYm54w/640?wx_fmt=png&tp=webp&wxfrom=5&wx_lazy=1&wx_co=1)

![GC.Collect();](https://mmbiz.qpic.cn/mmbiz_png/aClMHOpCiag8Siabd4czFxCrn57SWO83X0GdcUI01H0fXso8luOwcEY6MAj7yZXwEYYgdkz8dnia0Majsm5pG7Kkw/640?wx_fmt=png&tp=webp&wxfrom=5&wx_lazy=1&wx_co=1)

紧接着执行完毕这段代码之后：

```
Clipboard.SetDataObject(new MemoryStream(new byte[0]));
data = Clipboard.GetDataObject()?.GetData(typeof(MemoryStream));
```
有趣的是占用的2G内存，不会释放。为什么上面的 `GetData` 会使内存剧增，而这一句不会使内存变小呢？如图：

![](https://mmbiz.qpic.cn/mmbiz_png/aClMHOpCiag8Siabd4czFxCrn57SWO83X0hFKg5kl9MZELwsGGDQtQaKQtuz0vU1aoHMRPMweZgbPGo1OWYOYyLQ/640?wx_fmt=png&tp=webp&wxfrom=5&wx_lazy=1&wx_co=1)

紧接着执行第二个 `GC.Collect();` 执行之后，内存会被回收，但是还是比最初的大了一些，没有完全释放。如图：

![](https://mmbiz.qpic.cn/mmbiz_png/aClMHOpCiag8Siabd4czFxCrn57SWO83X0oeCM8IXr12JgwTGwKCxOjkvttXecQdD38kWdIAM9VnQcCL2RicKktiaw/640?wx_fmt=png&tp=webp&wxfrom=5&wx_lazy=1&wx_co=1)

> 奇思妙想：可以用 `Clipboard` 申请一些内存，然后在内存中执行一些代码，会不会对系统造成威胁？有能力的大牛可以尝试一下。

完整代码：

```
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
```
