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
