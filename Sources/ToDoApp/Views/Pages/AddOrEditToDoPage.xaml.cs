using ToDoApp.ViewModels;

namespace ToDoApp.Views.Pages;

public partial class AddOrEditToDoPage : ContentPage
{
    private AppVM AppVM => (Application.Current as App).AppVM;

    public AddOrEditToDoPage()
    {
        InitializeComponent();
        BindingContext = AppVM;
    }
}