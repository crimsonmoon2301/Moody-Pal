using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.ViewModels;

namespace kursadarbs_reactiveUI.Views
{
    public partial class BreatheSelectionView : UserControl
    {
        public BreatheSelectionView()
        {
            InitializeComponent();
            DataContext = new BreatheMainWindowViewModel();
        }
        
    }
}