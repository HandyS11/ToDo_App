using ToDoApp.ViewModels;

namespace ToDoApp.Views.Pages;

public partial class ToDoDetailPage : ContentPage
{
    private AppVM AppVM => (Application.Current as App).AppVM;

    public ToDoDetailPage()
    {
        InitializeComponent();
        BindingContext = AppVM;
    }
}