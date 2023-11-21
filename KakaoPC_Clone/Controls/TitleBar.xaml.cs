using CommunityToolkit.Mvvm.ComponentModel;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLib.Extensions;

namespace KakaoPC_Clone.Controls
{
    [ObservableObject]
    public partial class TitleBar : UserControl
    {
        private Window? _parentWindow;
        private WindowState _winState;
        public Window ParentWindow
        {
            get
            {
                if (_parentWindow == null)
                {
                    _parentWindow = this.FindParent<Window>()!;
                }
                return _parentWindow;
            }
            set { _parentWindow = value; }
        }

       

        public WindowState WinState
        {
            get { return _winState; }
            set { SetProperty(ref _winState, value); }
        }


        public TitleBar()
        {
            InitializeComponent();

            btnExit.Click += BtnExit_Click;
            btnMaximize.Click += btnMaximize_Click;
            btnMinimize.Click += btnMinimize_Click;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WinState = WindowState.Minimized;
            ParentWindow.WindowState=WinState;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            WinState = ParentWindow.WindowState == WindowState.Maximized 
                ? WindowState.Normal 
                : WindowState.Maximized;
            ParentWindow.WindowState=WinState;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.FindParent<Window>()!.Close();
        }
    }
}
