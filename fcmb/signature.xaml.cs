using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace fcmb
{
    /// <summary>
    /// Interaction logic for signature.xaml
    /// </summary>
    public partial class signature : Window
    {
        private Point _startPoint;
        private Polyline _line;

        public signature()
        {
            InitializeComponent();
        }

        private void saveSignature_Click(object sender, RoutedEventArgs e)
        {
            Canvas ck = new Canvas();
            try
            {
                var chk = _line.Stroke;

                Rect rect = new Rect(canvas.RenderSize);
                RenderTargetBitmap rtb = new RenderTargetBitmap(750, 700, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                rtb.Render(canvas);
                //endcode as PNG
                BitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

                //save to memory stream
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pngEncoder.Save(ms);

                var imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.StreamSource = ms;
                imageSource.EndInit();

                // Assign the Source property of your image
                System.Windows.Controls.Image win = UIHelper.FindChild<System.Windows.Controls.Image>(Application.Current.MainWindow, "sign");
                win.Source = imageSource;
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                msg.Content = "Please append your signature";

            }
        }

        private void canvas_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(canvas);
            _line = new Polyline();
            _line.Stroke = new SolidColorBrush(Colors.Black);
            _line.StrokeThickness = 2.0;

            canvas.Children.Add(_line);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPoint = e.GetPosition(canvas);
                if (_startPoint != currentPoint)
                {
                    _line.Points.Add(currentPoint);
                }
            }
        }

        private void dismiss_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image win = UIHelper.FindChild<System.Windows.Controls.Image>(Application.Current.MainWindow, "sign");
            win.Source = null;
            this.DialogResult = false;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
