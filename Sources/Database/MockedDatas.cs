using Database.Entities;

namespace Database
{
    public static class MockedDatas
    {
        public static List<ToDoEntity> GetDatas()
        {
            return new()
            {
                new(){ ID = Guid.NewGuid(), Title = "Start the ToDo Project", IsDone = true, Description = "It shall be done correctly", CreationDate = DateTime.Parse("01/09/2023") },
                new(){ ID = Guid.NewGuid(), Title = "End the ToDo Project", IsDone = false, Description = "Yes you have to!", CreationDate = DateTime.Parse("01/09/2023") },
                new(){ ID = Guid.NewGuid(), Title = "Work on the ToDo app", IsDone = true, Description = "It will not be completed otherwise", CreationDate = DateTime.Parse("02/09/2023") },
                new(){ ID = Guid.NewGuid(), Title = "Do a great front", IsDone = false, Description = "The front is really important", CreationDate = DateTime.Parse("02/09/2023") },
                new(){ ID = Guid.NewGuid(), Title = "Do a clean back", IsDone = true, Description = "The logic shall be perfect", CreationDate = DateTime.Parse("02/09/2023") },
                new(){ ID = Guid.NewGuid(), Title = "Test the code", IsDone = false, Description = "Yes.. maybe another day", CreationDate = DateTime.Parse("03/09/2023") },
                new(){ ID = Guid.NewGuid(), Title = "Test the code (for real)", IsDone = false, Description = "!!!", CreationDate = DateTime.Parse("03/09/2023") },
            };
        }
    }
}
