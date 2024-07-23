namespace AvaHash.ViewModels;

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Text;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<HashResult> HashResults { get; } = [];

    private static string RandStr()
    {
        const string charselection = "0123456789abcdef";
        int randLength = Random.Shared.Next(2, 40);
        StringBuilder cb = new();
        for(int i = 0;i<randLength;i++)
        {
            cb.Append(charselection[Random.Shared.Next(charselection.Length)]);
        }
        return cb.ToString();
    }

    [RelayCommand]
    private async Task FillList()
    {
        HashResults.Clear();

        for(int i = 0; i < 20; i++)
        {
            HashResults.Add(new HashResult { Hash = RandStr(), HashType = RandStr() });
            await Task.Delay(10);
        }
    }
}
