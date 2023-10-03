using ToDoApp.ViewModels;

namespace ToDoApp.Views.Pages;

public partial class ToDosPage : ContentPage
{
    private AppVM AppVM => (Application.Current as App).AppVM;

    public ToDosPage()
    {
        InitializeComponent();
        BindingContext = AppVM;
    }
}