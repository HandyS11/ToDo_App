using CommunityToolkit.Mvvm.Input;
using ToDoApp.Views.Pages;
using VM;
using VM.Utils;

namespace ToDoApp.ViewModels
{
    public partial class AppVM
    {
        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public ToDosManagerVM ToDosManagerVM { get; private set; }
        public AddOrEditToDoVM AddOrEditToDoVM { get; private set; }

        public AppVM(ToDosManagerVM toDosManagerVM, AddOrEditToDoVM addOrEditToDoVM)
        {
            ToDosManagerVM = toDosManagerVM;
            AddOrEditToDoVM = addOrEditToDoVM;
        }

        [RelayCommand]
        private async Task NavigateBack()
        {
            await Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task GoToToDoDetail(ToDoVM vm)
        {
            ToDosManagerVM.SelectedToDo = vm;
            await Navigation.PushAsync(new ToDoDetailPage());
        }

        [RelayCommand]
        private async Task GoToAddTodo()
        {
            AddOrEditToDoVM.Clone(null);
            await Navigation.PushAsync(new AddOrEditToDoPage());
        }

        [RelayCommand]
        private async Task GoToEditToDo(ToDoVM vm)
        {
            AddOrEditToDoVM.Clone(vm);
            await Navigation.PushAsync(new AddOrEditToDoPage());
        }

        [RelayCommand]
        private async Task AddToDo()
        {
            ToDosManagerVM.AddToDo(AddOrEditToDoVM.ToToDoVM());
            await NavigateBack();
        }

        [RelayCommand]
        private async Task EditToDo()
        {
            ToDosManagerVM.EditTodo(AddOrEditToDoVM.ToToDoVM());
            await NavigateBack();
        }

        [RelayCommand]
        private async Task DeleteToDo()
        {
            await ToDosManagerVM.DeleteToDo();
            await NavigateBack();
        }
    }
}
