using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.ViewModels;

namespace kursadarbs_reactiveUI;

public partial class HappyApp : Window
{
    public HappyApp()
    {
        InitializeComponent();
        DataContext = new HappyAppViewModel();
    }
}