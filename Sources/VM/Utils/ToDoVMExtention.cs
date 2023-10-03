using Model;

namespace VM.Utils
{
    public static class ToDoVMExtention
    {
        public static ToDoVM ToToDoVM(this AddOrEditToDoVM vm)
        {
            if (vm.IsNewToDo)
            {
                return new ToDoVM(new ToDo(vm.EditTitle, vm.EditDescription));
            }
            else
            {
                var todo = vm.Model;
                todo.Title = vm.EditTitle;
                todo.Description = vm.EditDescription;
                return new ToDoVM(todo);
            }
        }
    }
}
