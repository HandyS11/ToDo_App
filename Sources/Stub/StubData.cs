using Model;

namespace Stub
{
    public class StubData : IDataManager
    {
        private readonly List<ToDo> toDos;

        public StubData()
        {
            toDos = new()
            {
                new(Guid.NewGuid(), "Start the ToDo Project", true, "It shall be done correctly", DateTime.Parse("01/09/2023")),
                new(Guid.NewGuid(), "End the ToDo Project", false, "Yes you have to!", DateTime.Parse("01/09/2023")),
                new(Guid.NewGuid(), "Work on the ToDo app", true, "It will not be completed otherwise", DateTime.Parse("02/09/2023")),
                new(Guid.NewGuid(), "Do a great front", false, "The front is really important", DateTime.Parse("02/09/2023")),
                new(Guid.NewGuid(), "Do a clean back", true, "The logic shall be perfect", DateTime.Parse("02/09/2023")),
                new(Guid.NewGuid(), "Test the code", false, "Yes.. maybe another day", DateTime.Parse("03/09/2023")),
                new(Guid.NewGuid(), "Test the code (for real)", false, "!!!", DateTime.Parse("03/09/2023"))
            };
        }

        public Task AddTodo(ToDo todo)
        {
            return Task.Run(() => toDos.Add(todo));
        }

        public Task SaveTodo(ToDo todo)
        {
            if (toDos.Contains(todo))
            {
                return UpdateTodo(todo);
            }
            return AddTodo(todo);
        }

        public Task UpdateTodo(ToDo todo)
        {
            return Task.Run(() =>
            {
                var td = toDos.Find(t => t.Id == todo.Id);
                if (td != null)
                {
                    td.Title = todo.Title;
                    td.IsDone = todo.IsDone;
                    td.Description = todo.Description;
                }
            });
        }

        public Task<bool> DeleteTodo(ToDo todo)
        {
            return Task.FromResult(toDos.Remove(todo));
        }

        public Task<IEnumerable<ToDo>> GetAllToDos()
        {
            return Task.FromResult<IEnumerable<ToDo>>(toDos);
        }

        public Task<IEnumerable<ToDo>> GetSomeToDos(int size, int limit)
        {
            return Task.FromResult(toDos.Skip(size).Take(limit));
        }

        public Task<IEnumerable<ToDo>> GetToDosByCompletion(bool isDone)
        {
            return Task.FromResult(toDos.Where(td => td.IsDone == isDone));
        }

        public Task<ToDo?> GetToDosById(Guid id)
        {
            return Task.FromResult(toDos.Find(td => td.Id == id));
        }

        public Task<ToDo?> GetToDosByTitle(string title)
        {
            return Task.FromResult(toDos.Find(td => td.Title == title));
        }

        public Task<int> GetToDosCount()
        {
            return Task.FromResult(toDos.Count);
        }
    }
}
