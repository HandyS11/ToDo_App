using Model;

namespace Database.Entities
{
    public static class ToDoExtension
    {
        public static ToDo ToModel(this ToDoEntity entity)
        {
            return new ToDo(entity.ID, entity.Title, entity.IsDone, entity.Description, entity.CreationDate);
        }

        public static IEnumerable<ToDo> ToModels(this IEnumerable<ToDoEntity> entities)
        {
            return entities.Select(e => e.ToModel());
        }

        public static ToDoEntity ToEntity(this ToDo model)
        {
            return new ToDoEntity
            {
                ID = model.Id,
                Title = model.Title,
                IsDone = model.IsDone,
                Description = model.Description,
                CreationDate = model.CreationDate
            };
        }

        public static IEnumerable<ToDoEntity> ToEntities(this IEnumerable<ToDo> models)
        {
            return models.Select(m => m.ToEntity());
        }
    }
}
