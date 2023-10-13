namespace AvaHash.Views;

using AvaHash.ViewModels;
using Avalonia.Controls;
using System.Threading.Tasks;

public partial class ErrorDialog : Window
{
    public ErrorDialog()
    {
        InitializeComponent();
    }

    public static async Task<ErrorDialogViewModel.DialogResult> ShowDialog(Window owner, string title, string message)
    {
        var vm = new ErrorDialogViewModel()
        {
            Title = title,
            Message = message
        };

        var dialog = new ErrorDialog() { 
            DataContext = vm
        };

        vm.Close = x => { dialog.Close(x); };

        return await dialog.ShowDialog<ErrorDialogViewModel.DialogResult?>(owner) ?? ErrorDialogViewModel.DialogResult.Canceled;
    }
}
