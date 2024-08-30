using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPFTabTip;

namespace fcmb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer, timer1, netTimer, countTimer; public int i = 0, j = 0, k = 0, l = 0;
        public MainWindow()
        {
            InitializeComponent();

            InkInputHelper.DisableWPFTabletSupport();

            TabTipAutomation.IgnoreHardwareKeyboard = HardwareKeyboardIgnoreOptions.IgnoreIfSingleInstance;
            TabTipAutomation.BindTo<TextBox>();
            TabTipAutomation.BindTo<RichTextBox>();
            TabTipAutomation.BindTo<PasswordBox>();
            TabTipAutomation.ExceptionCatched += TabTipAutomation_ExceptionCatched;
        }

        void bgvideo_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            unavailable un = new unavailable(e.ErrorException.Message);
            un.ShowDialog();
        }

        void TabTipAutomation_ExceptionCatched(Exception obj)
        {
            unavailable un = new unavailable(obj.Message);
            un.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /** try
             {
                 var hwndSource = PresentationSource.FromVisual(this) as HwndSource;
                 var hwndTarget = hwndSource.CompositionTarget;
                 hwndTarget.RenderMode = RenderMode.SoftwareOnly;
             }
             catch (Exception ex)
             {
                 unavailable ns = new unavailable(ex.Message);
                 ns.ShowDialog();
             }*/

            try
            {
                bgvideo.LoadedBehavior = MediaState.Manual;
                bgvideo.UnloadedBehavior = MediaState.Manual;
                bgvideo.Source = new Uri("Contents/AWorldOfOpportunities.mp4", UriKind.Relative);
                bgvideo.Play();

                var hwndSource = PresentationSource.FromVisual(this) as HwndSource;
                var hwndTarget = hwndSource.CompositionTarget;
                hwndTarget.RenderMode = RenderMode.SoftwareOnly;
            }
            catch (Exception ex)
            {
                unavailable ns = new unavailable(ex.Message);
                ns.ShowDialog();
            }

            i = 5; j = 46; k = 10;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer1_Tick;
            timer.Start();
        }


        void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                j = --j;
                if (j == 0)
                {
                    bgvideo.LoadedBehavior = MediaState.Manual;
                    bgvideo.UnloadedBehavior = MediaState.Manual;
                    bgvideo.Source = new Uri("Contents/AWorldOfOpportunities.mp4", UriKind.Relative);
                    bgvideo.Play();
                    j = 46;
                }
            }
            catch (Exception ex)
            {
                unavailable jj = new unavailable("Video - " + ex.Message);
                jj.ShowDialog();
            }
        }

    }
}
