namespace Model
{
    public class ToDo
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; private set; }

        public ToDo(string title) : this(title, "") { }

        public ToDo(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            Id = Guid.NewGuid();
            Title = title;
            IsDone = false;
            Description = description;
            CreationDate = DateTime.Now;
        }

        public ToDo(Guid id, string title, bool isDone, string description, DateTime creationDate)
        {
            Id = id;
            Title = title;
            IsDone = isDone;
            Description = description;
            CreationDate = creationDate;
        }

        public override string ToString()
        {
            return $"{CreationDate} : {Title} - {Description}";

        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not ToDo) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Id.Equals((obj as ToDo)?.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
