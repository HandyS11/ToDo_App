using Database.Entities;
using Model;
using SQLite;

namespace Database
{
    public class ToDosDatabase : IDataManager
    {
        SQLiteAsyncConnection Database;

        public ToDosDatabase() { }

        protected async Task Init()
        {
            if (Database is not null) return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<ToDoEntity>();

            if (await Database.Table<ToDoEntity>().CountAsync() < 1)
            {
                await Database.InsertAllAsync(MockedDatas.GetDatas());
            }
        }

        public async Task AddTodo(ToDo todo)
        {
            await Init();
            var entity = todo.ToEntity();
            await Database.InsertAsync(entity);
        }

        public async Task UpdateTodo(ToDo todo)
        {
            await Init();
            var entity = todo.ToEntity();
            await Database.UpdateAsync(entity);
        }

        public Task SaveTodo(ToDo todo)
        {
            if (GetToDosById(todo.Id) is not null)
            {
                return UpdateTodo(todo);
            }
            return AddTodo(todo);
        }

        public async Task<bool> DeleteTodo(ToDo todo)
        {
            await Init();
            var entity = todo.ToEntity();
            return await Database.DeleteAsync(entity) > 0;
        }

        /* GETs */
        public async Task<IEnumerable<ToDo>> GetAllToDos()
        {
            await Init();
            return await Database.Table<ToDoEntity>().ToListAsync().ContinueWith(t => t.Result.ToModels());
        }

        public async Task<IEnumerable<ToDo>> GetSomeToDos(int size, int limit)
        {
            await Init();
            return await Database.Table<ToDoEntity>().Skip(size).Take(limit).ToListAsync().ContinueWith(t => t.Result.ToModels());
        }

        public Task<IEnumerable<ToDo>> GetToDosByCompletion(bool isDone)
        {
            throw new NotImplementedException();
        }

        public async Task<ToDo> GetToDosById(Guid id)
        {
            await Init();
            return await Database.Table<ToDoEntity>().Where(e => e.ID == id).FirstOrDefaultAsync().ContinueWith(t => t.Result.ToModel());
        }

        public async Task<ToDo> GetToDosByTitle(string title)
        {
            await Init();
            return await Database.Table<ToDoEntity>().Where(e => e.Title == title).FirstOrDefaultAsync().ContinueWith(t => t.Result.ToModel());
        }

        /* COUNT */
        public async Task<int> GetToDosCount()
        {
            await Init();
            return await Database.Table<ToDoEntity>().CountAsync();
        }
    }
}
