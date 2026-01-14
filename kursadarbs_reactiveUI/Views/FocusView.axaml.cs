using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace kursadarbs_reactiveUI.Views
{
    public partial class FocusView : UserControl
    {
        public FocusView()
        {
            InitializeComponent();
        }


        private void starttimer_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            starttimer_btn.IsVisible = false;
            pausetimer_btn.IsVisible = true;
            addtime_btn.IsVisible = false;
            removetime_btn.IsVisible = false;
        }
        private void pausetimer_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            pausetimer_btn.IsVisible = false;
            starttimer_btn.IsVisible = true;
            addtime_btn.IsVisible = true;
            removetime_btn.IsVisible = true;
        }

        private void stoptimer_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            pausetimer_btn.IsVisible = false;
            starttimer_btn.IsVisible = true;
            addtime_btn.IsVisible = true;
            removetime_btn.IsVisible = true;
        }
    }
}
