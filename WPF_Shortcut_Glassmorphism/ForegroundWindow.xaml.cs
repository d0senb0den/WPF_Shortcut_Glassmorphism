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
            ShortcutGrid.Margin = new Thickness(50, 0, 0, 0);

            
            foreach (var s in shortcuts)
            {
                RowDefinition row = new();
                row.Height = GridLength.Auto;
                ShortcutGrid.RowDefinitions.Add(row);


                Border border = new();
                border.Height = SystemParameters.PrimaryScreenHeight * 0.11;
                border.Width = SystemParameters.PrimaryScreenWidth * 0.15;
                border.Background = Brushes.White;
                border.Opacity = 0.7;
                border.Margin = new Thickness(0, 5, 0, 5);
                //border.BorderBrush = Brushes.Gray;
                //border.BorderThickness = new Thickness(0, 0, 0.5, 0.5);
                border.CornerRadius = new CornerRadius(5);
                border.Effect = new DropShadowEffect() { ShadowDepth = 1, Opacity = 0.5 };

                RadialGradientBrush radialGradient = new RadialGradientBrush();

                // Set the GradientOrigin to the center of the area being painted.
                radialGradient.GradientOrigin = new Point(0, 0);

                // Set the gradient center to the center of the area being painted.
                radialGradient.Center = new Point(0.5, 0.5);

                // Set the radius of the gradient circle so that it extends to
                // the edges of the area being painted.
                radialGradient.RadiusX = 0.5;
                radialGradient.RadiusY = 0.5;

                // Create four gradient stops.
                radialGradient.GradientStops.Add(new GradientStop(Color.FromArgb(179, 255, 255, 255), 0.0));
                radialGradient.GradientStops.Add(new GradientStop(Color.FromArgb(26, 255,255,255), 1.1));

                // Freeze the brush (make it unmodifiable) for performance benefits.
                radialGradient.Freeze();
                border.Child = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Children =
                        {
                            new StackPanel()
                            {
                                Margin = new Thickness(0, 0, 0, 10),
                                Orientation = Orientation.Horizontal,
                                Children =
                                {
                                    new Border() {
                                        Width = 50,
                                        Height = 35,
                                        Child =
                                        new Grid()
                                        {
                                            Children =
                                            {
                                                new Rectangle()
                                                {
                                                    Width = 50,
                                                    Height = 35,
                                                    Fill = radialGradient,
                                                    RadiusX = 8,
                                                    RadiusY = 8,
                                                    Stroke =new SolidColorBrush(Color.FromRgb(96, 175, 229)),
                                                    StrokeThickness = -2,
                                                },
                                                new Label
                                                {
                                                    Content = s.Keys[0],
                                                    HorizontalAlignment = HorizontalAlignment.Center,
                                                    VerticalAlignment= VerticalAlignment.Center,
                                                    //LineBreakMode = LineBreakMode.WordWrap,
                                                    FontFamily = new FontFamily("Arial"),
                                                    FontSize = 15
                                                },
                                            },
                                        },
                                        //CornerRadius = new CornerRadius(8),
                                        //BorderBrush = Brushes.Blue,
                                        //BorderThickness = new Thickness(2),
                                        //Effect = new DropShadowEffect()
                                        //{
                                        //    ShadowDepth = 0,
                                        //    BlurRadius = 5,
                                        //    Color = Color.FromRgb(96, 175, 229)
                                        //}
                                    },
                                    new Label
                                    {
                                        Content = " + ",
                                        HorizontalAlignment = HorizontalAlignment.Center,
                                        VerticalAlignment = VerticalAlignment.Center,
                                        FontFamily = new FontFamily("Arial"),
                                        FontSize = 15
                                    },
                                    new Border() {
                                        Width = 50,
                                        Height = 35,
                                        Child =
                                        new Grid()
                                        {
                                            Children =
                                            {
                                               new Rectangle()
                                                {
                                                    Width = 50,
                                                    Height = 35,
                                                    Fill = radialGradient,
                                                    RadiusX = 8,
                                                    RadiusY = 8,
                                                    // Stroke = Brushes.White,
                                                    //StrokeThickness = -1,
                                                },
                                                new Label
                                                {
                                                    Content = s.Keys[1],
                                                    HorizontalAlignment = HorizontalAlignment.Center,
                                                    VerticalAlignment= VerticalAlignment.Center,
                                                    //LineBreakMode = LineBreakMode.WordWrap,
                                                    FontFamily = new FontFamily("Arial"),
                                                    FontSize = 15
                                                },
                                            },
                                        },
                                        Opacity = 1,
                                        CornerRadius = new CornerRadius(8),
                                        BorderBrush = Brushes.Black,
                                        BorderThickness = new Thickness(1),
                                        //Effect = new DropShadowEffect()
                                        //{
                                        //    ShadowDepth = 0,
                                        //    BlurRadius = 5,
                                        //    Opacity = 0.5
                                        //}
                                    },
                                },
                            },
                            new Label
                            {
                                Content = s.Description,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                //LineBreakMode = LineBreakMode.WordWrap,
                                //FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                                FontFamily = new FontFamily("Arial"),
                                FontSize = 15
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
    shortcuts.Add(new Shortcut("Copy", "Ctrl", "C"));
    shortcuts.Add(new Shortcut("Paste", "Ctrl", "V"));
    shortcuts.Add(new Shortcut("Cut", "Ctrl", "X"));
    shortcuts.Add(new Shortcut("Select all text", "Ctrl", "A"));
}
    }
}
