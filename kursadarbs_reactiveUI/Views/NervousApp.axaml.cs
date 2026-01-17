using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.ViewModels;
using kursadarbs_reactiveUI.Views;
using System.Globalization;

namespace kursadarbs_reactiveUI;

public partial class NervousApp : Window
{
    public NervousApp()
    {
        InitializeComponent();
        DataContext = new NervousAppViewModel();
    }
    private NervousAppViewModel VM => (NervousAppViewModel)DataContext!;

    private void Journal_Click(object? s, RoutedEventArgs e) => VM.ShowNotes();
    private void Todo_Click(object? s, RoutedEventArgs e) => VM.ShowTodo();
    private void Focus_Click(object? s, RoutedEventArgs e) => VM.ShowFocus();

    private void langselect_eng_Click(object? sender, RoutedEventArgs e)
    {
        Assets.Resources.Culture = new CultureInfo("en-US");
        var refreshwindow = new NervousApp();
        var oldwindow = this;
        refreshwindow.Show();
        oldwindow.Close();
    }
    private void langselect_lv_Click(object? sender, RoutedEventArgs e)
    {
        Assets.Resources.Culture = new CultureInfo("lv-LV");
        var refreshwindow = new NervousApp();
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