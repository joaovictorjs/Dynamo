using Avalonia.Controls;
using Dynamo.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Dynamo.Presentation.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    [ActivatorUtilitiesConstructor]
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
