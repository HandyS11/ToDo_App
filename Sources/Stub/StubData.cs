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
                new("First title", "first desc"),
                new("Second title", "second desc"),
                new("Third title", "third desc"),
                new("Fourth title", "fourth desc"),
                new("Fifth title", "fifth desc"),
                new("Sixth title", "sixth desc"),
                new("Seventh title", "seventh desc"),
            };
            toDos[2].IsDone = true;
            toDos[3].IsDone = true;
            toDos[6].IsDone = true;
        }

        public Task<ToDo?> AddTodo(ToDo todo)
        {
            toDos.Add(todo);
            return Task.FromResult<ToDo?>(todo);
        }

        public Task<ToDo?> UpdateTodo(ToDo todo)
        {
            var td = toDos.Find(t => t.Id == todo.Id);
            if (td == null) return Task.FromResult<ToDo?>(null);
            td.Title = todo.Title;
            td.IsDone = todo.IsDone;
            td.Description = todo.Description;
            return Task.FromResult<ToDo?>(td);

        }

        public Task<bool> DeleteTodo(ToDo todo)
        {
            var b = toDos.Remove(todo);
            return Task.FromResult(b);
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
