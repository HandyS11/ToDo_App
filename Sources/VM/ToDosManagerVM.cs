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

        private List<ToDoVM> toDos { get; set; } = new();

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

            WeakReferenceMessenger.Default.Register<ToDoVMessage>(this, (r, n) =>
            {
                RefreshToDos();
            });
        }

        [RelayCommand]
        public async Task LoadFromDatabase()
        {
            var todos = await DataManager.GetAllToDos();
            toDos.Clear();
            foreach (var td in todos)
            {
                toDos.Add(new(td));
            }
            RefreshToDos();
        }

        [RelayCommand]
        public async Task SaveToDatabase()
        {
            var todos = ToDosDone.ToList();
            todos.AddRange(ToDosNotDone);
            foreach (var td in todos)
            {
                await DataManager.SaveTodo(td.Model);
            }
        }

        [RelayCommand]
        private void RefreshToDos()
        {
            IsBusy = true;
            toDosDone.Clear();
            toDosNotDone.Clear();
            foreach (var td in toDos.OrderByDescending(t => t.CreationDate))
            {
                if (td.IsDone)
                {
                    toDosDone.Add(td);
                }
                else
                {
                    toDosNotDone.Add(td);
                }
            }
            IsBusy = false;

            Task.Run(() => SaveToDatabase());       // Due to the lack of QUIT/DESTROY event in MAUI
        }

        [RelayCommand]
        public void AddToDo(ToDoVM vm)
        {
            try
            {
                toDos.Add(vm);
                SelectedToDo = vm;
                RefreshToDos();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        [RelayCommand]
        public void EditTodo(ToDoVM vm)
        {
            try
            {
                var todo = toDos.Find(t => t.Id == vm.Id);
                if (todo == null)
                {
                    return;
                }
                todo.Title = vm.Title;
                todo.IsDone = vm.IsDone;
                todo.Description = vm.Description;
                SelectedToDo = vm;
                RefreshToDos();
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
                await DataManager.DeleteTodo(SelectedToDo.Model);
                toDos.Remove(SelectedToDo);
                SelectedToDo = null;
                RefreshToDos();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
