using Dermalog.Afis.ImageContainer;
using Dermalog.Afis.NistQualityCheck;
using Dermalog.Imaging.Capturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace fcmb
{
    /// <summary>
    /// Interaction logic for cardRequest.xaml
    /// </summary>
    public partial class cardRequest : Window
    {
        #region Private Variables And Delegate

        private Device _capDevice;

        private bool _isDeviceError = false;

        PictureBox picBox, picBox1;

        int i = 0;

        delegate void SetContaminationLevel(int value);
       
        public data result { get; set; }

        #endregion

        #region Constructors
        public cardRequest()
        {
            InitializeComponent();

            // Create the interop host control.
            System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();

            // Create the PictureBox control.
            picBox = new PictureBox();
            picBox.Width = 350;
            picBox.Height = 300;
            // Assign the MaskedTextBox control as the host control's child.
            ima.Child = picBox;

            // Add the interop host control to the Grid
            // control's collection of child controls.
            //this.grid1.Children.Add(host);

            // Create the PictureBox control.
            picBox1 = new PictureBox();
            picBox1.Width = 350;
            picBox1.Height = 300;
            // Assign the MaskedTextBox control as the host control's child.
          //  ima1.Child = picBox1;

            // Add the interop host control to the Grid
            // control's collection of child controls.
            this.grid1.Children.Add(host);

        }

        #endregion

        #region accountNumber
        private void AccountNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!accountNumber.IsKeyboardFocused)
            {
                Keyboard.Focus(accountNumber);
            }
        }

        private void AccountNumber_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!accountNumber.IsKeyboardFocused)
            {
                Keyboard.Focus(accountNumber);
            }
        }
        #endregion

        #region Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessFingerPrint();
            }
            catch (Exception ex)
            {
                mess.Text = ex.Message;
                mess.Foreground = Brushes.Red;
            }
        }
        #endregion

        #region UI Events

        /// <summary>
        /// Event handler to dismiss the current operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UnbindEvents();
                _capDevice.Stop();
                CloseDevice();
            }
            catch (Exception)
            {
            }

            this.DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// Event handler to drag the window from any point 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Event handler to drag the window from the draggable image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Event handler that fires when FingerPrint device is stopped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _capDevice_OnStop(object sender, DeviceEventBaseArgs e)
        {
            try
            {
                mess.Text = _capDevice.DeviceID + " stopped";
                mess.Foreground = Brushes.Blue;
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        /// <summary>
        /// Evnt handler that fires when there's a warning from the FingerPrint device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _capDevice_OnWarning(object sender, WarningEventArgs e)
        {
            try
            {
                mess.Text = _capDevice.DeviceID + " throws the warning - " + e.Warning;
                mess.Foreground = Brushes.Blue;
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        /// <summary>
        /// Event handler that fires when the fingerprint device encounters an error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _capDevice_OnError(object sender, Dermalog.Imaging.Capturing.ErrorEventArgs e)
        {
            try
            {
                showError("The " + _capDevice.DeviceID + " has encountered this error - " + e.Error);
                MethodInvoker method = () => CloseDevice();
                System.Windows.Application.Current.Dispatcher.BeginInvoke(method);
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        /// <summary>
        /// Event handler that fires when a finger is detected on the finger print device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _capDevice_OnDeviceEvent(object sender, DeviceEventArgs e)
        {
            try
            {
                showError("Event Unhandled");
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        private void showError(string err)
        {
            unavailable jj = new unavailable(err);
            jj.ShowDialog();
        }

        /// <summary>
        /// Event handler that fires when a finger is detected on the finger print device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _capDevice_OnDetect(object sender, DetectEventArgs e)
        {
            DateTime before = DateTime.Now;
            _capDevice.Property[PropertyType.FG_GREEN_LED] = 1;
            //_capDevice.Property[PropertyType.FG_LOW_CONTRAST_IMG] = 1;
            try
            {
                if (this._capDevice.CaptureMode == Dermalog.Imaging.Capturing.CaptureMode.ROLLED_FINGER)
                {
                    LifenessInfo_1 lfInfoRollTest = (LifenessInfo_1)this._capDevice.GetCurrentFrameInfo(FrameInfoTypes.E_LIFENESS_INFO_1);

                    if (lfInfoRollTest.State == 0)
                    {
                        mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                           new Action(
                               delegate ()
                               {
                                   mess.Text = "Rolled finger Ok!";
                                   mess.Foreground = Brushes.Green;
                               }
                           ));
                    }
                    else
                    {
                        mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                           new Action(
                               delegate ()
                               {
                                   mess.Foreground = Brushes.Red;
                                   mess.Text = "Rolled finger failed! Errorcode: " + lfInfoRollTest.State + ".";
                               }
                           ));
                    }
                }
                //check Fake/Live detection is enabled
                if (_capDevice.Property.ContainsKey(PropertyType.FG_FAKE_DETECT) && this._capDevice.Property[PropertyType.FG_FAKE_DETECT] > 0)
                {
                    //Get frame information to check the Liveness or Fake
                    LifenessInfo_1 lfInfo = (LifenessInfo_1)this._capDevice.GetCurrentFrameInfo(FrameInfoTypes.E_LIFENESS_INFO_1);
                    System.Diagnostics.Trace.WriteLine(string.Format("Possible Fake Finger score {0} ", Math.Round(lfInfo.Score, 2)), "Information");
                    mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                       new Action(
                           delegate ()
                           {
                               mess.Text = "Frame info state: " + lfInfo.State;
                           }
                       ));
                    //Possible Fake Finger
                    if (lfInfo.Score < 50)
                    {
                        mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                        new Action(
                            delegate ()
                            {
                                mess.Foreground = Brushes.Red;
                                mess.Text = string.Format("Possible Fake Finger score {0} ", Math.Round(lfInfo.Score, 2));
                            }
                        ));
                        picBox1.Image = null;
                    }
                    else
                    {
                        mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                        new Action(
                            delegate ()
                            {
                                mess.Foreground = Brushes.Green;
                                mess.Text = string.Format("Real Finger score {0} ", Math.Round(lfInfo.Score, 2));
                            }
                        ));
                    }
                }
            }
            catch (DeviceException ex)
            {
                showError(ex.Message);
                System.Diagnostics.Trace.WriteLine(ex.ToString(), "Warning");
            }
            finally
            {
                Dermalog.Afis.ImageContainer.Decoder decoder = new Dermalog.Afis.ImageContainer.Decoder();
                int nNFIQ2Value = -1;

                using (RawImage rawImage = decoder.Decode(e.ImageData))
                {
                    nNFIQ2Value = DermalogNistQualityCheck.CheckNfiq2(rawImage);
                }

                if (nNFIQ2Value >= 55)
                {
                    if (nNFIQ2Value > i)
                    {
                        picBox1.Image = e.Image;
                        _capDevice.Property[PropertyType.FG_RED_LED] = 0;
                        mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                            new Action(
                                delegate ()
                                {
                                    //mess.Text = string.Format("Finger detection done in {0} ms", (DateTime.Now - before).Milliseconds) + " Information. Image Quality -" + nNFIQ2Value;
                                    mess.Text = string.Format("Finger detection done in {0} ms", (DateTime.Now - before).Milliseconds) + ". Image Quality -" + nNFIQ2Value;
                                    mess.Foreground = Brushes.Green;
                                    @continue.Visibility = Visibility.Visible;
                                }
                            ));
                        i = nNFIQ2Value;
                    }
                }
                else
                {
                    _capDevice.Property[PropertyType.FG_RED_LED] = 1;
                    //if an image that hasn't met the requirements is gotten, display the low quality values
                    if (picBox1.Image == null)
                    {
                        mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                            new Action(
                                delegate ()
                                {
                                    mess.Text = string.Format("Finger detection done in {0} ms", (DateTime.Now - before).Milliseconds) + ". Image Quality -" + nNFIQ2Value;
                                    mess.Foreground = Brushes.Red;
                                }
                            ));
                    }
                }

                System.Diagnostics.Trace.WriteLine(string.Format("Finger detection done in {0} ms", (DateTime.Now - before).Milliseconds), "Information");
            }
        }

        /// <summary>
        /// Event handler that fires when a finger image is detected on the finger print device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _capDevice_OnImage(object sender, ImageEventArgs e)
        {
            try
            {
                _capDevice.Property[PropertyType.FG_RED_LED] = 1;
                _capDevice.Property[PropertyType.FG_GREEN_LED] = 0;
                picBox.Image = e.Image;

                if (IsContaminationSupported)
                {
                    MethodInvoker conatMon = new MethodInvoker(ContaminationMonitor);
                    conatMon.BeginInvoke(null, null);
                }
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        /// <summary>
        /// Event handler that fires when the finger print device mis started
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _capDevice_OnStart(object sender, DeviceEventBaseArgs e)
        {
            try
            {
                if (_capDevice != null)
                {
                    mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                      new Action(
                        delegate ()
                        {
                            mess.Text = string.Format("Device {0} started. ", _capDevice.DeviceID);
                            mess.Foreground = Brushes.Green;
                        }
                    ));

                    try
                    {
                        mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                          new Action(
                            delegate ()
                            {
                                mess.Text += "Contamination Level - " + Convert.ToInt32(_capDevice.Contamination).ToString();
                                mess.Foreground = Brushes.Green;
                            }
                        ));
                    }
                    catch (Exception)
                    {
                        System.Diagnostics.Trace.WriteLine("Not all Live Scanners support Contamination function", "Warning");
                    }
                }
                else
                {
                    mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                        new Action(
                            delegate ()
                            {
                                mess.Text = "Please Ensure FingerPrint Device is properly connected";
                                mess.Foreground = Brushes.Red;
                            }
                        ));

                }
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }

        }
        #endregion

        #region Functions

        /// <summary>
        /// registers all event handlers
        /// </summary>
        private void BindEvents()
        {
            _capDevice.OnStart += new OnStart(_capDevice_OnStart);
            _capDevice.OnImage += new OnImage(_capDevice_OnImage);
            _capDevice.OnDetect += new OnDetect(_capDevice_OnDetect);
            _capDevice.OnDeviceEvent += new DeviceEvent(_capDevice_OnDeviceEvent);
            _capDevice.OnError += new OnError(_capDevice_OnError);
            _capDevice.OnWarning += new OnWarning(_capDevice_OnWarning);
            _capDevice.OnStop += new OnStop(_capDevice_OnStop);
        }

        /// <summary>
        /// deregisters all event handlers
        /// </summary>
        private void UnbindEvents()
        {
            _capDevice.OnStart -= new OnStart(_capDevice_OnStart);
            _capDevice.OnImage -= new OnImage(_capDevice_OnImage);
            _capDevice.OnDetect -= new OnDetect(_capDevice_OnDetect);
            _capDevice.OnDeviceEvent -= new DeviceEvent(_capDevice_OnDeviceEvent);
            _capDevice.OnError -= new OnError(_capDevice_OnError);
            _capDevice.OnWarning -= new OnWarning(_capDevice_OnWarning);
            _capDevice.OnStop -= new OnStop(_capDevice_OnStop);
        }

        /// <summary>
        /// checks the level of dirt on device
        /// </summary>
        private void ContaminationMonitor()
        {
            try
            {
                if (_capDevice == null && !_capDevice.IsCapturing)
                {
                    return;
                }
                SetContaminationValue(Convert.ToInt32(_capDevice.Contamination));
            }
            catch (Exception ex)
            {
                mess.Text = ex.Message;
                mess.Foreground = Brushes.Red;
            }
        }

        /// <summary>
        /// sets the leve of device contamination
        /// </summary>
        /// <param name="value"></param>
        private void SetContaminationValue(int value)
        {
            try
            {
                mess.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                        new Action(
                            delegate ()
                            {
                                //mess.Text = string.Format("Contamination Level = {0}", value);
                            }
                        ));

                if (value >= 25)
                {
                    mess.Foreground = Brushes.Red;
                }
                else
                {
                    mess.Foreground = Brushes.Green;
                }
            }
            catch (Exception)
            {

            }
        }

        bool IsContaminationSupported
        {
            get
            {
                if (_capDevice != null)
                {
                    return (_capDevice.DeviceID == DeviceIdentity.FG_ZF1);
                }

                return false;
            }
        }

        /// <summary>
        /// starts the fingerprint device
        /// </summary>
        private void ProcessFingerPrint()
        {
            try
            {
                CloseDevice();

                var devices = DeviceManager.GetAvailableDevices();
                _capDevice = DeviceManager.GetDevice(devices.ElementAt(5));

                _capDevice.CaptureMode = Dermalog.Imaging.Capturing.CaptureMode.PREVIEW_IMAGE_AUTO_DETECT;

                BindEvents();

                _capDevice.Start();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The function failed because the scanner connection could not be established"))
                {
                    showError("FingerPrint device Undetected.");
                    this.Close();
                }
                else
                {
                    showError(ex.Message);
                }
            }
        }

        /// <summary>
        /// closes the fingerprint device
        /// </summary>
        private void CloseDevice()
        {
            if (_capDevice != null)
            {
                if (_capDevice.IsCapturing)
                {
                    _capDevice.Stop();
                }
                UnbindEvents();
                _capDevice.Dispose();
                _capDevice = null;
            }
        }

       
        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UnbindEvents();
                _capDevice.Stop();
                CloseDevice();
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                showError(ex.Message);
            }
        }

        #endregion

        #region Helpers
        #endregion

        private void AccountNumber_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

    }

}
