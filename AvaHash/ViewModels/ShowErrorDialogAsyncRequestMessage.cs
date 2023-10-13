namespace AvaHash.ViewModels;

using CommunityToolkit.Mvvm.Messaging.Messages;

public class ShowErrorDialogAsyncRequestMessage : AsyncRequestMessage<ErrorDialogViewModel.DialogResult>
{
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
