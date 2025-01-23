using CommunityToolkit.Mvvm.ComponentModel;

namespace Presentation.WPF.MainApp.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Add new contact";
}
