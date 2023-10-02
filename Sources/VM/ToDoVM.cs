using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Model;

namespace VM
{
    public partial class ToDoVM : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Id))]
        [NotifyPropertyChangedFor(nameof(Title))]
        [NotifyPropertyChangedFor(nameof(IsDone))]
        [NotifyPropertyChangedFor(nameof(Description))]
        [NotifyPropertyChangedFor(nameof(CreationDate))]
        private ToDo model;

        public Guid Id
        {
            get => Model.Id;
        }

        public string Title
        {
            get => Model.Title;
            set => SetProperty(Model.Title, value, Model, (m, v) => m.Title = v);
        }

        public bool IsDone
        {
            get => Model.IsDone;
            set
            {
                //WeakReferenceMessenger.Default.Send(this);   TODO: migrated to this tool
                if (value != Model.IsDone) MessagingCenter.Send(this, "StatusChanged", nameof(IsDone));
                SetProperty(Model.IsDone, value, Model, (m, v) => m.IsDone = v);
            }
        }

        public string Description
        {
            get => Model?.Description;
            set => SetProperty(Model.Description, value, Model, (m, v) => m.Description = v);
        }

        public DateTime CreationDate
        {
            get => Model.CreationDate;
        }

        public ToDoVM(ToDo model)
        {
            Model = model;
        }
    }
}
