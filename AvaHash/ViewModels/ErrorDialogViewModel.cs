namespace AvaHash.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class ErrorDialogViewModel : ViewModelBase
{
    public enum DialogResult
    {
        Canceled,
        Ok
    }

    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private string _message = string.Empty;

    [RelayCommand]
    private async Task Ok()
    {
        Close(DialogResult.Ok);
        await Task.CompletedTask;
    }

    public Action<DialogResult> Close { get; set; } = _ => { };
}
