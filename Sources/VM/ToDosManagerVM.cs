using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace VM
{
    public partial class ToDosManagerVM : ObservableObject
    {
        public ReadOnlyObservableCollection<ToDoVM> ToDosNotDone { get; private set; }
        private ObservableCollection<ToDoVM> toDosNotDone { get; set; } = new();

        public ReadOnlyObservableCollection<ToDoVM> ToDosDone { get; private set; }
        private ObservableCollection<ToDoVM> toDosDone { get; set; } = new();

        [ObservableProperty]
        private ToDoVM selectedToDo = new(new ToDo("EMPTY_TITLE"));

        [ObservableProperty]
        private IDataManager dataManager;

        [ObservableProperty]
        private bool isTodosNotDoneExpanded = true;

        [ObservableProperty]
        private bool isTodosDoneExpanded = true;

        [ObservableProperty]
        private bool isBusy = false;

        public ToDosManagerVM(IDataManager dataManager)
        {
            DataManager = dataManager;
            ToDosNotDone = new ReadOnlyObservableCollection<ToDoVM>(toDosNotDone);
            ToDosDone = new ReadOnlyObservableCollection<ToDoVM>(toDosDone);

            WeakReferenceMessenger.Default.Register<ToDoVMessage>(this, async (r, n) =>
            {
                if (await DataManager.UpdateTodo(n.Value.Model) == null) Debug.WriteLine("ERROR WHILE UPDATING TODO");
                await LoadToDos();
            });
        }

        [RelayCommand]
        private async Task LoadToDos()
        {
            IsBusy = true;
            toDosDone.Clear();
            toDosNotDone.Clear();
            var tds = await DataManager.GetAllToDos();
            foreach (var td in tds.OrderByDescending(t => t.CreationDate))
            {
                if (td.IsDone)
                {
                    toDosDone.Add(new(td));
                }
                else
                {
                    toDosNotDone.Add(new(td));
                }
            }
            IsBusy = false;
        }

        [RelayCommand]
        private async Task ChangeToDoState(ToDoVM vm)
        {
            vm.IsDone = vm.IsDone!;
            await EditTodo(vm);
            await LoadToDos();
        }

        [RelayCommand]
        public async Task AddToDo(ToDoVM vm)
        {
            try
            {
                if (await DataManager.AddTodo(vm.Model) == null)
                {
                    return;
                }
                SelectedToDo = vm;
                await LoadToDos();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        [RelayCommand]
        public async Task EditTodo(ToDoVM vm)
        {
            try
            {
                if (await DataManager.UpdateTodo(vm.Model) == null)
                {
                    return;
                }
                SelectedToDo = vm;
                await LoadToDos();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        [RelayCommand]
        public async Task DeleteToDo()
        {
            try
            {
                if (!await DataManager.DeleteTodo(SelectedToDo.Model))
                {
                    return;
                }
                SelectedToDo = null;
                await LoadToDos();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
