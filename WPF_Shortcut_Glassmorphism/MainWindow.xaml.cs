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

namespace WPF_Shortcut_Glassmorphism
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Height = SystemParameters.PrimaryScreenHeight;
            Width = SystemParameters.PrimaryScreenWidth * 0.2;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;

            InitializeComponent();

            var foregroundWindow = new ForegroundWindow();
            this.Topmost = true;

            this.IsVisibleChanged += (s, e) =>
            {
                if (((bool)e.NewValue) == true && foregroundWindow.Owner == null)
                {
                    foregroundWindow.Owner = this;
                    foregroundWindow.Show();
                }      
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new WindowBlurEffect(this);
        }
    }
}
