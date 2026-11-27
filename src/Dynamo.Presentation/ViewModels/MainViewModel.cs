using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Dynamo.Presentation.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<NodeViewModel> Nodes { get; } = [];

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RemoveSelectedNodeCommand))]
    public partial NodeViewModel? SelectedNode { get; set; }

    [RelayCommand]
    private void AddTextBlock() => AddNode(new TextBlockViewModel
    {
        Id = Guid.NewGuid(),
        Name = "Bloco de texto",
    });

    [RelayCommand]
    private void AddTextBox() => AddNode(new TextBoxViewModel
    {
        Id = Guid.NewGuid(),
        Name = "Caixa de texto",
    });

    [RelayCommand]
    private void AddCalendarDatePicker() => AddNode(new CalendarDatePickerViewModel
    {
        Id = Guid.NewGuid(),
        Name = "Seletor de data em calendário",
    });

    [RelayCommand]
    private void AddCheckBox() => AddNode(new CheckBoxViewModel
    {
        Id = Guid.NewGuid(),
        Name = "Caixa de seleção",
    });

    [RelayCommand]
    private void AddSpacing() => AddNode(new SpacingViewModel
    {
        Id = Guid.NewGuid(),
        Name = "Espaçamento",
    });

    [RelayCommand(CanExecute = nameof(CanRemoveSelectedNode))]
    private void RemoveSelectedNode()
    {
        if (SelectedNode is null)
        {
            return;
        }

        Nodes.Remove(SelectedNode);
        SelectedNode = null;
    }

    private void AddNode(NodeViewModel node)
    {
        Nodes.Add(node);
        SelectedNode = node;
    }

    private bool CanRemoveSelectedNode() => SelectedNode is not null;
}
