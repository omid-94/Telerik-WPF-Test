using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;



namespace TelerikWpfApp1.Windows
{
    public partial class VLCPlayer : Window
    {
        Window window;
        IntPtr VLC_hWnd;
        string VLC_Path = "";
        string Video_Path = "";
        ProcessStartInfo psi;
        Process process;
        public VLCPlayer()
        {
            InitializeComponent();
            window= Window.GetWindow(this);


            SizeChanged += new SizeChangedEventHandler((obj, evargs) =>
            {
                WindowSizeChanged();
            });
            this.Closing += Window_Closing;
        }

        private IntPtr Get_hWnd()
        {
            IntPtr hWnd = new WindowInteropHelper(window).EnsureHandle();
            return hWnd;
        }

        private void prepare()
        {
            //VLC_Path = System.Configuration.ConfigurationManager.AppSettings["VLC_Path"].ToString();
            //if(string.IsNullOrEmpty(value))
            //{
            //    var dlg = new OpenFileDialog();
            //    dlg.DefaultExt = "vlc.exe";
            //    dlg.Filter = "VLC (vlc.exe)|vlc.exe|" +
            //        "Shortcut (*.lnk)|*.lnk";

            //    var result = dlg.ShowDialog();
            //    if (result == System.Windows.Forms.DialogResult.OK)
            //    {
            //        Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //        VLC_Path = dlg.FileName;
            //        configuration.AppSettings.Settings["VLC_Path"].Value = VLC_Path;
            //        configuration.Save(ConfigurationSaveMode.Full, true);
            //        ConfigurationManager.RefreshSection("appSettings");
            //    }
            //}

            PrepareVideoPath();
            psi = new ProcessStartInfo();
            psi.FileName = "vlc";
            psi.Arguments = Video_Path;
            psi.WindowStyle = ProcessWindowStyle.Minimized;
            process = Process.Start(psi);
            Thread.Sleep(500);
            VLC_hWnd = process.MainWindowHandle;
            SetParent(VLC_hWnd, Get_hWnd());
            WindowSizeChanged();
        }

        public void Play()
        {
            prepare();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            const int WM_CLOSE = 0x0010;
            SendMessage(VLC_hWnd, WM_CLOSE, 0, 0);
            process.Kill();
        }

        private void PrepareVideoPath()
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            Video_Path = string.Format("\"{0}Resources\\Video\\My.Country.teaser1.mp4\"", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
        }

        private void WindowSizeChanged()
        {
            psi.WindowStyle = ProcessWindowStyle.Normal;


            int width = (int)(window.Width > window.ActualWidth ? window.Width : window.ActualWidth);
            int height = (int)(window.Height > window.ActualHeight ? window.Height : window.ActualHeight);

            bool ret = MoveWindow(VLC_hWnd, 0, 0, (int)(width * 1.23), (int)(height * 1.18), true);
            //psi.WindowStyle= ProcessWindowStyle.Normal;
            //const int SW_MAXIMIZE = 3;
            //ShowWindow(VLC_hWnd, SW_MAXIMIZE);
            //psi.WindowStyle = ProcessWindowStyle.Maximized;
        }


        #region Extern calls
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string strClassName, IntPtr nptWindowName);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        //EnumWindows(new EnumWindowsProc(Report), IntPtr.Zero);
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        private EnumWindowsProc callBackPtr;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);



        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);




        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        #endregion
    }


}
