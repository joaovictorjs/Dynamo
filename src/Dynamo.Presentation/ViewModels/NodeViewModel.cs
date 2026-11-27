using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Dynamo.Presentation.ViewModels;

public abstract partial class NodeViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial Guid Id { get; set; }

    [ObservableProperty]
    public partial string Name { get; set; } = string.Empty;
}

public partial class TextBlockViewModel : NodeViewModel
{
    [ObservableProperty]
    public partial string Text { get; set; } = string.Empty;

    [ObservableProperty]
    public partial double FontSize { get; set; } = 14;
}

public partial class TextBoxViewModel : NodeViewModel
{
    [ObservableProperty]
    public partial string Label { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Placeholder { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Text { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Target { get; set; } = string.Empty;
}

public partial class CalendarDatePickerViewModel : NodeViewModel
{
    [ObservableProperty]
    public partial string Label { get; set; } = string.Empty;

    [ObservableProperty]
    public partial DateTime? SelectedDate { get; set; }

    [ObservableProperty]
    public partial string Target { get; set; } = string.Empty;
}

public partial class CheckBoxViewModel : NodeViewModel
{
    [ObservableProperty]
    public partial string Label { get; set; } = string.Empty;

    [ObservableProperty]
    public partial bool IsChecked { get; set; }

    [ObservableProperty]
    public partial string Target { get; set; } = string.Empty;
}

public partial class SpacingViewModel : NodeViewModel
{
    [ObservableProperty]
    public partial double Height { get; set; }
}
