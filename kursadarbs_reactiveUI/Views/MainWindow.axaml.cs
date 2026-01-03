using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System.Threading.Tasks;
using kursadarbs_reactiveUI.ViewModels;
using kursadarbs_reactiveUI.Views;
using kursadarbs_reactiveUI;
using System.Globalization;
using Avalonia;
using System.Diagnostics;

namespace kursadarbs_reactiveUI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Each of the buttons has a event binded to this function. It reads the button's name and adapts accordingly. It reads the text from the locale files located in /Assets/*.resx
        private void info_controller(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            var button = (sender as Button)!;
            switch (button.Name)
            {
                case "annoyed_btn":
                    Infotip.Text = Assets.Resources.Infotip_annoyed;
                    break;
                case "calm_btn":
                    Infotip.Text = Assets.Resources.Infotip_calm;
                    break;
                case "happy_btn":
                    Infotip.Text = Assets.Resources.Infotip_happy;
                    break;
                case "nervous_btn":
                    Infotip.Text = Assets.Resources.Infotip_nerv;
                    break;
                default:
                    Infotip.Text = " ";
                    break;
                    //case "annoyed_btn":
                    //    Infotip.Text = "Program will use neutral colors and less distractions to get more done";
                    //    break;
                    //case "calm_btn":
                    //    Infotip.Text = "Program will use calm, warmer colors";
                    //    break;
                    //case "happy_btn":
                    //    Infotip.Text = "Program will launch as normal";
                    //    break;
                    //case "nervous_btn":
                    //    Infotip.Text = "Program will offer breathing exercises before you begin, colors more warmer, that don't cause emotions";
                    //    break;
                    //default:
                    //    Infotip.Text = " ";
                    //    break;
            }
        }
        private void hover_PointerMoved(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            Infotip.Text = " ";
        }

        private void annoyed_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var annoyedwindow = new AnnoyedApp();
            annoyedwindow.Show();
            this.Close();
        }

        private void calm_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var calmwindow = new CalmApp();
            calmwindow.Show();
            this.Close();
        }

        private void nervous_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var nervouswindow = new NervousApp();
            nervouswindow.Show();
            this.Close();
        }

        private void happy_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var happywindow = new HappyApp();
            happywindow.Show();
            this.Close();
        }

        private void langselect_eng_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Assets.Resources.Culture = new CultureInfo("en-US");
            var refreshwindow = new MainWindow();
            var oldwindow = this;
            refreshwindow.Show();
            oldwindow.Close();
        }

        private void langselect_lv_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Assets.Resources.Culture = new CultureInfo("lv-LV");
            var refreshwindow = new MainWindow();
            var oldwindow = this;
            refreshwindow.Show();
            oldwindow.Close();
            
        }
    }
}