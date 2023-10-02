namespace Model
{
    public interface IDataManager
    {
        // GET COUNT
        Task<int> GetToDosCount();

        // GETs
        Task<ToDo?> GetToDosById(Guid id);
        Task<ToDo?> GetToDosByTitle(string title);
        Task<IEnumerable<ToDo>> GetToDosByCompletion(bool isDone);
        Task<IEnumerable<ToDo>> GetSomeToDos(int size, int limit);
        Task<IEnumerable<ToDo>> GetAllToDos();

        // EDITs
        Task<ToDo?> AddTodo(ToDo todo);
        Task<ToDo?> UpdateTodo(Guid id, ToDo todo);
        Task<bool> DeleteTodo(ToDo todo);

    }
}
