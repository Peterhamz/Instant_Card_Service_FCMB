﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace fcmb
{
    /// <summary>
    /// Interaction logic for Keypad.xaml
    /// </summary>
    public partial class Keypad : Window,INotifyPropertyChanged
    {
        #region Public Properties

        private string _result;
        private TextBox textbox;
        private withoutBVN withoutBVN;
        private CreateAccount createAccount;
        private cardRequest cardRequest;

        public string Result
    {
        get { return _result; }
        private set { _result = value; this.OnPropertyChanged("Result"); }
    }

    #endregion

    public Keypad(PasswordBox owner, Window wndOwner)
    {
        InitializeComponent();
        this.Owner = wndOwner;
        this.DataContext = this;
        Result = "";
    }

        public Keypad(TextBox owner, Window wndOwner)
        {
            InitializeComponent();
            this.Owner = wndOwner;
            this.DataContext = this;
            Result = "";
        }

        public Keypad(TextBox textbox, withoutBVN withoutBVN)
        {
            InitializeComponent();
            this.textbox = textbox;
            this.withoutBVN = withoutBVN;
            this.DataContext = this;
            Result = "";
        }

        public Keypad(TextBox textbox, CreateAccount createAccount)
        {
            InitializeComponent();
            this.textbox = textbox;
            this.createAccount = createAccount;
            this.DataContext = this;
            Result = "";
        }

       

        private void button_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        switch (button.CommandParameter.ToString())
        {
            case "ESC":
                this.DialogResult = false;
                break;

            case "RETURN":
                this.DialogResult = true;
                break;

            case "BACK":
                if (Result.Length > 0)
                    Result = Result.Remove(Result.Length - 1);
                break;

            default:
                Result += button.Content.ToString();
                break;
        }
    }

    #region INotifyPropertyChanged members

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }

    #endregion
}
}
