using System.Collections.ObjectModel;

namespace Model
{
    public class Manager
    {
        private readonly List<ToDo> _toDos = new();
        public IEnumerable<ToDo> ToDos => new ReadOnlyCollection<ToDo>(_toDos);

        public Manager(List<ToDo> toDos)
        {
            if (toDos == null)
            {
                throw new ArgumentNullException(nameof(toDos));
            }
            _toDos.AddRange(toDos);
        }

        public void Add(ToDo toDo)
        {
            if (toDo == null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }
            _toDos.Add(toDo);
        }

        public void Remove(ToDo toDo)
        {
            if (toDo == null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }
            _toDos.Remove(toDo);
        }

        public void Clear()
        {
            _toDos.Clear();
        }
    }
}
