using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.ViewModels;
using kursadarbs_reactiveUI.Views;
using System.Globalization;

namespace kursadarbs_reactiveUI;

public partial class HappyApp : Window
{
    public HappyApp()
    {
        InitializeComponent();
        DataContext = new HappyAppViewModel();
    }
    private HappyAppViewModel VM => (HappyAppViewModel)DataContext!;

    private void Notes_Click(object? s, RoutedEventArgs e) => VM.ShowNotes();
    private void Todo_Click(object? s, RoutedEventArgs e) => VM.ShowTodo();
    private void Pomo_Click(object? s, RoutedEventArgs e) => VM.ShowPomo();

    private void langselect_eng_Click(object? sender, RoutedEventArgs e)
    {
        Assets.Resources.Culture = new CultureInfo("en-US");
        var refreshwindow = new HappyApp();
        var oldwindow = this;
        refreshwindow.Show();
        oldwindow.Close();
    }
    private void langselect_lv_Click(object? sender, RoutedEventArgs e)
    {
        Assets.Resources.Culture = new CultureInfo("lv-LV");
        var refreshwindow = new HappyApp();
        var oldwindow = this;
        refreshwindow.Show();
        oldwindow.Close();
    }

    private void breathe_btn_Click(object? sender, RoutedEventArgs e)
    {
        var breathewindow = new BreatheMainWindow();
        breathewindow.Show();
    }

    private void moodselect_btn_Click(object? sender, RoutedEventArgs e)
    {
        var currentwindow = this;
        var moodselector = new MainWindow();
        moodselector.Show();
        currentwindow.Close();
    }
}