namespace AvaHash.ViewModels;

using System;
using System.Threading.Tasks;
using Avalonia.Input.Platform;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;

public partial class HashResult
{
    public string HashType { get; set; } = String.Empty;
    public string Hash { get; set; } = String.Empty;

    [RelayCommand]
    public async Task CopyToClipboard(HashResult data)
    {
        WeakReferenceMessenger.Default.Send(data);
        await Task.CompletedTask;
    }
}
