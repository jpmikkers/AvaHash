#if NEVER
namespace AvaHash;
using AvaHash.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;
using System.Xml.Linq;

public class ViewLocator : IDataTemplate
{
    public Control Build(object? data)
    {
        if(data is not null)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if(type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }
        return new TextBlock { Text = "Not Found: null" };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}
#endif