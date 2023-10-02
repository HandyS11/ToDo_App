using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using System.Collections.ObjectModel;

namespace VM
{
    public partial class ToDoManagerVM : ObservableObject
    {
        public ReadOnlyObservableCollection<ToDoVM> ToDos { get; private set; }
        private ObservableCollection<ToDoVM> toDos { get; set; } = new();

        [ObservableProperty]
        private ToDoVM selectedToDo = new(new ToDo("EMPTY_TITLE"));

        [ObservableProperty]
        private IDataManager dataManager;

        [RelayCommand]
        private async Task LoadToDos()
        {
            toDos.Clear();
            var tds = await DataManager.GetAllToDos();
            foreach (var td in tds)
            {
                toDos.Add(new(td));
            }
        }

        [RelayCommand]
        private async Task ChangeToDoState(ToDoVM vm)
        {
            vm.IsDone = vm.IsDone!;
            await EditTodo(vm);
        }

        [RelayCommand]
        private async Task AddToDo(ToDoVM vm)
        {
            if (await DataManager.AddTodo(vm.Model) != null)
            {
                SelectedToDo = vm;
                await LoadToDos();      //TODO: It should be optimized
            }
        }

        [RelayCommand]
        private async Task EditTodo(ToDoVM vm)
        {
            if (await DataManager.UpdateTodo(SelectedToDo.Id, vm.Model) != null)
            {
                SelectedToDo = vm;
                await LoadToDos();      //TODO: It should be optimized
            }
        }

        [RelayCommand]
        private async Task DeleteToDo()
        {
            if (await DataManager.DeleteTodo(SelectedToDo.Model))
            {
                SelectedToDo = null;
                await LoadToDos();      //TODO: It should be optimized
            }
        }
    }
}
