namespace AvaHash.Views;

using AvaHash.ViewModels;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System.Linq;
using System.Threading.Tasks;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        AddHandler(DragDrop.DragOverEvent, DragOverHandler);
        AddHandler(DragDrop.DropEvent, DropHandler);

        // see: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/messenger
        WeakReferenceMessenger.Default.Register<MainWindow, AsyncRequestMessage<SelectedFile>>(this, (r, m) =>
        {
            m.Reply(SelectFile());
        });

        WeakReferenceMessenger.Default.Register<MainWindow, HashResult>(this, async (r, m) =>
        {
            if(Clipboard is not null)
            {
                await Clipboard.SetTextAsync(m.Hash);
            }
        });
    }

    private async Task<SelectedFile> SelectFile()
    {
        var files = await StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                AllowMultiple = false,
                FileTypeFilter = new[] { FilePickerFileTypes.All },
                Title = "Select file to upload.."
            }
        );

        return files.Count>0 ? new SelectedFile() { Path = files[0].Path } : new SelectedFile();
    }

    private void DragOverHandler(object? sender, DragEventArgs e)
    {
        var files = e.Data.GetFiles();
        if(files!=null && files.Count() > 0)
        {
            e.DragEffects = DragDropEffects.Copy;
            e.Handled = true;
        }
    }

    private async void DropHandler(object? sender, DragEventArgs e)
    {
        if(DataContext is MainWindowViewModel viewModel)
        {
            if(e.Data.GetFiles() is { } fileNames)
            {
                foreach(var file in fileNames)
                {
                    await viewModel.Calculate(file.Path);
                    //viewModel.Greeting = file.Path.ToString();

                    //ViewModel.Attachments.Add(new AttachmentLink(file));
                }
            }
        }
    }

}
