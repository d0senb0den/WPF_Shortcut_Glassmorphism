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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Shortcut_Glassmorphism
{
    /// <summary>
    /// Interaction logic for ForegroundWindow.xaml
    /// </summary>
    public partial class ForegroundWindow : Window
    {
        public ForegroundWindow()
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Height = SystemParameters.PrimaryScreenHeight;
            Width = SystemParameters.PrimaryScreenWidth * 0.2;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;

            InitializeComponent();
            this.Topmost = true;
            List<Shortcut> shortcuts = new();

            Shortcuts(shortcuts);

            ColumnDefinition column = new();
            ShortcutGrid.ColumnDefinitions.Add(column);
            int i = 0;
            ShortcutGrid.Margin = new Thickness(50, 100, 0, 0);
            foreach (var s in shortcuts)
            {
                RowDefinition row = new();
                row.Height = GridLength.Auto;
                ShortcutGrid.RowDefinitions.Add(row);


                Border border = new();
                border.Height = SystemParameters.PrimaryScreenHeight * 0.11;
                border.Width = SystemParameters.PrimaryScreenWidth * 0.15;
                border.Background = Brushes.White;
                border.Margin = new Thickness(0, 5, 0, 5);
                //border.BorderBrush = Brushes.Gray;
                //border.BorderThickness = new Thickness(0, 0, 0.5, 0.5);
                border.CornerRadius = new CornerRadius(5);
                border.Effect = new DropShadowEffect() { ShadowDepth = 1, Opacity = 0.5 };
                border.Child = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Children =
                        {
                            new Border() { Child =
                            new Label
                            {
                                Content = s.Command,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                //LineBreakMode = LineBreakMode.WordWrap,
                            },
                            BorderBrush = Brushes.Gray,
                            BorderThickness = new Thickness(1,1, 1, 1),
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
    ShortcutGrid.Children.Add(border);
                Grid.SetColumn(border, 0);
                Grid.SetRow(border, i);
                i++;
            }
        }

        public void Shortcuts(List<Shortcut> shortcuts)
{
    shortcuts.Add(new Shortcut("Ctrl + C", "Copy"));
    shortcuts.Add(new Shortcut("Ctrl + V", "Paste"));
    shortcuts.Add(new Shortcut("Ctrl + X", "Cut"));
    shortcuts.Add(new Shortcut("Ctrl + A", "Select all text"));
}
    }
}
