namespace AvaHash.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _filename = "<select or drag-drop file into window to calculate hashes>";

    public ObservableCollection<HashResult> HashResults { get; } = new ObservableCollection<HashResult>();

    private static async Task<string> CalculateHashAsync(Func<HashAlgorithm> hasherFactory,string file)
    {
        using(var hasher = hasherFactory())
        {
            using(var stream = File.OpenRead(file))
            {
                var hash = await hasher.ComputeHashAsync(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }

    public async Task Calculate(Uri file)
    {
        HashResults.Clear();

        if(file.Scheme == Uri.UriSchemeFile)
        {
            var filename = file.LocalPath;
            Filename = filename;

            if(File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                HashResults.Add(new HashResult { HashType = "File size", Hash = fi.Length.ToString() });
                HashResults.Add(new HashResult { HashType = "MD5", Hash = await CalculateHashAsync(MD5.Create, filename) });
                HashResults.Add(new HashResult { HashType = "SHA1", Hash = await CalculateHashAsync(SHA1.Create, filename) });
                HashResults.Add(new HashResult { HashType = "SHA384", Hash = await CalculateHashAsync(SHA384.Create, filename) });
                HashResults.Add(new HashResult { HashType = "SHA256", Hash = await CalculateHashAsync(SHA256.Create, filename) });
                HashResults.Add(new HashResult { HashType = "SHA512", Hash = await CalculateHashAsync(SHA512.Create, filename) });
            }
        }
    }

    [RelayCommand]
    private async Task SelectFile()
    {
        try
        {
            var response = await WeakReferenceMessenger.Default.Send(
                new ShowSelectFileDialogAsyncRequestMessage());

            if(response is not null)
            {
                await Calculate(response);
            }
        }
        catch(Exception ex)
        {
            await WeakReferenceMessenger.Default.Send(
                new ShowErrorDialogAsyncRequestMessage() {
                    Title = "AvaHash Error",
                    Message = ex.ToString(), 
                });
        }
    }
}
