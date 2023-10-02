using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace VM
{
    public partial class AddOrEditToDoVM : ToDoVM
    {
        [ObservableProperty]
        private bool isNewToDo = false;

        [ObservableProperty]
        private string editTitle;

        [ObservableProperty]
        private string editDescription;

        public AddOrEditToDoVM() : base(new ToDo("EMPTY_TITLE")) { }

        public void Clone(ToDoVM vm)
        {
            if (vm == null)
            {
                IsNewToDo = true;
                Model = new ToDo("EMPTY_TITLE");
            }
            else
            {
                IsNewToDo = false;
                Model = vm.Model;
                EditTitle = vm.Title;
                EditDescription = vm.Description;
            }
        }
    }
}
