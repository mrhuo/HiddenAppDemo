## DotnetXDemo ��Ŀ����

һֱ��дһЩ���� `.net` �߼�Ӧ�ÿ����Ĵ��룬ȴ������Ϊ������īˮ�ٱﲻ�������Ǿ���������ʲô��д��ʲô�ɡ�

### һ��`winform` ���

1��HiddenApp1

	��һ�� `winform` ��������ִ�У�����ִ�еķ�ʽ�кܶ��֣���һ�� `demo` ������򵥵ķ�ʽ��ʵ������ִ�С�

	`demo` ִ��ʱ��������ʾ�κδ��壬���ǹ�10�룬�ᵯ���Ի���֤�����������С�

	1) ���ճ���˼·���ڴ����ʼ�����֮�󣬵������������

	```
	public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //��Ҫ��ʾ��������
            this.ShowInTaskbar = false;
            //���ش���
            this.Visible = false;
            //�����ȵ���Ϊ0
            this.Width = 0;
            //����߶ȵ���Ϊ0
            this.Height = 0;
            //������������ó�-10000����֤����Ļ���
            this.Left = -10000;
            //����������ó�-10000����֤����Ļ���
            this.Top = -10000;
        }
    }
	```

    2) �� `Form1_Load` ������������һ���̣߳������Ի������ԡ�

    ```
    private void Form1_Load(object sender, EventArgs e)
    {
        new Thread(new ThreadStart(() =>
        {
            Thread.Sleep(10 * 1000);
            MessageBox.Show("���ں�ִ̨��Ӵ...");
        })).Start();
    }
    ```

    �����������ֻ�������ʾ��������ߺͶ����λ��û�����óɹ�����ͼ��

    3) ����һ�� `opacity`������͸���ȵ����ԣ����ó�0�����£�

    ```
    this.Opacity = 0;
    ```
    4) ���ھͺ��ˣ����������壬�ﵽ�����ص�Ŀ�ģ��򵥴ֱ������ǻ��պ�ʵ�á�

    > ����֮����������Ȼ�������ˣ���ֻ�ǵ�����͸���ȣ������е㲻ˬ���������Ǵ��ڵģ���

2��HiddenApp2

    ������һ�� `demo`�����Ǽ򵥵�ʵ����һ���������е�Ӧ�ó�����ô����ʲô��ʽ������ִ���أ�

    ϸ�ĵ�ͬѧ���֣������� `Program.cs` �ļ� `Main` ������������һ�� `new Form1()`����ô��ʲô�취�ܲ�ִ����һ�䣬Ӧ�ó����������أ�

    ���ǰ���һ��ע�͵������� `Application` ���ṩ��һ�� `Run` �����������κβ�������������ɾ��û�õ� `Form1` ������壬�Ѵ���ĳ���������ִ��һ�����ԡ�

    ```
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    //Application.Run(new Form1());
    Application.Run();
    ```

    prefect�������ճ��������У�����������п��Կ��� `HiddenApp2.exe` ������̣�Ҳ���÷������ش��壬���ֲ�Ϊ��

    PS: ĳЩ�뷨������ͬѧ�������뵽�����������ɵ㻵�£���ס�������ֻ֡������©��

    ��������һ�£�����ʵ������Ĺ��ܣ�10��󵯳�һ���Ի���֤������ȷʵ�����С�

    ```
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    //Application.Run(new Form1());
    new Thread(new ThreadStart(() =>
    {
        Thread.Sleep(10 * 1000);
        MessageBox.Show("���ں�ִ̨��Ӵ...");
    })).Start();
    Application.Run();
    ```

    ����ܼ򵥣���������һ���߳��ӳ�10��󵯴����е�ͬѧ����Ҫ���ˣ�Ϊɶ `new Thread` ������ `Application.Run()` ����֮����Ϊ `Application.Run()` ��ʹӦ�ó�������������ִ�У����Ժ���Ĵ��벻��ִ�С�

3��HiddenApp3��ClipboardTail��

    ��һ�������ʹ�õڶ�����ʹ�õķ�������һ�㻵�£�PS����ϲ��������һ�� `���а�β��` �����ǻᾭ���ĸ���ճ�������������㸴��ճ���������Һܸ���Ȥ��������

    ����Ч�����������㸴�Ƶ��ı�����׺�����úõ����֣�Ȼ��Ž����а塣
    
    PS: Ѹ�׵ļ��Ӽ��а壬���Ǽ����˼��а����Ƿ��� Html ��ʽ���ı������м���� URL��ʵ�����ء�

    winform ������ʹ�ü��а�ʹ�� `Clipboard` ����ܷ��࣬�����¶��壺

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

    ��һ����Ҫ��ʹ�� `public static string GetText();` �������������ȡ�û����е����ݣ���������׷��һ��β�������һ�¡�

    ԭ��ʹ�ú�̨�̣߳���ʱ�İѼ��а����ݸ���������Ȼ��׷��һЩ���֣���д�ؼ��а塣�ϻ�����˵��ֱ���Ϻ��Ĵ��룺

    ```
    var text = Clipboard.GetText();
    //��Ҫ����Ϊɶ���� String.IsNullOrEmpty()����Ϊ���õ� .Net Framework 3.5
    if (text != null && text.Length > 0)
    {
        if (!text.EndsWith(TAIL))
        {
            Clipboard.SetText(text + TAIL);
            Debug.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] successful catch text��{text}��changed to��{Clipboard.GetText()}��");
        }
    }
    ```

    ����̣ܶ����Ǻܶ�㣬��Ҫ�����ɻ��¡�

    #### ��Ȥ�����⣺

    ������Ĵ��룺

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

    �������а� `Clipboard.SetDataObject` �������Խ���һ�� `object` �������Һ����Ū��һ���ܴ�� `byte[]` ���˽�ȥ����������� `GetData()` �������ú��ڴ��������ȫ������ڴ�ը��������С��2���� `byte[]` ��С�ֽڣ���������һ���߳������ٴε��� `SetDataObject()` �������ü��а����ݣ������ڴ治���ͷš�

    ���˵�һ�� `GC.Collect();` ֮���ڴ�ήһ�룬�Ҳ��� `data` �������ͷţ����Ǽ��а�����û�ͷţ�2����С���ֽ�Ӧ���� `data` ����ռ�� 2G�����а�ռ�� 2G����ͼ��

    ������ִ�������δ���֮��

    ```
    Clipboard.SetDataObject(new MemoryStream(new byte[0]));
    data = Clipboard.GetDataObject()?.GetData(typeof(MemoryStream));
    ```
    ��Ȥ����ռ�õ�2G�ڴ棬�����ͷš�Ϊʲô����� `GetData` ��ʹ�ڴ����������һ�䲻��ʹ�ڴ��С�أ���ͼ��

    ������ִ�еڶ��� `GC.Collect();` ִ��֮���ڴ�ᱻ���գ����ǻ��Ǳ�����Ĵ���һЩ��û����ȫ�ͷš���ͼ��

    > ��˼���룺������ `Clipboard` ����һЩ�ڴ棬Ȼ�����ڴ���ִ��һЩ���룬�᲻���ϵͳ�����в���������Ĵ�ţ���Գ���һ�¡�

    �������룺

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
            /// Ӧ�ó��������ڵ㡣
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

            private const string TAIL = "����Ҫ��ע�������߾�ѡ��Ѷ�����ں�";
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
                                    Debug.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] successful catch text��{text}��changed to��{Clipboard.GetText()}��");
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