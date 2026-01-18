using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.ViewModels;
using kursadarbs_reactiveUI.Views;
using System.Globalization;

namespace kursadarbs_reactiveUI;

public partial class AnnoyedApp : Window
{
    public AnnoyedApp()
    {
        InitializeComponent();
        DataContext = new AnnoyedAppViewModel();
    }
    private AnnoyedAppViewModel VM => (AnnoyedAppViewModel)DataContext!;

    private void Journal_Click(object? s, RoutedEventArgs e) => VM.ShowNotes();
    private void Todo_Click(object? s, RoutedEventArgs e) => VM.ShowTodo();
    private void Focus_Click(object? s, RoutedEventArgs e) => VM.ShowFocus();

    private void langselect_eng_Click(object? sender, RoutedEventArgs e)
    {
        Assets.Resources.Culture = new CultureInfo("en-US");
        var refreshwindow = new AnnoyedApp();
        var oldwindow = this;
        refreshwindow.Show();
        oldwindow.Close();
    }
    private void langselect_lv_Click(object? sender, RoutedEventArgs e)
    {
        Assets.Resources.Culture = new CultureInfo("lv-LV");
        var refreshwindow = new AnnoyedApp();
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
    private void Check_invis_Checked(object? sender, RoutedEventArgs e)
    {
        AppTitleButton.IsVisible = false;
        AppTitleButton1.IsVisible = false;
        AppTitleButton2.IsVisible = false;
        AppTitleButton3.IsVisible = false;

        icon.IsVisible = true;
        icon1.IsVisible = true;
        icon2.IsVisible = true;
        icon3.IsVisible = true;
    }

    private void Check_invis_Unchecked(object? sender, RoutedEventArgs e)
    {
        AppTitleButton.IsVisible = true;
        AppTitleButton1.IsVisible = true;
        AppTitleButton2.IsVisible = true;
        AppTitleButton3.IsVisible = true;

        icon.IsVisible = false;
        icon1.IsVisible = false;
        icon2.IsVisible = false;
        icon3.IsVisible = false;
    }
}