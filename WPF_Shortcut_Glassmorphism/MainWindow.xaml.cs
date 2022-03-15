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

            List<Shortcut> shortcuts = new();

            Shortcuts(shortcuts);

            ColumnDefinition column = new();
            ShortcutGrid.ColumnDefinitions.Add(column);
            int i = 0;
            foreach (var s in shortcuts)
            {
                RowDefinition row = new();
                ShortcutGrid.RowDefinitions.Add(row);


                Frame frame = new();
                frame.Height = SystemParameters.PrimaryScreenHeight * 0.11;
                frame.Width = SystemParameters.PrimaryScreenWidth * 0.15;
                frame.Background = Brushes.White;
                frame.Content = new StackPanel
                {

                    Children =
                        {
                            new Label
                            {
                                Content = s.Command,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                //LineBreakMode = LineBreakMode.WordWrap,
                            },
                            new Line
                            {
                                Height = 2,
                                Width= SystemParameters.PrimaryScreenWidth * 0.20,
                            },
                            new Label
                            {
                                Content = s.Description,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                //LineBreakMode = LineBreakMode.WordWrap,
                                //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                                Foreground = Brushes.Orange,
                            }
                        },
                };
                    ShortcutGrid.Children.Add(frame);
                Grid.SetColumn(frame, 0);
                Grid.SetRow(frame, i);
                i++;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new WindowBlurEffect(this);
        }
        public void Shortcuts(List<Shortcut> shortcuts)
        {
            shortcuts.Add(new Shortcut("Ctrl + C", "Copy"));
            shortcuts.Add(new Shortcut("Ctrl + V", "Paste"));
            shortcuts.Add(new Shortcut("Ctrl + X", "Cut"));
        }
    }
}
