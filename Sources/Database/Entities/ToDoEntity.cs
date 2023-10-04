using Model;

namespace Database.Entities
{
    public class ToDoEntity
    {
        [SQLite.PrimaryKey]
        public Guid ID { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
